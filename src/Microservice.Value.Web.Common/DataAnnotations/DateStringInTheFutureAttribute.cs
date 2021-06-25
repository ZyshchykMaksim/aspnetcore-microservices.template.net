using System;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to check that provided date string is in the future.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateStringInTheFutureAttribute : ValidationAttribute
    {
        /// <summary>
        /// Time in minutes which will be added to current date during determining of future time.
        /// By default it is equal to 0
        /// </summary>
        public int RelativeTimeInMinutes { get; set; }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <returns>
        /// True if the specified value is valid; otherwise, false.
        /// </returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            if (value == null || !DateTime.TryParse(value.ToString(), out DateTime date))
            {
                return true;
            }

            return date > DateTime.UtcNow.AddMinutes(RelativeTimeInMinutes);
        }
    }
}
