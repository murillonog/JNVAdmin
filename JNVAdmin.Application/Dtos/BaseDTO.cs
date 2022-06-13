using System;
using System.Text.Json.Serialization;

namespace JNVAdmin.Application.Dtos
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
    }
}
