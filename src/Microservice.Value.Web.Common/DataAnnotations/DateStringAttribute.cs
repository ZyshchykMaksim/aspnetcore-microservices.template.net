using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to check that the string contains date in valid format.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateStringAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <returns>
        /// True if the specified value is valid; otherwise, false.
        /// </returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var format = new[] { Format };

            return DateTime.TryParseExact(
                value.ToString(),
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}
