using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Common.Web.DataAnnotations
{
    /// <summary>
    /// The class provides to validate that collection contains unique list of elements.
    /// </summary>
    public class UniqueListAttribute : ValidationAttribute
    {
        private const string DEFAULT_ERROR_MESSAGE = "The field {0} contains duplicated items.";

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueListAttribute" /> class.
        /// </summary>
        public UniqueListAttribute() : base(DEFAULT_ERROR_MESSAGE) { }

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
            var list = value as IList;

            if (list == null)
            {
                return true;
            }

            var distinctList = new List<object>();

            foreach (object element in list)
            {
                if (!distinctList.Contains(element))
                {
                    distinctList.Add(element);
                }
            }

            return distinctList.Count == list.Count;
        }
    }
}
