using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Character> Character { get; set; }
    }
}
