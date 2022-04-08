using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons;

namespace MVCDemo.Controllers
{
    public class ClassController : Controller
    {
        private readonly ILogger<ClassController> _logger;
        private static readonly string _adminPolicy = Constants.AdministratorPolicy;

        public ClassController(ILogger<ClassController> logger)
        {
            _logger = logger;
        }


        [Authorize(Roles = "Admin, User")] //or
        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "User")] //and
        public IActionResult Index(ClassViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "Administrator")]
        public IActionResult Register(ClassViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", model);
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
