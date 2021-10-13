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
               
        string Login(LoginDetails login);

       string ForgotPassword(string email);
        Task<string> ResetPassword(LoginDetails resetpassword);
    }
}
