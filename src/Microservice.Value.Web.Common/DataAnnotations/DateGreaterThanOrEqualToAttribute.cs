using System;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to check that the date greater than value in parameter.
    /// </summary>
    public class DateGreaterThanAttribute : GreaterThanAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateGreaterThanAttribute"/> class.
        /// </summary>
        /// <param name="dependentProperty">The dependent property.</param>
        public DateGreaterThanAttribute(string dependentProperty) : base(dependentProperty) { }

        /// <summary>
        /// Returns true if specified values are valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dependentValue">The dependent value.</param>
        /// <param name="container">The container.</param>
        /// <returns>
        ///   <c>true</c> if the specified values are valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(object value, object dependentValue, object container)
        {
            if (value == null ||
                dependentValue == null ||
                !DateTime.TryParse(value.ToString(), out var dateValue) ||
                !DateTime.TryParse(dependentValue.ToString(), out var dateDependentValue))
            {
                return true;
            }

            return base.IsValid(dateValue, dateDependentValue, container);
        }
    }
}
