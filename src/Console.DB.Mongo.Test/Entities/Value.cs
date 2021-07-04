using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.Domain.Entities;

namespace Console.DB.Mongo.Test.Entities
{
    [Table("Values")]
    public class Value : EntityAuditBase<Guid>
    {
        #region Overrides of EntityBase<Guid>

        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        [Key]
        public override Guid Id { get; set; }

        #endregion
    }
}
