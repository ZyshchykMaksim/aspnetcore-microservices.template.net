using System;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Common.Web.DataAnnotations
{
    /// <summary>
    /// The class provides to validate if string in base-64 format.
    /// </summary>
    public class Base64StringAttribute : ValidationAttribute
    {
        /// <summary>
        /// Returns true if string provided in base-64 format.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, false.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueString = value.ToString();

            if (string.IsNullOrEmpty(valueString))
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(valueString);
                
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
