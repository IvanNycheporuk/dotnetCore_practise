using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public class SqlCharactersRepository : ICharactersRepositry
    {
        private readonly FictionDbContext _dbContext;

        public SqlCharactersRepository(FictionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _dbContext.Characters;
        }
    }
}
