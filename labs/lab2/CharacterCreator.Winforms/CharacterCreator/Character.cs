using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Name { get; set; }

        public Profession Profession { get; set; }

        public Race Race { get; set; }

        public int[] Attribute { get; set; } = { 50, 50, 50, 50, 50 };

        public string Description { get; set; }

    }
}
