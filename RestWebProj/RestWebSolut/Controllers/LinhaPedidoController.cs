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
    public class LinhaPedidoController : Controller
    {
        private RestWebSolutContext db = new RestWebSolutContext();

        // GET: LinhaPedido
        public ActionResult Index()
        {
            return View(db.LinhaPedido.ToList());
        }

        // GET: LinhaPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            if (linhaPedido == null)
            {
                return HttpNotFound();
            }
            return View(linhaPedido);
        }

        // GET: LinhaPedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinhaPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProduto,quantidade,NumeroPedido")] LinhaPedido linhaPedido)
        {
            if (ModelState.IsValid)
            {
                db.LinhaPedido.Add(linhaPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(linhaPedido);
        }

        // GET: LinhaPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            if (linhaPedido == null)
            {
                return HttpNotFound();
            }
            return View(linhaPedido);
        }

        // POST: LinhaPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProduto,quantidade,NumeroPedido")] LinhaPedido linhaPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhaPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(linhaPedido);
        }

        // GET: LinhaPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            if (linhaPedido == null)
            {
                return HttpNotFound();
            }
            return View(linhaPedido);
        }

        // POST: LinhaPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            db.LinhaPedido.Remove(linhaPedido);
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
