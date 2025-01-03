namespace BankSphere.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateSavingAccount(int productId);
        Task CreateCheckingAccount(int productId);
        Task CreateCDTAccount(int productId, decimal? interestRate);
    }
}
