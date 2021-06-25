using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.Domain.Entities;

namespace Microservice.Value.Domen.Entities
{
    /// <summary>
    /// The class for catalog.
    /// </summary>
    public class Value : EntityAuditBase<Guid>
    {
        #region Overrides of EntityBase<Guid>

        /// <summary>
        /// Gets unique identifier for base entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        #endregion

        /// <summary>
        /// The name of value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of value.
        /// </summary>s
        public string Description { get; set; }
    }
}
