namespace Microservice.Entities.MSSQL
{
    public interface IConcurrency
    {
        /// <summary>
        /// Gets or sets the row version for entity.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
