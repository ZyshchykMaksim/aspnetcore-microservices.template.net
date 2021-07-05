namespace Microservice.DataAccess.DB.Mongo
{

    public class DbContextOptions : IDbContextOptions
    {
        #region Implementation of IDbContextOptions

        
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the name of database to connect.
        /// </summary>
        public string Database { get; set; }

        #endregion
    }
}
