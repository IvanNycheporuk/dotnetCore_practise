using Fiction.Models;
using Fiction.Services;
using Fiction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IStoryRepository _storyRepository;

        public HomeController(ICharactersRepository charactersRepository,
            IStoryRepository storyRepository)
        {
            _charactersRepository = charactersRepository;
            _storyRepository = storyRepository;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                Characters = _charactersRepository.GetAll(),
                Stories = _storyRepository.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SendMessage([FromServices] IMessageSender messageSender)
        {
            messageSender.SendMessage();
        }
    }
}
