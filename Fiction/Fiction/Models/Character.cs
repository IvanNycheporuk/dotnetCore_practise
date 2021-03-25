﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        
        //[]
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }
}
