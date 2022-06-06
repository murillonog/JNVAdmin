using JNVAdmin.Domain.Validation;
using System;

namespace JNVAdmin.Domain.Entities
{
    public class Schedule : EntityBase
    {      
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public int? Quantity { get; private set; }
        public decimal? AvarageAge { get; private set; }
        public decimal? SpentValue { get; private set; }
        public decimal? ReceivedValue { get; private set; }
        public decimal? FullValue { get; private set; }

        public Guid SnackId { get; set; }
        public Snack Snack { get; set; }

        public Schedule(Guid id, string name, DateTime date, int quantity, 
            decimal avarageAge, decimal spentValue, decimal receivedValue, 
            decimal fullValue, string createdBy)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(createdBy),
                "Invalid createdBy. createdBy is required.");

            ValidationDomain(name, date, quantity, avarageAge, spentValue, receivedValue, fullValue);

            Id = id;
            CreatedBy = createdBy;
            Created = DateTime.Now;
        }

        public Schedule(string name, DateTime date, int quantity, 
            decimal avarageAge, decimal spentValue, decimal receivedValue, 
            decimal fullValue)
        {
            ValidationDomain(name, date, quantity, avarageAge, spentValue, receivedValue, fullValue);
        }

        public void Update(string name, DateTime date, int quantity,
            decimal avarageAge, decimal spentValue, decimal receivedValue,
            decimal fullValue, string modifiedBy, Guid snackId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(modifiedBy),
                "Invalid modifiedBy. modifiedBy is required.");

            ValidationDomain(name, date, quantity, avarageAge, spentValue, receivedValue, fullValue);
            
            SnackId = snackId;
            ModifiedBy = modifiedBy;
            Modified = DateTime.Now;
        }

        private void ValidationDomain(string name, DateTime date, int quantity, decimal avarageAge, decimal spentValue, decimal receivedValue, decimal fullValue)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters.");

            DomainExceptionValidation.When(quantity < 0, "Invalid quantity value.");

            DomainExceptionValidation.When(avarageAge < 0, "Invalid avarage age value.");

            DomainExceptionValidation.When(spentValue < 0, "Invalid spent value.");

            DomainExceptionValidation.When(receivedValue < 0, "Invalid received value.");

            Name = name;
            Date = date;
            Quantity = quantity;
            AvarageAge = avarageAge;
            SpentValue = spentValue;
            ReceivedValue = receivedValue;
            FullValue = fullValue;
        }
    }
}
