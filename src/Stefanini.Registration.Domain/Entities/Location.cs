using Stefanini.Registration.Domain.Common;

namespace Stefanini.Registration.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public string City { get; set; }
        public string State { get; set; }
    }
}
