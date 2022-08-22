using AsanPardakht.Entities.Users;

namespace AsanPardakht.Services.Interface
{
    public interface IJwtService
    {
        string Generate(ResultUserLoginDto users);
    }
}