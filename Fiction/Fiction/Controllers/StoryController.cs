using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryRepository _storyRepository;

        public StoryController(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public IActionResult Index(int id)
        {
            var story = _storyRepository.GetAll().Single(x => x.Id == id);

            return View(story);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Story story)
        {
            if (ModelState.IsValid)
            {
                _storyRepository.Add(story);
                return RedirectToAction("Index", "Story");
            }

            return View();
        }
    }
}
