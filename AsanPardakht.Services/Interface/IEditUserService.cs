using AsanPardakht.Entities.Users;

namespace AsanPardakht.Services.Interface
{
    public interface IEditUserService
    {
        Task EditUser(EditUserDto user);
    }
}