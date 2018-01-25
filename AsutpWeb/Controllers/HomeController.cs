using System.Web.Mvc;
using AsutpWeb.Models;

namespace AsutpWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          return View();
        }

    }
}