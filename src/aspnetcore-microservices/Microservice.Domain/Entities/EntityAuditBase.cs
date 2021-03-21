using System;

namespace Microservice.Domain.Entities
{
    /// <summary>
    /// The class of base audit.
    /// </summary>
    public abstract class EntityAuditBase : EntityBase, IAuditable
    {
        #region Implementation of IAuditable

        ///<inheritdoc cref="IAuditable"/>
        public string CreatedBy { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public DateTime CreatedUtc { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public string LastModifiedBy { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public DateTime LastModifiedUtc { get; set; }

        #endregion
    }
}
