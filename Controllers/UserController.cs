using CodingPie.Models;
using CodingPie.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingPie.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _service.Login(model.Email, model.PassWord);
            if(user is null)
            {
                return View();
            }
            HttpContext.Session.SetString("name" , user.Name);
            HttpContext.Session.SetString("email" , user.Email);
                                   
            return RedirectToAction("Pies","Pie");
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}