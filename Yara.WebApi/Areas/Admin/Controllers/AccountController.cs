using Microsoft.AspNetCore.Mvc;

namespace Yara.WebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly IAccount _account;

        //public AccountController(IAccount account)
        //{
        //    _account = account;
        //}

        //[Route("GetOk")]
        //[HttpGet]
        //public ActionResult GetOk()
        //{
        //    return Ok();
        //}

        //[Route("GetAccountInformation")]
        //[HttpPost]
        //public ActionResult GetAccountInformation([FromBody] AccountInformationDTO accountInformationDTO)
        //{
        //    //return new Account_BL(_account).GetAccountInformation(accountInformationDTO);
        //    return null;
        //}
    }
}