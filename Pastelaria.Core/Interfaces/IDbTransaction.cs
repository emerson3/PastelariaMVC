namespace Pastelaria.Core.Interfaces
{
    public interface IDbTransaction
    {
        Task CommitAsync();
        void Commit();

        Task RollbackAsync();
        void Rollback();
    }
}