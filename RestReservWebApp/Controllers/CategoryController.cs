using BusinessLogicLayer.Models;
using DataAccessLayer.Date;
using Microsoft.AspNetCore.Mvc;
using System;


namespace TestWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RestReservDbContext _db;
        public CategoryController(RestReservDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {

            return View();
        }
        //Post
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly manch the Name."); //CustomError - использовать для обозначения оштибки сверху
            }
            if (ModelState.IsValid)
            {

                _db.categories.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.ID==id);
            //var categoryFromDb2 = _db.Categories.SingleOrDefault(u => u.ID == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly manch the Name."); //CustomError - использовать для обозначения оштибки сверху
            }
            if (ModelState.IsValid)
            {

                _db.categories.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
