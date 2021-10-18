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
        public string ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
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
        public string GenerateToken(string email)
        {
            try
            {
                return this.repository.GenerateToken(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
