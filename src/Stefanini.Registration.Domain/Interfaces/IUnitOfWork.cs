namespace Stefanini.Registration.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}
