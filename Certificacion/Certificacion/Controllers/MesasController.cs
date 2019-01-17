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
using Certificacion.Models;

namespace Certificacion.Controllers
{
    public class MesasController : ApiController
    {
        private Model1 db = new Model1();

        //metodo que retorna todos los datos
        // GET: api/Mesas
        public IQueryable<Mesas> GetMesas()
        {
            //retornando todos los datos de la base
            return db.Mesas;
        }

        //metodo para retornar un dato dependiendo del id
        // GET: api/Mesas/5
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult GetMesas(int id)
        {
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return NotFound();
            }

            return Ok(mesas);
        }

        //metodo para actualizar datos
        // PUT: api/Mesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMesas(int id, Mesas mesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mesas.idMesa)
            {
                return BadRequest();
            }

            db.Entry(mesas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesasExists(id))
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

        //metoto para guardar datos
        // POST: api/Mesas
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult PostMesas(Mesas mesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mesas.Add(mesas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mesas.idMesa }, mesas);
        }

        //metodo para eliminar datos
        // DELETE: api/Mesas/5
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult DeleteMesas(int id)
        {
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return NotFound();
            }

            db.Mesas.Remove(mesas);
            db.SaveChanges();

            return Ok(mesas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MesasExists(int id)
        {
            return db.Mesas.Count(e => e.idMesa == id) > 0;
        }
    }
}