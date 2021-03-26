using System;

namespace Microservice.Domain.Entities
{
    /// <summary>
    /// The class of base audit.
    /// </summary>
    public abstract class EntityAuditBase : EntityBase, IAuditable, ISoftDelitable
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

        #region Implementation of ISoftDelitable

        ///<inheritdoc cref="ISoftDelitable"/>
        public string DeletedBy { get; set; }

        ///<inheritdoc cref="ISoftDelitable"/>
        public DateTime? DeletedUtc { get; set; }

        #endregion
    }
}
