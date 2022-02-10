using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QazaqmysTestTask.Controllers.HomePage;
using QazaqmysTestTask.Models;
using QazaqmysTestTask.Models.List;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QazaqmysTestTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(HomeModel.Initialize(HttpContext));
        }

        [HttpPost]
        public IActionResult Index(NumbersListModel model)
        {
            if (ModelState.IsValid)
            {
                return View(HomeModel.Initialize(HttpContext, model));
            }


            return View(HomeModel.Initialize(HttpContext));
        }

        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Delete(long ID)
        {
            DeleteNumber.Execute(ID);
            return RedirectToAction("Index");
        }
    }
}
