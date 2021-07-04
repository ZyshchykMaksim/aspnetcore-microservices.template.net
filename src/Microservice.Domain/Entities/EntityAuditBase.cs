using System;

namespace Microservice.Domain.Entities
{
    /// <summary>
    /// The class of base audit.
    /// </summary>
    public abstract class EntityAuditBase<TKey> : EntityBase<TKey>, IAuditable, ISoftDelitable
    {
        #region Implementation of IAuditable

        ///<inheritdoc cref="IAuditable"/>
        public virtual string CreatedBy { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public virtual DateTime CreatedUtc { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public virtual string LastModifiedBy { get; set; }

        ///<inheritdoc cref="IAuditable"/>
        public virtual DateTime LastModifiedUtc { get; set; }

        #endregion

        #region Implementation of ISoftDelitable

        ///<inheritdoc cref="ISoftDelitable"/>
        public virtual string DeletedBy { get; set; }

        ///<inheritdoc cref="ISoftDelitable"/>
        public virtual DateTime? DeletedUtc { get; set; }

        #endregion
    }
}
