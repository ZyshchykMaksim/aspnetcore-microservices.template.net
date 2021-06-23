using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Microservice.Value.Web.Api.DataAnnotations
{
    /// <summary>
    /// ListElementsRangeAttribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class ListElementsRangeAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} must contain number of elements within range {1} - {2}";

        private readonly int min;
        private readonly int max;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListElementsRangeAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ListElementsRangeAttribute(int min, int max) : base(DefaultErrorMessage)
        {
            this.min = min;
            this.max = max;
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
            var list = value as IList;

            if (list == null)
            {
                return true;
            }

            if (list.Count < this.min || list.Count > this.max)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Formats the error message.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Formatted error response.</returns>
        public override string FormatErrorMessage(string name)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            string errorMessageString = this.ErrorMessageString;

            object[] objArray = new object[3];

            objArray[0] = name;
            objArray[1] = min;
            objArray[2] = max;

            return string.Format(currentCulture, errorMessageString, objArray);
        }
    }
}
