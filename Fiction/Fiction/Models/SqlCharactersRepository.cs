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

        public Character GetCharacterById(int id)
        {
            return _dbContext.Characters.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Character> GetCharacters(string name, int? age)
        {
            if (name != null && age != null)
            {
                return _dbContext.Characters.Where(x => x.Name == name || x.Age == age);
            }

            if (name != null)
            {
                return _dbContext.Characters.Where(x => x.Name == name);
            }

            if (age != null)
            {
                return _dbContext.Characters.Where(x => x.Age == age);
            }


            return _dbContext.Characters;
        }
    }
}
