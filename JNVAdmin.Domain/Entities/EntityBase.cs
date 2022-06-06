using System;

namespace JNVAdmin.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime? Created { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public DateTime? Modified { get; protected set; }
        public bool? Active { get; protected set; }
    }
}
