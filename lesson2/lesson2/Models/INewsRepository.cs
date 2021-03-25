using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson2.Models
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews();
    }
}
