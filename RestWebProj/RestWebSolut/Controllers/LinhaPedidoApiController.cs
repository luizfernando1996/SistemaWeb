using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestWebSolut.Models;

namespace RestWebSolut.Controllers
{
    public class LinhaPedidoApiController : ApiController
    {
        private RestWebSolutContext db = new RestWebSolutContext();

        // GET: api/LinhaPedidoApi
        public IQueryable<LinhaPedido> GetLinhaPedidoes()
        {
            return db.LinhaPedido;
        }

        // GET: api/LinhaPedidoApi/5
        [ResponseType(typeof(LinhaPedido))]
        public IHttpActionResult GetLinhaPedido(int id)
        {
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            if (linhaPedido == null)
            {
                return NotFound();
            }

            return Ok(linhaPedido);
        }

        // PUT: api/LinhaPedidoApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinhaPedido(int id, LinhaPedido linhaPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linhaPedido.Id)
            {
                return BadRequest();
            }

            db.Entry(linhaPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinhaPedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LinhaPedidoApi
        [ResponseType(typeof(LinhaPedido))]
        public IHttpActionResult PostLinhaPedido(LinhaPedido linhaPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LinhaPedido.Add(linhaPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linhaPedido.Id }, linhaPedido);
        }

        // DELETE: api/LinhaPedidoApi/5
        [ResponseType(typeof(LinhaPedido))]
        public IHttpActionResult DeleteLinhaPedido(int id)
        {
            LinhaPedido linhaPedido = db.LinhaPedido.Find(id);
            if (linhaPedido == null)
            {
                return NotFound();
            }

            db.LinhaPedido.Remove(linhaPedido);
            db.SaveChanges();

            return Ok(linhaPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinhaPedidoExists(int id)
        {
            return db.LinhaPedido.Count(e => e.Id == id) > 0;
        }
    }
}