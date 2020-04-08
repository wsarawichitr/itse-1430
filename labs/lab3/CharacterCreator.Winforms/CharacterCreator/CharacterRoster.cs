using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            character.Id = _id++;
            _characters.Add(character);

            return character;
        }

        public void Delete ( int id )
        {
            var character = FindById(id);
            _characters.Remove(character);
        }

        public Character Get ( int id )
        {
            return _characters[id];
        }

        public IEnumerable<Character> GetAll ()
        {
            return _characters;
        }

        public string Update ( int id, Character character )
        {
            return null;
        }

        private Character FindById ( int id )
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character;
            };

            return null;
        }

        private readonly List<Character> _characters = new List<Character>();
        private int _id = -1;
    }
}
