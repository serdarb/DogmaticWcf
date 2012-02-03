using System.Web.Mvc;
using DogmaticWcf.Server.Contracts;

namespace DogmaticWcf.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyService _service;
        public HomeController(IMyService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my dogmatic wcf implemantation with castle windsor and ASP.NET MVC!";

            ViewBag.MyProperty = _service.DoSomething(new MyDto { MyProperty = "Testing" });

            return View();
        }
    }
}
