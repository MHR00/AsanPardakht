using AsanPardakht.Common.Utilities;
using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using AsanPardakht.Services.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AsanPardakht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IRegisterUserService _registerUser;
        private readonly ILoginUserService _loginUser;
        private readonly IJwtService _jwtService;
        public UserAuthenticationController(IRegisterUserService registerUser,
            IJwtService jwtService,
            ILoginUserService loginUser)
        {
            _registerUser = registerUser;
            _jwtService = jwtService;
            _loginUser = loginUser;
        }

        [HttpGet]
        public async Task<IResult> UserLogin([FromQuery] UserLoginDto user)
        {
            try
            {
                var passwordhash = SecurityHelper.GetSha256Hash(user.Password);
                var users = await _loginUser.LoginUsers(user);
                if(users.PasswordHash == passwordhash)
                {
                    var jwt = _jwtService.Generate(users);
                    return Results.Ok(jwt);
                }
                else
                {
                    return Results.NotFound();
                }
                
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IResult> RegisterUser(RegisterUserDto user)
        {
            try
            {
               var passwordhash = SecurityHelper.GetSha256Hash(user.Password);
               user.Password = passwordhash;
               await _registerUser.RegisterUsers(user);
               
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
