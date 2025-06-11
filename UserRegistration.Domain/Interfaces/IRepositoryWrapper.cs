namespace UserRegistration.Domain.Interfaces
{    
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
