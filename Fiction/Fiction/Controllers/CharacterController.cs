using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    [Route("example")]
    public class CharacterController : Controller
    {
        //private FictionDbContext _dbContext;
        private readonly ICharactersRepositry _charactersRepositry;

        public CharacterController(ICharactersRepositry charactersRepositry)
        {
            _charactersRepositry = charactersRepositry;
        }

        [Route("c/index")]
        [Route("char/index")]
        public IActionResult Index()
        {
            var characters = _charactersRepositry.GetCharacters();
            
            ViewData["Story"] = characters.ToList();

            // _dbContext.Characters.ToList();
            return View();
        }
    }
}
