using AsanPardakht.Entities.Users;

namespace AsanPardakht.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ShowAllUser();
        Task<IEnumerable<ResultUserLoginDto>> ShowUser();
    }
}