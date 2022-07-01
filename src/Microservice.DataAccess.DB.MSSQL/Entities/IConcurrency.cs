namespace Microservice.DataAccess.DB.MSSQL.Entities
{
    public interface IConcurrency
    {
        /// <summary>
        /// Gets or sets the row version for entity.
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
