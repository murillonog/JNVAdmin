using JNVAdmin.Domain.Validation;
using System;
using System.Collections.Generic;

namespace JNVAdmin.Domain.Entities
{
    public class Snack : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<Schedule> Schedules { get; set; }

        public Snack(Guid id, string name, string modifiedBy, DateTime modified)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(modifiedBy),
                "Invalid modifiedBy. modifiedBy is required.");

            ValidationDomain(name);

            Id = id;
            Modified = modified;
            ModifiedBy = modifiedBy;
        }

        public Snack(string name, string createdBy, DateTime created)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(createdBy),
                "Invalid createdBy. createdBy is required.");

            ValidationDomain(name);

            Created = created;
            CreatedBy = createdBy;
        }

        public void Update(string name, string modifiedBy, DateTime modified)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(modifiedBy),
                "Invalid modifiedBy. modifiedBy is required.");

            ValidationDomain(name);

            Modified = DateTime.Now;
            ModifiedBy = modifiedBy;
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters.");
        }
    }
}
