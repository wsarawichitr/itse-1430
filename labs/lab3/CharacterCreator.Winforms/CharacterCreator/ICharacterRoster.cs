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
    public interface ICharacterRoster
    {
        /// <summary>Adds a new character.</summary>
        /// <param name="character">The character to add.</param>
        /// <returns>The new character.</returns>
        /// Error: Character is invalid
        /// Error: Character with the same name already exists
        Character Add ( Character character );

        /// <summary>Deletes a character.</summary>
        /// <param name="id">The character to remove.</param>
        /// Error: Id is less than zero.
        void Delete ( int id );

        /// <summary>Gets an existing character.</summary>
        /// <param name="id">The character to get.</param>
        /// <returns>The character, if any.</returns>
        /// Error: Id is less than zero.
        Character Get ( int id );

        /// <summary>Gets all characters.</summary>
        /// <returns>The list of characters.</returns>
        IEnumerable<Character> GetAll ();

        /// <summary>Updates an existing character.</summary>
        /// <param name="id">The character to update.</param>
        /// <param name="character">The character details.</param>
        /// Error: Updated character is invalid.
        /// Error: Existing character cannot be found.
        /// Error: Existing character with the same name already exists
        string Update ( int id, Character character );
    }
}
