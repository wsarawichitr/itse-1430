//William Sarawichitr
//ITSE-1430
//2-26-20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Name
        {
            get {
                return _name ?? "";
            }
            set {
                _name = value;
            }
        }
        private string _name;

        public Profession Profession { get; set; }

        public Race Race { get; set; }

        public int[] Attributes { get; set; } = { 50, 50, 50, 50, 50 };
        //{
        //    get { return _attributes; }
        //    set { _attributes = value; }
        //}
        //private int[] _attributes = { 50, 50, 50, 50, 50 };

        public string Description { get; set; }


    }
}
