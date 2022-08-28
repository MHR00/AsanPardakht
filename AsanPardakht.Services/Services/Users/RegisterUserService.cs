using AsanPardakht.Data.DbAccess;
using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanPardakht.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly ISqlDataAccess _db;
        public RegisterUserService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task RegisterUsers(RegisterUserDto users) =>
            _db.SaveData("dbo.spUser_Register", new
            {
                users.UserName,
                users.Password,
                users.MobileNumber,
            });





       
    }
}
