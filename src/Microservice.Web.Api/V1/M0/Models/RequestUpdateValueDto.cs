namespace Microservice.Web.Api.V1.M0.Models
{
    public class RequestUpdateValueDto : RequestCreateValueDto
    {
        /// <summary>
        /// Current resource row version.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
