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
        public IActionResult Index([FromHeader]bool isFake)
        {

            var test = _newsRepository.GetNews(isFake).ToList();

            ViewData["News"] = test;

            return View();
        }

        [HttpDelete]
        public void UpdateAllNews([FromBody]List<News> news)
        {
            _newsRepository.UpdateAllNews(news);
        }

        [HttpPost]
        public void AddNews([FromBody]News news)
        {
            _newsRepository.AddNews(news);
        }
        [Route("news/{id}")]
        [HttpGet]
        public IActionResult Single(int id, [FromHeader] bool isFake)
        {
            ViewData["Item"] = _newsRepository.GetNews(isFake).FirstOrDefault(x => x.Id == id);

            return View();
        }

        [Route("news/{id}")]
        [HttpPut]
        public void UpdateSingleNews(int id, [FromBody] News news)
        {

            var singleNews = new News()
            {
                Id = id,
                AuthorName = news.AuthorName,
                IsFake = news.IsFake,
                Text = news.Text,
                Title = news.Title
            };

            _newsRepository.UpdateSingleNews(singleNews);
        }

    }
}
