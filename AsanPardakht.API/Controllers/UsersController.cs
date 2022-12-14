using AsanPardakht.Entities.Users;
using AsanPardakht.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsanPardakht.Common;
using AsanPardakht.Common.Utilities;
using AsanPardakht.Entities.Wallet;
using System.Security.Claims;

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
            _editUserService = editUserService;
            _userService = userService;
        }


        [HttpGet("[action]")]
        public async Task<IResult> ShowUserProfile()
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                var result = await _userService.ShowProfile(userId);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IResult> AddContact(UserContactDto contact)
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                await _userService.AddContact(contact, userId);
                return Results.Ok();
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
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var userName = claimsIdentity.FindFirst("Name").ToString();
                var userId = HttpContext.User.Identity.GetUserId<int>();
                await _editUserService.EditUser(user, userId);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IResult> ShowUserContact()
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                var result= await _userService.ShowUserContact(userId);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


    }
}
