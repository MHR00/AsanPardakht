using AsanPardakht.Entities.Users;
using AsanPardakht.Entities.Wallet;

namespace AsanPardakht.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ShowAllUser();
        Task<ShowUserProfile> ShowProfile(int UserId);
        Task AddContact(UserContactDto contact, int userId);
        Task<IEnumerable<UserContactList>> ShowUserContact(int userId);


    }
}