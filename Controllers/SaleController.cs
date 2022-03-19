using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class SaleController : Controller
    {
        InventoryManagementEntities db = new InventoryManagementEntities();

        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> SaleList = db.Sales.OrderByDescending(x => x.SaleId).ToList();
            return View(SaleList);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> ProductList = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(ProductList);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale SaleProduct)
        {
            db.Sales.Add(SaleProduct);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            Sale SaleUpdate = db.Sales.Where(x => x.SaleId == id).SingleOrDefault();
            List<string> ProductList = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(ProductList);
            return View(SaleUpdate);
        }

        [HttpPost]
        public ActionResult UpdateSale(int id, Sale SaleUpdate)
        {
            Sale SaleUpdated = db.Sales.Where(x => x.SaleId == id).SingleOrDefault();
            SaleUpdated.SaleName = SaleUpdate.SaleName;
            SaleUpdated.SaleQuantity = SaleUpdate.SaleQuantity;
            SaleUpdated.SaleDate = SaleUpdate.SaleDate;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult DetailSale(int id)
        {
            Sale SaleDetail = db.Sales.Where(x => x.SaleId == id).SingleOrDefault();
            return View(SaleDetail);
        }

        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            Sale SaleDelete = db.Sales.Where(x => x.SaleId == id).SingleOrDefault();
            return View(SaleDelete);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale SaleDelete)
        {
            db.Sales.Remove(db.Sales.Where(x => x.SaleId == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}
