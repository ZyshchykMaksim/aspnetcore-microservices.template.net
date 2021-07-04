using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.DataAccess.DB.EF;
using Microservice.Domain.Entities;

namespace Microservice.Value.Domen.Entities
{
    /// <summary>
    /// The class for value.
    /// </summary>
    public class Value : EntityAuditBase<Guid>, IConcurrency
    {
        #region Overrides of EntityBase<Guid>

        /// <inheritdoc cref="EntityBase"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the name of value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of value.
        /// </summary>s
        public string Description { get; set; }

        #region Implementation of IConcurrency

        /// <inheritdoc cref="IConcurrency"/>
        [Timestamp]
        public byte[] RowVersion { get; set; }

        #endregion
    }
}
