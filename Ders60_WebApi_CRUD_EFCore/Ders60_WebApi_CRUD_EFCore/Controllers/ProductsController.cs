using Ders60_WebApi_CRUD_EFCore.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ders60_WebApi_CRUD_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> urunler = new List<Product>
        {
            new Product
            {
                ID = 1,
                UrunAdi = "urun1",
                Fiyat = 1000,
                Stok = 35
            },
            new Product
            {
                ID = 2,
                UrunAdi = "urun2",
                Fiyat = 2000,
                Stok = 25
            }
        };

        private readonly DataContext context;

        public ProductsController(DataContext context)
        {
            this.context = context;
        }

        //GET LİSTELEME
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {

            return Ok(await context.tbl_urunler.ToListAsync());
        }

        //GET DETAY
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> Get(int id)
        { /*
            var urun = urunler.Find(p => p.ID == id);
                if (urun == null)
                {
                 return BadRequest("Ürün bulunamadı");
                }
            return Ok(urun);*/
            var urun = await context.tbl_urunler.FindAsync(id);
            if (urun == null)
            {
                return BadRequest("Ürün bulunamadı");
            }
            return Ok(urun);
        }

        //EKLEME - POST
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product pr)
        {
            //urunler.Add(pr);
            //return Ok(urunler);

            context.tbl_urunler.Add(pr);
            await context.SaveChangesAsync();
            return Ok(await context.tbl_urunler.ToListAsync());
        }

        //PUT GÜNCELLEME    
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product pr)
        { /*
            var urun = urunler.Find(p => p.ID == p.ID);
            if (urun==null)
            {
                return BadRequest("ürün bulunamadı");
            }
            urun.UrunAdi = pr.UrunAdi;
            urun.Fiyat = pr.Fiyat;
            urun.Stok = pr.Stok;

            return Ok(urunler);*/

            var urun = await context.tbl_urunler.FindAsync(pr.ID);
            if (urun == null)
            {
                return BadRequest("ürün bulunamadı");
            }
            urun.UrunAdi = pr.UrunAdi;
            urun.Fiyat = pr.Fiyat;
            urun.Stok = pr.Stok;

            await context.SaveChangesAsync();
            return Ok(await context.tbl_urunler.ToListAsync());

        }

        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            /*
            var urun = urunler.Find(p => p.ID == id);
            if (urun == null)
            {
                return BadRequest("ürün bulunamadı");
            }
            urunler.Remove(urun);
            return Ok(urunler); */

            var urun = await context.tbl_urunler.FindAsync(id);
            if (urun == null)
            {
                return BadRequest("ürün bulunamadı");
            }
            context.tbl_urunler.Remove(urun);
            await context.SaveChangesAsync();
            return Ok(await context.tbl_urunler.ToListAsync());

        }


    }
}
