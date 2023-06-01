using Stefanini.Registration.Domain.Common;

namespace Stefanini.Registration.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public int? EventLocationId { get; set; }
        public virtual Location Location { get; set; }

        public List<Registration>? Registrations { get; set; } 

    }
}
