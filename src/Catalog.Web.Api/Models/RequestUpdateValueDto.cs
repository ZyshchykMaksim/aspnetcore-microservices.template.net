namespace Microservice.Value.Web.Api.Models
{
    public class RequestUpdateValueDto : RequestCreateValueDto
    {
        /// <summary>
        /// Current resource row version.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
