namespace Microservice.DataAccess.DB.Mongo
{
    /// <summary>
    /// The interface provides to manage settings for connecting to the database.
    /// </summary>
    public interface IDbContextOptions
    {
        /// <summary>
        /// Gets or sets connection to database.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the name of database to connect.
        /// </summary>
        public string Database { get; set; }
    }
}
