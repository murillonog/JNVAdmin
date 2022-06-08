using JNVAdmin.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JNVAdmin.Application.Dtos
{
    public class ScheduleDTO : BaseDTO
    {
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public int? Quantity { get; private set; }
        public decimal? AvarageAge { get; private set; }
        public decimal? SpentValue { get; private set; }
        public decimal? ReceivedValue { get; private set; }
        public decimal? FullValue { get; private set; }

        public Guid SnackId { get; set; }
        [JsonIgnore]
        public Snack Snack { get; set; }
    }
}
