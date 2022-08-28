using AsanPardakht.Data.DbAccess;
using AsanPardakht.Entities.Users;
using AsanPardakht.Entities.Wallet;
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

        public async Task<ShowUserProfile> ShowProfile(int userId)
        {

            var results = await _db.LoadData<ShowUserProfile, dynamic>("dbo.sp_ShowProfile",new
            {

                userId
            });
              
              
            return results.FirstOrDefault();
        }

        public Task AddContact(UserContactDto contact, int userId)=>
        
            _db.SaveData("dbo.spAdd_Contact", new
            {
                contact.Name,
                contact.MobileNumber,
                userId = userId
                
            });

        public Task<IEnumerable<UserContactList>> ShowUserContact(int userId)=>
     
            _db.LoadData<UserContactList , dynamic>("dbo.spShowUserContact" , new {UserId  = userId});
      
       
         

    }
}
