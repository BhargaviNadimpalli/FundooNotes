using FundooManager.Interface;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            try
            {
                string resultMessage = await this.manager.Register(user);
                if (resultMessage.Equals("Registration Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = resultMessage });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = resultMessage });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = e.Message });
            }
        }
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginDetails login)
        {
            try
            {
                string result = this.manager.Login(login);
                string token = this.manager.GenerateToken(login.Email);
                if (result.Equals("Login is successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = login.Email + " Token: " + token });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = e.Message });
            }
        }
        [HttpPost]
        [Route("api/forgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result = this.manager.ForgotPassword(email);
                if(result.Equals("Send Email Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = e.Message });
            }
        }
        [HttpPut]
        [Route("api/resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] LoginDetails resetpassword)
        {
            try 
            {
                string result = await this.manager.ResetPassword(resetpassword);
                if (result.Equals("Reset password is successfull"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = e.Message });
            }
        }

    }
}
