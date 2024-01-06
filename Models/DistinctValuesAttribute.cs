using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Project2.Models
{
    public class DistinctValuesAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IEnumerable<string> values)
            {
                // Check if the values are distinct
                return values.Distinct().Count() == values.Count();
            }

            // If the value is not a collection, consider it as valid
            return true;
        }
    }
}
