using System.Diagnostics;
using AppTask.Data;
using AppTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDataDbContext applicationDataDbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDataDbContext applicationDataDbContext)
        {
            _logger = logger;
            this.applicationDataDbContext = applicationDataDbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            var task = this.applicationDataDbContext.
                Tasks.Include(x => x.UserCreated).
                Include(x => x.Status);

            return View(task);
        }

        [Authorize]
        [HttpGet]
        public IActionResult NewTask()
        {
            return RedirectToAction("Task");
        }


        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
