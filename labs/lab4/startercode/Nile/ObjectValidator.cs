/*
 * ITSE 1430
 * William Sarawichitr
 * 4-29-20
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }

        public static void Validate ( object value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);
        }

    }
}
