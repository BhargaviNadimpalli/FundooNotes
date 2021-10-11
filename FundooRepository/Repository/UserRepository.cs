﻿using FundooModels;
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
                                                                     && x.Password == login.Password).FirstOrDefault();
                
                if (result != null)
                {
                    return "Login is successful";
                }
               else
                {
                    return "Email is not valid or password is not valid";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string ForgotPassword(LoginDetails forgotpassward)
        {
            try
            {
                var result = this.userContext.Users.Where(x => x.Email == forgotpassward.Email).FirstOrDefault();
               
                
               
                if (result != null)
                {                 
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",587);

                    mail.From = new MailAddress("bhargavinadimpalli423@gmail.com");
                    mail.To.Add(forgotpassward.Email);
                    mail.Subject = "Fundoo Notes";
                    mail.Body = "This is for testing SMTP mail from GMAIL";

                    //SmtpServer.Port = 587;
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



        public string ResetPassword(LoginDetails resetpassword)
        {
            try
            {
                var user = this.userContext.Users.Where(x => x.Email == resetpassword.Email).FirstOrDefault();
                if (user != null)
                {
                    this.userContext.Users.Update(user);
                    this.userContext.SaveChanges();
                    return "Reset password is successfull";
                }
                else
                {
                    return "Invalid Email. please enter the correct email";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
