using System;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to check that provided date string is in the past.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateStringInThePastAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <returns>
        /// True if the specified value is valid; otherwise, false.
        /// </returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            DateTime date;

            if (value == null || !DateTime.TryParse(value.ToString(), out date))
            {
                return true;
            }

            return date <= DateTime.UtcNow;
        }
    }
}
