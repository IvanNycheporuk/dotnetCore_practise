using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Models
{
    public interface ICharactersRepository
    {
        IEnumerable<Character> GetCharacters(string name, int? age);

        Character GetCharacterById(int id);

        void Add(Character character);

        IEnumerable<Character> GetAll();
    }
}
