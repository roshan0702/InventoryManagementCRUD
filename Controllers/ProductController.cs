using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        InventoryManagementEntities db = new InventoryManagementEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> ProductList = db.Products.OrderByDescending(x => x.ProductId).ToList();
            return View(ProductList);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DetailProduct(int id)
        {
            Product ProductDetail = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(ProductDetail);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product ProductUpdate = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(ProductUpdate);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product ProductUpdate)
        {
            Product ProductUpdated = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            ProductUpdated.ProductName = ProductUpdate.ProductName;
            ProductUpdated.ProductQuantity = ProductUpdate.ProductQuantity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product ProductDelete = db.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(ProductDelete);
        }
        
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product ProductDelete)
        {
            db.Products.Remove(db.Products.Where(x => x.ProductId == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}