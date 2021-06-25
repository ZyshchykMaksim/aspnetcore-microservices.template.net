using System;

namespace Microservice.Web.Common.DataAnnotations
{
    /// <summary>
    /// The class provides to check value greater than value in other parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class GreaterThanAttribute : Foolproof.GreaterThanAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThanAttribute"/> class.
        /// </summary>
        /// <param name="dependentProperty">The dependent property.</param>
        public GreaterThanAttribute(string dependentProperty) : base(dependentProperty) { }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dependentValue">The dependent value.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public override bool IsValid(object value, object dependentValue, object container)
        {
            if (PassOnNull && value == null && dependentValue == null)
            {
                return true;
            }

            return base.IsValid(value, dependentValue, container);
        }
    }
}
