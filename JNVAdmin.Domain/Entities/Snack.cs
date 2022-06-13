using JNVAdmin.Domain.Validation;
using System;
using System.Collections.Generic;

namespace JNVAdmin.Domain.Entities
{
    public sealed class Snack : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<Schedule> Schedules { get; set; }

        public Snack(string name, string createdBy, string modifiedBy)
        {
            ValidationDomain(name, createdBy);
            
            ModifiedBy = modifiedBy;
        }

        public void Update(Guid id, string name, string createdBy, DateTime? created, string modifiedBy)
        {              
            DomainExceptionValidation.When(string.IsNullOrEmpty(modifiedBy.Trim()),
                "The update user cannot be empty!");

            ValidationDomain(name, createdBy);

            Created = created;            
            ModifiedBy = modifiedBy;
            Id = id;
        }

        private void ValidationDomain(string name, string createdBy)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(createdBy),
                "Invalid createdBy. CreatedBy is required.");

            Name = name;
            CreatedBy = createdBy;
        }
    }
}
