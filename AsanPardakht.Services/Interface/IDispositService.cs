using AsanPardakht.Entities.Wallet;

namespace AsanPardakht.Services.Interface
{
    public interface IDispositService
    {
        Task Disposit(int userId, int money ,bool type);
        Task TransferMoney(int senderId, int reciverId, int amount, bool type);

        Task<IEnumerable<BalaceAccountDto>> GetBalaceAccount(int userId);

        Task<IEnumerable<TransactionListDto>> ShowTransactionList(int userId);

    }
}