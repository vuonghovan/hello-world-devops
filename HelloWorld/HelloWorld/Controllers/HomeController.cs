using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new CreateViewModel
            {
                Name = "Azure DevOps!"
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public ActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Name.Length > 15)
            {
                ModelState.AddModelError(nameof(model.Name), "Max length is 15");
                return View(model);
            }

            return RedirectToAction(nameof(Edit), new { model.Name });
        }

        [HttpGet("Edit")]
        public ActionResult Edit(string Name)
        {
            var model = new CreateViewModel
            {
                Name = Name
            };

            return View(model);
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
