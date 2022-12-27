using ArchitecturalPatternMVC.Filters;
using ArchitecturalPatternMVC.Models;
using BLL.DesignPatterns.GenericRepositoryPattern.IntRep;
using ENTITIES.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitecturalPatternMVC.Controllers
{
    [LoggedUser]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<User> _genericRepository;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }        
        public IActionResult Index()
        {
            var list = _genericRepository.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
