using AsanPardakht.Common.Utilities;
using AsanPardakht.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsanPardakht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IDispositService _dispositService;

        public TransactionController(IDispositService dispositService)
        {
           _dispositService = dispositService;
        }

        [HttpGet("[action]")]
        public async Task<IResult> GetBalaceAccount()
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                var result = await _dispositService.GetBalaceAccount(userId);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IResult> AddMoney(int money , bool type)
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                await _dispositService.Disposit(userId, money ,type);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }


        [HttpPut("[action]")]
        public async Task<IResult> TransferMoney(int reciverId, int amount , bool type)
        {
            try
            {
                var senderId = HttpContext.User.Identity.GetUserId<int>();
                await _dispositService.TransferMoney(senderId,reciverId, amount , type);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IResult> ShowTransactionList()
        {
            try
            {
                var userId = HttpContext.User.Identity.GetUserId<int>();
                var result = await _dispositService.ShowTransactionList(userId);
                return Results.Ok(result);

            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
