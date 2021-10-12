using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {

        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public Task<string> Register(UserModel user)
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
        public Task<string> Login(LoginDetails login)
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
        public Task<string> ForgotPassword(LoginDetails forgotpassword)
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

        public Task<string> ResetPassword(LoginDetails resetpassword)
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
