namespace Stefanini.Registration.Data.Repositories.Abstractions
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly StefaniniRegistrationContext _context;

        public UnitOfWork(StefaniniRegistrationContext context)
        {
            _context = context;
        }

        public async Task CommitChanges() => await _context.SaveChangesAsync();
    }
}
