using Stefanini.Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Dtos
{
    public class ReadEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public int? EventLocationId { get; set; }
        public virtual Location Location { get; set; }
        public List<Domain.Entities.Registration> Registrations { get; set; }
        public bool? Active { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
