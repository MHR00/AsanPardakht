using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsanPardakht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IEditUserService _editUserService;
        private readonly IUserService _userService;

        public UsersController(IEditUserService editUserService,
            IUserService userService)
        {
            _editUserService= editUserService;
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IResult> GetAllUsers()
        {
            try
            {
                return Results.Ok(await _userService.ShowAllUser());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IResult> EditUser(EditUserDto user)
        {
            try
            {
                await _editUserService.EditUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


    }
}
