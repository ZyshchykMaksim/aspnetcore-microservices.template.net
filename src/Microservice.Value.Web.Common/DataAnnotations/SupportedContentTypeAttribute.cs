using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to support of content type.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class SupportedContentTypeAttribute : ValidationAttribute
    {
        private const string DEFAULT_ERROR_MESSAGE = "{0} must contain valid values.";

        private readonly string[] _contentTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupportedContentTypeAttribute"/> class.
        /// </summary>
        /// <param name="contentTypes">The content types.</param>
        /// <exception cref="System.ArgumentException">contentTypes</exception>
        public SupportedContentTypeAttribute(params string[] contentTypes) : base(DEFAULT_ERROR_MESSAGE)
        {
            if (contentTypes == null || !contentTypes.Any())
            {
                throw new ArgumentException(nameof(contentTypes));
            }

            _contentTypes = contentTypes;
        }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, false.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return _contentTypes.Any(e => e.ToLower() == ((string)value).ToLower());
        }

        /// <summary>
        /// Formats the error message.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            string errorMessageString = this.ErrorMessageString;

            object[] objArray = new object[2];

            objArray[0] = name;
            objArray[1] = string.Join(", ", _contentTypes);

            return string.Format(currentCulture, errorMessageString, objArray);
        }
    }
}
