using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GNG_v0._2.Models;

namespace GNG_v0._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository _userRepository;

 
        public HomeController(ILogger<HomeController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var q = _userRepository.GetAllUsers();
            return View(q);
        }


        public IActionResult Detail()
        {
            return View("Detail", "_Layout");
        }

        public IActionResult LevelupDetail()
        {
            return View("LevelupDetail", "_Layout");
        }

        public IActionResult Preorder()
        {
            return View("Preorder", "_Layout");
        }

        public IActionResult lvlupcatalog()
        {
            return View("lvlupcatalog", "_Layout");
        }


        public IActionResult Forgot()
        {
            return View("Forgot", "_Layout");
        }

        public IActionResult Privacy()
        {
            return View("Privacy", "_Layout");
        }


       

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
