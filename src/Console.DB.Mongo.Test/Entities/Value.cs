using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.Domain;

namespace Console.DB.Mongo.Test.Entities
{
    [Table("Values")]
    public class Value : IEntity<Guid>, IAuditable, ISoftDelitable
    {
        #region Overrides of EntityBase<Guid>

        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        #endregion

        #region Implementation of IAuditable

        /// <summary>
        /// Id of the user who created record.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date when resource was created (in UTC timezone).
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Id of the user who updated record.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Date when resource was updated (in UTC timezone).
        /// </summary>
        public DateTime LastModifiedUtc { get; set; }

        #endregion

        #region Implementation of ISoftDelitable

        /// <summary>
        /// Id of the user who deleted record.
        /// </summary>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Date when resource was deleted (in UTC timezone).
        /// </summary>
        public DateTime? DeletedUtc { get; set; }

        #endregion
    }
}
