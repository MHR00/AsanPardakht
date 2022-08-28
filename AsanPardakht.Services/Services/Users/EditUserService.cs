using AsanPardakht.Data.DbAccess;
using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using AsanPardakht.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AsanPardakht.Services.Services.Users
{
    public class EditUserService : IEditUserService
    {
        private readonly ISqlDataAccess _db;
        public EditUserService(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task EditUser(EditUserDto user , int userId)=>
            _db.SaveData("dbo.spEdit_Profile" , new
            {
                user.Email,
                user.FirstName,
                user.LastName,
                user.MobileNumber,
                userId = userId
            });

        //public Task Edit(EditUserDto user)
        //{

        //var test = new JwtSecurityTokenHandler().ReadJwtToken()
        //}


    }
}
