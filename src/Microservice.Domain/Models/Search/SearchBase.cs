namespace Microservice.Domain.Models.Search
{
    /// <summary>
    /// The base class to search terms.
    /// </summary>
    public abstract class SearchBase
    {
        private const int DefaultSkip = 0;
        private static readonly int DefaultTake = 30;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBase"/> class.
        /// </summary>
        protected SearchBase()
        {
            this.Skip = DefaultSkip;
            this.Take = DefaultTake;
        }

        /// <summary>
        /// The pagination (skip).
        /// </summary>
        public virtual int Skip { get; set; }

        /// <summary>
        /// The pagination (take).
        /// </summary>
        public virtual int Take { get; set; }
    }
}
