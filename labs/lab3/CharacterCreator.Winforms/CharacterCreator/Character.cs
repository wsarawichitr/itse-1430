//William Sarawichitr
//ITSE-1430
//4-6-20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public int Id { get; set; }

        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        private string _name;

        public Profession Profession { get; set; }

        public Race Race { get; set; }

        public int[] Attributes { get; set; } = { 50, 50, 50, 50, 50 };
        
        public string Description { get; set; }

        public override string ToString ()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });
            }
        }
    }
}
