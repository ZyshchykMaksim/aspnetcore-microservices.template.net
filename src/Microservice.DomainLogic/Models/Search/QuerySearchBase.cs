namespace Microservice.DomainLogic.Models.Search
{
    /// <summary>
    /// The base class to search terms.
    /// </summary>
    public abstract class QuerySearchBase : SearchBase
    {
        /// <summary>
        /// The generic text search.
        /// </summary>
        public string Q { get; set; }
    }
}
