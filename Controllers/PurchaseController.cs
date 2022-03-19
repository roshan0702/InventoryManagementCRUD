using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        InventoryManagementEntities db = new InventoryManagementEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> PurchaseList = db.Purchases.OrderByDescending(x => x.PurchaseId).ToList();
            return View(PurchaseList);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> ProductList = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(ProductList);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase PurchaseName)
        {
            db.Purchases.Add(PurchaseName);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult UpdatePurchase(int id)
        {
            Purchase PurchaseUpdate = db.Purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            List<string> ProductList = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(ProductList);
            return View(PurchaseUpdate);
        }

        [HttpPost]
        public ActionResult UpdatePurchase(int id, Purchase PurchaseUpdate)
        {
            Purchase PurchaseUpdated = db.Purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            PurchaseUpdated.PurchaseProduct = PurchaseUpdate.PurchaseProduct;
            PurchaseUpdated.PurchaseQuantity = PurchaseUpdate.PurchaseQuantity;
            PurchaseUpdated.PurchaseDate = PurchaseUpdate.PurchaseDate;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult DetailPurchase(int id)
        {
            Purchase PurchaseDetail = db.Purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            return View(PurchaseDetail);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase PurchaseDelete = db.Purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            return View(PurchaseDelete);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase PurchaseDelete)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.PurchaseId == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }
}