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
    public class EditUserService : IEditUserService
    {
        private readonly ISqlDataAccess _db;
        public EditUserService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task EditUser(EditUserDto user) =>
             _db.SaveData("dbo.spEdit_Profile", user);
    }
}
