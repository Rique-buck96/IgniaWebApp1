using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RxWebApp.Data;
using RxWebApp.Extensions;
using RxWebApp.Models;
using RxWebApp.Services;
using RxWebApp.ViewModels;

namespace RxWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Orders()
        {
            ViewBag.Message = "Your orders.";
            return new RedirectResult("Orders");
        }
    }
}