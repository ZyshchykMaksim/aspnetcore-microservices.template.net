using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Microservice.Value.Web.Api.DataAnnotations
{
    /// <summary>
    /// The class provides to check that property value exists in enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumMemberAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} must contain valid enumeration values.";

        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumMemberAttribute" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentException">type</exception>
        public EnumMemberAttribute(Type type) : base(DefaultErrorMessage)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException(nameof(type));
            }

            _type = type;
        }

        /// <summary>
        /// Gets the value indicating whether or not the specified <paramref name="value" /> is valid
        /// with respect to the current validation attribute.
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

            bool isValid = Enum.IsDefined(_type, value);

            return isValid;
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

            objArray[0] = (object)name;
            objArray[1] = (object)string.Join(", ", Enum.GetValues(_type).Cast<object>().Select(e => Enum.GetName(_type, e)));

            return string.Format(currentCulture, errorMessageString, objArray);
        }
    }
}
