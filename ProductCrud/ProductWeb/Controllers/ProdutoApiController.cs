using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProductWeb.Models;

namespace ProductWeb.Controllers
{
    public class ProdutoApiController : ApiController
    {
        private Context db = new Context();

        // GET: api/Produto
        public IQueryable<ProdutoModel> GetProduto()
        {
            return db.ProdutoModels;
        }

        // GET: api/ListProdutos
        [Route("api/ListProdutos")]
        public IEnumerable<ProdutoModel> GetProdutos()
        {
            return from p in db.ProdutoModels.ToList()
                    select p;
        }

        // GET: api/Produto/5
        [ResponseType(typeof(ProdutoModel))]
        public async Task<IHttpActionResult> GetProduto(long id)
        {
            ProdutoModel produtoModel = await db.ProdutoModels.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return Ok(produtoModel);
        }

        // PUT: api/Produto/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduto(long id, ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtoModel.Id)
            {
                return BadRequest();
            }

            db.Entry(produtoModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoModelExists(id))
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

        // POST: api/Produto
        [ResponseType(typeof(ProdutoModel))]
        public async Task<IHttpActionResult> PostProduto(ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProdutoModels.Add(produtoModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = produtoModel.Id }, produtoModel);
        }

        // DELETE: api/Produto/5
        [ResponseType(typeof(ProdutoModel))]
        public async Task<IHttpActionResult> DeleteProduto(long id)
        {
            ProdutoModel produtoModel = await db.ProdutoModels.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            db.ProdutoModels.Remove(produtoModel);
            await db.SaveChangesAsync();

            return Ok(produtoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoModelExists(long id)
        {
            return db.ProdutoModels.Count(e => e.Id == id) > 0;
        }
    }
}