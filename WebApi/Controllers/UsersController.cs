using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetList")]
        public IActionResult GetList()
        {

            return Ok(_userService.GetList());
        }   
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {

            var result = _userService.GetById(id);
            if(result.Success)
            {
                 return Ok(result);
            }
            return BadRequest(result.Message);    
        }              
        [HttpPost("update")]
        public IActionResult Update(User user)
        {

            var result = _userService.Update(user);
            if(result.Success)
            {
                 return Ok(result);
            }
            return BadRequest(result.Message);    
        }         
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {

            var result = _userService.Update(user);
            if(result.Success)
            {
                 return Ok(result);
            }
            return BadRequest(result.Message);    
        }        
        [HttpPost("changePassword")]
        public IActionResult ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {

            var result = _userService.ChangePassword(userChangePasswordDto);
            if(result.Success)
            {
                 return Ok(result);
            }
            return BadRequest(result.Message);    
        }


    }
}
