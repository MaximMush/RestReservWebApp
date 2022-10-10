using DataAccessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace RestReservWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
