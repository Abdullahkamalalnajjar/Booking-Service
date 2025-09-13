
namespace Project.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository Users { get; }
      
        Task<int> CompeleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

    }
}
