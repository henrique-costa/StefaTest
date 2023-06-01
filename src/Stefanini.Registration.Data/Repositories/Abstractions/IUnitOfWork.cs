namespace Stefanini.Registration.Data.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}
