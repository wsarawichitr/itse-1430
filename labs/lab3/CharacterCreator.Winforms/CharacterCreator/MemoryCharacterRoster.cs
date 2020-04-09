//William Sarawichitr
//ITSE-1430
//4-6-20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class MemoryCharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            character.Id = ++_id;
            foreach(var item in _characters)
            {
                if (item.Name == character.Name)
                    return null;
            }

            _characters.Add(character);

            return character;
        }

        public void Delete ( int id )
        {
            if (id<=0)
                return;

            var character = Get(id);

            _characters.Remove(character);
        }

        public Character Get ( int id )
        {
            if (id <= 0)
                return null;

            foreach (var character in _characters)
            {
                if (character.Id == id)
                    return character;
            }
            return null;
        }

        public IEnumerable<Character> GetAll ()
        {
            foreach (var character in _characters)
                yield return CopyCharacter(character);
        }

        private Character CopyCharacter ( Character source )
        {
            var copy = new Character();
            copy.Id = source.Id;
            copy.Name = source.Name;
            copy.Profession = source.Profession;
            copy.Race = source.Race;
            copy.Attributes = source.Attributes;
            copy.Description = source.Description;

            return copy;
        }

        public string Update ( int id, Character character )
        {
            if (character == null)
                return "Character is null";
            
            var existing = Get(id);
            if (existing == null)
                return "Character not found";
            
            var sameName = FindByName(character.Name);
            if (sameName != null && sameName.Id != id)
                return "Name must be unique";
            
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
