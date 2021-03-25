namespace Microservice.Value.BusinessLogic.Models
{
    public class CreateValueDto
    {
        /// <summary>
        /// The name of value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of value.
        /// </summary>s
        public string Description { get; set; }
    }
}
