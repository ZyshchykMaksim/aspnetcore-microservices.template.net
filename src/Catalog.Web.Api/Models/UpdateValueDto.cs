namespace Microservice.Value.Web.Api.Models
{
    public class UpdateValueDto : CreateValueDto
    {
        /// <summary>
        /// Current resource row version.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
