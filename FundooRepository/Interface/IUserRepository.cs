using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
   public interface IUserRepository
    {
        string Register(UserModel user);
               
        string Login(LoginDetails login);

        string ForgotPassword(LoginDetails forgotpassword);
        string ResetPassword(LoginDetails resetpassword);
    }
}
