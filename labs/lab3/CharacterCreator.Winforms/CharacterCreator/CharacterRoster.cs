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
            var character = Get(id);

            _characters.Remove(character);
        }

        public Character Get ( int id )
        {
            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character;
            }
            return null;
        }

        public IEnumerable<Character> GetAll ()
        {
            return _characters;
        }

        public string Update ( int id, Character character )
        {
            if (character == null)
                return "Movie is null";

            if (id < 0)
                return "Id is invalid";

            var existing = Get(id);
            if (existing == null)
                return "Movie not found";

            // Movie names must be unique
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Name must be unique";

            existing.Id = character.Id;
            existing.Name = character.Name;
            existing.Profession = character.Profession;
            existing.Race = character.Race;
            existing.Attributes = character.Attributes;
            existing.Description = character.Description;

            return null;
        }

        private Character FindByName ( string name )
        {
            foreach (var character in _characters)
            {
                if (String.Compare(character?.Name, name, true) == 0)
                    return character;
            };

            return null;
        }


        private readonly List<Character> _characters = new List<Character>();
        private int _id = 0;
    }
}
