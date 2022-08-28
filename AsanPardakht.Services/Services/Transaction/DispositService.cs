using AsanPardakht.Data.DbAccess;
using AsanPardakht.Entities.Wallet;
using AsanPardakht.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanPardakht.Services.Services.Transaction
{
    public class DispositService : IDispositService
    {
        private readonly ISqlDataAccess _db;
        public DispositService(ISqlDataAccess db)
        {
            _db = db;
        }


        public Task Disposit(int userId, int money , bool type) =>

            _db.SaveData("dbo.sp_DispositMoney", new
            {
                UserId = userId,
                MoneyAmount = money,
                Type = type
            });

        public Task TransferMoney(int senderId, int reciverId, int amount , bool type) =>

           _db.SaveData("dbo.sp_TransferMoney", new
           {
               SenderId = senderId,
               ReciverId = reciverId,
               Amount = amount,
               Type = type
           });


        public Task<IEnumerable<BalaceAccountDto>> GetBalaceAccount(int userId) =>
        _db.LoadData<BalaceAccountDto, dynamic>("dbo.sp_GetBalaceAccount", new { AccountId= userId });

        public Task<IEnumerable<TransactionListDto>> ShowTransactionList(int userId) =>
            _db.LoadData<TransactionListDto, dynamic>("dbo.sp_ShowTransactionList" , new {userId});
        


    }
}
