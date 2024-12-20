using itLibrary2.Data;
using itLibrary2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace itLibrary2.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(ApplicationDbContext db )
        {
                _db = db;
        }
        private readonly ApplicationDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _db.Category;
            return View(objlist);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
