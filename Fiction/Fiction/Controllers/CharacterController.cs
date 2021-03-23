using Fiction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class CharacterController : Controller
    {
        private FictionDbContext _dbContext;

        public CharacterController(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Characters"] = _dbContext.Characters.ToList();
            return View();
        }
    }
}
