using AsanPardakht.Data.DbAccess;
using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanPardakht.Services.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ISqlDataAccess _db;

        public UserService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<User>> ShowAllUser() =>
           _db.LoadData<User, dynamic>("dbo.spUser_GetAll", new { });

          public Task<IEnumerable<ResultUserLoginDto>> ShowUser() =>
           _db.LoadData<ResultUserLoginDto, dynamic>("dbo.spResultUserLoginDto", new { });

    }
}
