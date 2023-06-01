namespace Stefanini.Registration.Domain.Common
{
    public abstract class AuditableEntity
    {
        public int Id { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
