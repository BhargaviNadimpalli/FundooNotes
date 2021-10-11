using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public string Register(UserModel user)
        {
            try
            {
                this.userContext.Users.Add(user);
                this.userContext.SaveChanges();
                return "Registration Successful";
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message);
            }
        }
        public string Login(LoginDetails login)
        {
            try
            {
                var result = this.userContext.Users.Where(x => x.Email == login.Email
                                                                     && x.Password == login.Password);
                int count = result.Count();
                if (count > 0)
                {
                    return "Login is successful";
                }
               else
                {
                    return "Email is not valid";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string ForgotPassword(LoginDetails login)
        {
            try
            {
                var result = this.userContext.Users.Where(x => x.Email == login.Email);
               
                int count = result.Count();
               
                if (count > 0)
                {
                  

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("bhargavinadimpalli423@gmail.com");
                    mail.To.Add(login.Email);
                    mail.Subject = "Test Mail";
                    mail.Body = "This is for testing SMTP mail from GMAIL";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("bhargavinadimpalli423@gmail.com", "Bhagi@1234");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    return "Mail Sent Successfully, Please check your mail !";  
                }
                else
                {
                    return "Email not Exists ! Please Register ! ";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
