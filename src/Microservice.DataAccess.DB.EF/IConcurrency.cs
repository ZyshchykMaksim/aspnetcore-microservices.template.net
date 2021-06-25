using System.ComponentModel.DataAnnotations;

namespace Microservice.DataAccess.DB.EF
{
    public interface IConcurrency
    {
        /// <summary>
        /// Gets or sets the row version for entity.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
