using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {

        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public string Register(UserModel user)
        {
            try
            {
                return this.repository.Register(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string Login(LoginDetails login)
        {
            try
            {
                return this.repository.Login(login);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string ForgotPassword(LoginDetails forgotpassword)
        {
            try
            {
                return this.repository.ForgotPassword(forgotpassword);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string ResetPassword(LoginDetails resetpassword)
        {
            try
            {
                return this.repository.ResetPassword(resetpassword);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
