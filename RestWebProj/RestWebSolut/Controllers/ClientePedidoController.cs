using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestWebSolut.Models;

namespace RestWebSolut.Controllers
{
    public class ClientePedidoController : Controller
    {
        private RestWebSolutContext db = new RestWebSolutContext();

        // GET: ClientePedido
        public ActionResult Index()
        {
            return View(db.ClientePedidoes.ToList());
        }

        // GET: ClientePedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            if (clientePedido == null)
            {
                return HttpNotFound();
            }
            return View(clientePedido);
        }

        // GET: ClientePedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientePedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,numeroMesa,ValorTotal")] ClientePedido clientePedido)
        {
            if (ModelState.IsValid)
            {
                db.ClientePedidoes.Add(clientePedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientePedido);
        }

        // GET: ClientePedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            if (clientePedido == null)
            {
                return HttpNotFound();
            }
            return View(clientePedido);
        }

        // POST: ClientePedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,numeroMesa,ValorTotal")] ClientePedido clientePedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientePedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientePedido);
        }

        // GET: ClientePedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            if (clientePedido == null)
            {
                return HttpNotFound();
            }
            return View(clientePedido);
        }

        // POST: ClientePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            db.ClientePedidoes.Remove(clientePedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
