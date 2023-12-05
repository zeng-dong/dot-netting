using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kafka_aspnet_frontend.Models;
// add dependencies

namespace kafka_aspnet_frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // TODO: appsettings/dependency injection

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationModel model)
        {
            // TODO: client config - hard-coded

            // TODO: client config with appsettings/dependency injection

            // TODO: Register logic            

            ViewBag.Message = "User registration request is sent to the server.";
            return View(model);
        }

        // TODO: GetKafkaConfig method

        // TODO: deliveryHandler method

        // TODO: Produce method

		public ActionResult Admin()
		{
		  return View();
		}

		public ActionResult DeleteTopic()
		{

		  return View("Admin");
		}
		public ActionResult CreateTopic()
		{

		  return View("Admin");
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
