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
    public class ClientePedidoApiController : ApiController
    {
        private RestWebSolutContext db = new RestWebSolutContext();

        // GET: api/ClientePedidoApi
        public IQueryable<ClientePedido> GetClientePedidoes()
        {
            return db.ClientePedidoes;
        }

        // GET: api/ClientePedidoApi/5
        [ResponseType(typeof(ClientePedido))]
        public IHttpActionResult GetClientePedido(int id)
        {
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            if (clientePedido == null)
            {
                return NotFound();
            }

            return Ok(clientePedido);
        }

        // PUT: api/ClientePedidoApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientePedido(int id, ClientePedido clientePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePedido.Id)
            {
                return BadRequest();
            }

            db.Entry(clientePedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientePedidoExists(id))
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

        // POST: api/ClientePedidoApi
        [ResponseType(typeof(ClientePedido))]
        public IHttpActionResult PostClientePedido(ClientePedido clientePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientePedidoes.Add(clientePedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientePedido.Id }, clientePedido);
        }

        // DELETE: api/ClientePedidoApi/5
        [ResponseType(typeof(ClientePedido))]
        public IHttpActionResult DeleteClientePedido(int id)
        {
            ClientePedido clientePedido = db.ClientePedidoes.Find(id);
            if (clientePedido == null)
            {
                return NotFound();
            }

            db.ClientePedidoes.Remove(clientePedido);
            db.SaveChanges();

            return Ok(clientePedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientePedidoExists(int id)
        {
            return db.ClientePedidoes.Count(e => e.Id == id) > 0;
        }
    }
}