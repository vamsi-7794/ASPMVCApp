using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPMVCApp.Data;
using ASPMVCApp.Models;

namespace ASPMVCApp.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly DbCon _db;
        public ApplicationTypeController(DbCon db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
