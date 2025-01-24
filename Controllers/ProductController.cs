using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Data;
using ProductCRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;

        public ProductController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Name", "Description", "Quantity", "Price")]Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Created Successfully";
                TempData["NotificationType"] = "Success";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                return View(product);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Deleted Successfully";
                TempData["NotificationType"] = "Success";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                TempData["Notification"] = "Product Updated Successfully";
                TempData["NotificationType"] = "Success";

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}

