using DataAccessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;
using BusinessLogicLayer.Models.ViewModels;
using BusinessLogicLayer.Models;

namespace RestReservWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RestaurantController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

    

        //GET
        public IActionResult Upsert(int? id)
        {
            RestaurantVM restaurantVM = new()
            {
                Restaurant = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {

                return View(restaurantVM);
            }
            else
            {
                restaurantVM.Restaurant = _unitOfWork.Restaurant.GetFirstOrDefault(u => u.Id == id);
              
                return View(restaurantVM);
            }
        }

        //POST
        [HttpPost]
        
        public IActionResult Upsert(RestaurantVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\restaurants");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Restaurant.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Restaurant.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Restaurant.ImageUrl = @"\images\restaurants\" + fileName + extension;

                }
                if (obj.Restaurant.Id == 0)
               {
                    _unitOfWork.Restaurant.Add(obj.Restaurant);
                }
                else
               {
                    _unitOfWork.Restaurant.Update(obj.Restaurant);
               }
                _unitOfWork.Save();
                TempData["success"] = "Restaurant created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }























        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var restaurantList = _unitOfWork.Restaurant.GetAll(includeProperties: "Category");
            return Json(new { data = restaurantList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Restaurant.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Restaurant.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
