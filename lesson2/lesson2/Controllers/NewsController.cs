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
        private NewsDbContext _dbContext;

        public NewsController(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["News"] = _dbContext.News.ToList();

            return View();
        }

        [HttpGet("news/{id}")]
        public IActionResult Index(int id)
        {
            ViewData["Item"] = _dbContext.News.SingleOrDefault(x => x.Id == id);

            return View();
        }
    }
}
