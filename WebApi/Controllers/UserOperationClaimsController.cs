using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IUserOperationClaimService   _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("add")]

        public IActionResult Add(UserOperationClaim userOperationClaimService)
        {
            _userOperationClaimService.Add(userOperationClaimService);
            return Ok("Kullanıcı Yetkilendirme Başarıyla Tamamlandı");


        }



    }

}
