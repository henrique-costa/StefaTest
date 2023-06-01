using Stefanini.Registration.Domain.Common;
using Stefanini.Registration.Domain.Enums;

namespace Stefanini.Registration.Domain.Entities
{
    public class Registration : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public RegistrationStatus Status { get; set; }
        public Event Event { get; set; }      
    }
}
