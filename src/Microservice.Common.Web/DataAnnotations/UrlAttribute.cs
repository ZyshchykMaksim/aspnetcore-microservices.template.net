using System;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Common.Web.DataAnnotations
{
    /// <summary>
    /// The class provides to check that the object is url.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class UrlAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets the value indicating whether or not the specified <paramref name="value"/> is valid
        /// with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate</param>
        /// <returns><c>true</c> if the <paramref name="value"/> is acceptable, <c>false</c> if it is not acceptable</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return Uri.TryCreate(value.ToString(), UriKind.Absolute, out var uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
