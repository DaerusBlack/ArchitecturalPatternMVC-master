using BLL.DesignPatterns.GenericRepositoryPattern.IntRep;
using ENTITIES.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArchitecturalPatternMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGenericRepository<User> _genericRepository;

        public AuthController(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public IActionResult Login(string yonlen)
        {
            ViewBag.yonlen = yonlen;
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userDto, string yonlen)
        {
            if (ModelState.IsValid)
            {
                User response = _genericRepository.GetDefault(x => x.Username == userDto.Username && x.Password == userDto.Password);

                if (response == null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!!");
                    return View();
                }

                HttpContext.Session.SetString("userId", response.Id.ToString());
                HttpContext.Session.SetString("username", response.Username);

                if (string.IsNullOrEmpty(yonlen))
                {
                    return RedirectToAction("List", "Article");
                }
                return Redirect(yonlen); //Url yönelendirmelerinde kullanılan!!! IActionResult dönüşlerinden biridir.
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User userDto)
        {
            if (ModelState.IsValid)
            {
                User userCheck = _genericRepository.Where(x => x.Username == userDto.Username).FirstOrDefault();

                if (userCheck != null) return View();

                _genericRepository.Add(userDto);
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("username"); //Spesifik olarak session temizlemek isterseniz remove fonk. kullanabilirsiniz.
            HttpContext.Session.Clear();//Bütün sessionları temizleyebilirsiniz.

            return RedirectToAction("Login", "Auth");
        }
    }
}
