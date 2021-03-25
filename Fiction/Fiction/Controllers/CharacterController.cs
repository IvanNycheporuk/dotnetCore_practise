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
        private readonly ICharactersRepositry _charactersRepositry;

        public CharacterController(ICharactersRepositry charactersRepositry)
        {
            _charactersRepositry = charactersRepositry;
        }

        [Route("/character")]
        public IActionResult Index([FromQuery]string name, [FromQuery]int? age)
        {

            var characters = _charactersRepositry.GetCharacters(name, age);

            ViewData["Characters"] = characters.ToList();            
            
            return View();
        }

        [Route("character/{id}")]
        public IActionResult SingleCharacter(int id)
        {
            var character = _charactersRepositry.GetCharacterById(id);

            ViewData["Character"] = character;

            return View();
        }
    }
}
