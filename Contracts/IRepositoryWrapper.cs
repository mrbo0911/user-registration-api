namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        void Save();
    }
}
