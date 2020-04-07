using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class CharacterRoster
    {
        public Character Add ( Character character )
        {
            if (character == null)
                return null;

            return null;
        }

        public void Delete ( int id )
        {
            
        }

        //public Character Get ( int id );

        //public IEnumerable<Character> GetAll ();

        //public string Update ( int id, Character character );

        //public Character FindById ( int id )
        //{
        //    foreach
        //}

        private readonly List<Character> _characters = new List<Character>();
        private int __id = 0;
    }
}
