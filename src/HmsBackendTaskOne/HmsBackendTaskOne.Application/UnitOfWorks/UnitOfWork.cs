using HmsBackendTaskOne.Domain.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace HmsBackendTaskOne.Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public virtual void Dispose() => _dbContext?.Dispose();
        public virtual void Save() => _dbContext?.SaveChanges();
    }
}