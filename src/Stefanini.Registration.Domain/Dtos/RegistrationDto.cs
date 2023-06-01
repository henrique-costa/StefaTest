using Stefanini.Registration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Dtos
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public RegistrationStatus Status { get; set; }
    }
}
