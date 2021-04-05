using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public interface IStoryRepository
    {
        IEnumerable<Story> GetAll();

        void Add(Story story);
    }
}
