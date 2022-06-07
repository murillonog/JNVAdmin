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

        public Schedule(Guid id, string name, DateTime date, int? quantity,
            decimal? avarageAge, decimal? spentValue, decimal? receivedValue,
            decimal? fullValue)
        {
            ValidationDomain(name);

            Id = id;
            Date = date;
            Quantity = quantity;
            AvarageAge = avarageAge;
            SpentValue = spentValue;
            ReceivedValue = receivedValue;
            FullValue = fullValue;
        }

        public Schedule(string name, DateTime date, int? quantity,
            decimal? avarageAge, decimal? spentValue, decimal? receivedValue,
            decimal? fullValue)
        {
            ValidationDomain(name);

            Date = date;
            Quantity = quantity;
            AvarageAge = avarageAge;
            SpentValue = spentValue;
            ReceivedValue = receivedValue;
            FullValue = fullValue;
        }

        public void Update(string name, DateTime date, int? quantity,
            decimal? avarageAge, decimal? spentValue, decimal? receivedValue,
            decimal? fullValue, Guid snackId)
        {

            ValidationDomain(name);
            
            Date = date;
            Quantity = quantity;
            AvarageAge = avarageAge;
            SpentValue = spentValue;
            ReceivedValue = receivedValue;
            FullValue = fullValue;
            SnackId = snackId;
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 charecters.");

            Name = name;            
        }
    }
}
