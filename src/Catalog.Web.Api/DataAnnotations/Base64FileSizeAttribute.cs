using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Microservice.Value.Web.Api.DataAnnotations
{
    /// <summary>
    /// The class provides to validate the size of file encoded in base 64 string.
    /// </summary>
    public class Base64FileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Base64FileSizeAttribute"/> class.
        /// </summary>
        /// <param name="maxFileSize">Maximum size of the file.</param>
        public Base64FileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>
        /// true if the specified value is valid; otherwise, false.
        /// </returns>
        public override bool IsValid(object value)
        {
            var valueString = value?.ToString();

            if (string.IsNullOrEmpty(valueString))
            {
                return true;
            }

            try
            {
                var file = Convert.FromBase64String(valueString);

                return file.LongLength <= _maxFileSize;
            }
            catch (FormatException)
            {
                return true;
            }
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>
        /// An instance of the formatted error message.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            string errorMessageString = this.ErrorMessageString;
            object[] objArray = new object[2];

            objArray[0] = name;
            objArray[1] = _maxFileSize / 1024 / 1024;

            return string.Format((IFormatProvider)currentCulture, errorMessageString, objArray);
        }
    }
}
