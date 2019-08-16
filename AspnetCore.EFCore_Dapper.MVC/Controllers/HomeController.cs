using AspnetCore.EFCore_Dapper.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            View();

        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
