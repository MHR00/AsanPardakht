using AsanPardakht.Common.Utilities;
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
    public class LoginUserService : ILoginUserService
    {
        private readonly ISqlDataAccess _db;
        public LoginUserService(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<ResultUserLoginDto> LoginUsers(UserLoginDto user)
        {
            var result = await _db.LoadData<ResultUserLoginDto, dynamic>(
                "dbo.spUser_Login",
                new
                {
                    user.UserName,
                    user.Password
                });
            
            
            return result.FirstOrDefault();
        }





    }
}
