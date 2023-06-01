using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Domain.Dtos
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableSeats { get; set; }
        public int? EventLocationId { get; set; }
        public bool? Active { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
