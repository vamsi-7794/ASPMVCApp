using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPMVCApp.Data;
using ASPMVCApp.Models;

namespace ASPMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbCon _db;
        public CategoryController(DbCon db)
        {
            _db = db;
            

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id != null && Id != 0)
            {
                var obj = _db.Category.Find(Id);
                if (obj != null)
                {
                    return View(obj);
                }
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
            
        }
        public IActionResult Delete(int? Id)
        {
            if (Id != null && Id != 0)
            {
                var obj = _db.Category.Find(Id);
                if (obj != null)
                {
                    return View(obj);
                }
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Category.Find(Id);
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            

            
        }
    }
}
