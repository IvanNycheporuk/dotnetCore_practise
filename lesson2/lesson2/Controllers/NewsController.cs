using lesson2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson2.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["News"] = NewsBase.GetNews();
            return View();
        }
    }
}
