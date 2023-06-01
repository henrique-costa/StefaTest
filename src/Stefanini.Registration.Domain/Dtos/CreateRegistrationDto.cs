using Stefanini.Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Dtos
{
    public class CreateRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public RegistrationStatus Status { get; set; }
        public bool? Active { get; set; } = true;
        [JsonIgnore]
        public DateTime CreatedOn { get; set; } = DateTime.Now;       
    }
}
