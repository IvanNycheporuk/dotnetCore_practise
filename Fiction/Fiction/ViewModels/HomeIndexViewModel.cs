using Fiction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Story> Stories { get; set; }
    }
}
