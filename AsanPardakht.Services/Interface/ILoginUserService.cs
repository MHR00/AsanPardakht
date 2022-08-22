using AsanPardakht.Entities.Users;

namespace AsanPardakht.Services.Interface
{
    public interface ILoginUserService
    {
        Task<ResultUserLoginDto> LoginUsers(UserLoginDto user);
    }
}