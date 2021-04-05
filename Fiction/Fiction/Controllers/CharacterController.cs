using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{    
    public class CharacterController : Controller
    {        
        private readonly ICharactersRepository _charactersRepository;

        public CharacterController(ICharactersRepository charactersRepositry)
        {
            _charactersRepository = charactersRepositry;
        }

        public IActionResult Index([FromQuery]string name, [FromQuery]int? age)
        {

            var characters = _charactersRepository.GetCharacters(name, age);

            ViewData["Characters"] = characters.ToList();            
            
            return View();
        }

        public IActionResult SingleCharacter(int id)
        {
            var character = _charactersRepository.GetAll().Single(x => x.Id == id);

            return View(character);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Character character)
        {
            if (ModelState.IsValid)
            {
                _charactersRepository.Add(character);
                return RedirectToAction("Index", "Character");
            }

            return View();
        }
    }
}
