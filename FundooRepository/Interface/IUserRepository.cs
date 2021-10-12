using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
   public interface IUserRepository
    {
        Task<string> Register(UserModel user);
               
        Task<string> Login(LoginDetails login);

        Task<string> ForgotPassword(LoginDetails forgotpassword);
        Task<string> ResetPassword(LoginDetails resetpassword);
    }
}
