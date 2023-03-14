namespace HmsBackendTaskOne.Domain.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
