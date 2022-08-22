using AsanPardakht.Entities.Users;

namespace AsanPardakht.Services.Interface
{
    public interface IRegisterUserService
    {
        Task RegisterUsers(RegisterUserDto users);
    }
}