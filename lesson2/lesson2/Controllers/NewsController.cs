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
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {

            ViewData["News"] = _newsRepository.GetNews();

            return View();
        }

        [Route("news/{id}")]
        public IActionResult Index(int id)
        {
            ViewData["Item"] = _newsRepository.GetNews().FirstOrDefault(x => x.Id == id);

            return View();
        }
    }
}
