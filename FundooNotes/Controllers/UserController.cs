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
        public IActionResult Register([FromBody] UserModel user)
        {
            try
            {
                string resultMessage = this.manager.Register(user);
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
                if (result.Equals("Login is successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login is completed" });
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
        public IActionResult ForgotPassword([FromBody] LoginDetails forgotpassword)
        {
            try
            {
                string result = this.manager.ForgotPassword(forgotpassword);
                if(result.Equals("Mail Sent Successfully, Please check your mail !"))
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
        public IActionResult ResetPassword([FromBody] LoginDetails resetpassword)
        {
            try 
            {
                string result = this.manager.ResetPassword(resetpassword);
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
