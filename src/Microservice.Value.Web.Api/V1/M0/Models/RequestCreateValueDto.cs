using System.ComponentModel.DataAnnotations;

namespace Microservice.Value.Web.Api.V1.M0.Models
{
    public class RequestCreateValueDto
    {
        /// <summary>
        /// Gets and sets the name of value.
        /// </summary>
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "{0} is required"
        )]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the description of value.
        /// </summary>
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "{0} is required"
        )]
        public string Description { get; set; }
    }
}
