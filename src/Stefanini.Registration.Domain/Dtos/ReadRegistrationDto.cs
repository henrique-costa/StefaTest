using Stefanini.Registration.Domain.Entities;
using Stefanini.Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Dtos
{
    public class ReadRegistrationDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The number must be greater than zero.")]
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Event Event { get; set; }
        public RegistrationStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? Active { get; set; }
    }
}
