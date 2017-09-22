using AspnetCore.EFCore_Dapper.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
