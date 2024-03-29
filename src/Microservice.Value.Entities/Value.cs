﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservice.Entities.MSSQL;

namespace Microservice.Value.Entities
{
    /// <summary>
    /// The class for value.
    /// </summary>
    public sealed class Value : IEntity<Guid>, IAuditable, ISoftDelitable, IConcurrency
    {
        #region Implementation of IEntity<T>

        /// <inheritdoc cref="IEntity"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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

        #region Implementation of IAuditable

        /// <inheritdoc cref="IAuditable"/>
        public string CreatedBy { get; set; }

        /// <inheritdoc cref="IAuditable"/>
        public DateTime CreatedUtc { get; set; }

        /// <inheritdoc cref="IAuditable"/>
        public string LastModifiedBy { get; set; }

        /// <inheritdoc cref="IAuditable"/>
        public DateTime LastModifiedUtc { get; set; }

        #endregion

        #region Implementation of ISoftDelitable

        /// <inheritdoc cref="ISoftDelitable"/>
        public string DeletedBy { get; set; }

        /// <inheritdoc cref="ISoftDelitable"/>
        public DateTime? DeletedUtc { get; set; }

        #endregion
    }
}
