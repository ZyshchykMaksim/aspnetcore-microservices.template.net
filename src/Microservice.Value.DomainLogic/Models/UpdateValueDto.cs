namespace Microservice.Value.BusinessLogic.Models
{
    public class UpdateValueDto : CreateValueDto
    {
        /// <summary>
        /// Current resource row version.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
