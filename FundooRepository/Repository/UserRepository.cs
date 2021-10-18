using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using Experimental.System.Messaging;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        private readonly IConfiguration configuration;

        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }
        public async Task<string> Register(UserModel user)
        {
            try
            {
                var exist = this.userContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                if (exist == null)
                {
                    user.Password = EncryptPassword(user.Password);
                    this.userContext.Users.Add(user);
                    await this.userContext.SaveChangesAsync();
                    return "Registration Successful";
                }
                else
                {
                    return "Registration is failed";
                }
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
                    login.Password = EncryptPassword(login.Password);
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
        public string EncryptPassword(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public string ForgotPassword(string email)
        {
            try
            {
                // Check Email is in Database or Not
                var userCheck = this.userContext.Users
                                    .Where(e => e.Email == email).FirstOrDefault();

                //If Email is in Database or not so it will return message accordingly
                if (userCheck != null)
                {
                    MessageQueue msgqueue;
                    if (MessageQueue.Exists(@".\Private$\MailQueue"))
                    {
                        msgqueue = new MessageQueue(@".\Private$\MailQueue");
                    }
                    else
                    {
                        msgqueue = MessageQueue.Create(@".\Private$\MailQueue");
                    }
                    Message message = new Message();
                    message.Formatter = new BinaryMessageFormatter();
                    message.Body = email;

                    msgqueue.Label = "Mail";
                    msgqueue.Send(message);
                    SendEmail(email);

                    return "Send Email Successfully";
                }
                else
                {
                    return "Email Id Is not Valid";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void SendEmail(string email)
        {
            try
            {
                MessageQueue msgqueue;
                if (MessageQueue.Exists(@".\Private$\MailQueue"))
                    msgqueue = new MessageQueue(@".\Private$\MailQueue");

                else
                    msgqueue = MessageQueue.Create(@".\Private$\MailQueue");

                var receiveQueue = new MessageQueue(@".\Private$\MailQueue");
                var receiveMsg = receiveQueue.Receive();
                receiveMsg.Formatter = new BinaryMessageFormatter();

                MailMessage mail = new MailMessage();
                mail.Body = "Reset Password link : www.reset-password.link";
                mail.From = new MailAddress("bhargavinadimpalli423@gmail");
                mail.To.Add(email);
                mail.Subject = "Test Mail";

                //Credintials
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("bhargavinadimpalli423@gmail", "Bhagi@1234");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }


        public async Task<string> ResetPassword(LoginDetails resetpassword)
        {
            try
            {
                var user = this.userContext.Users.Where(x => x.Email == resetpassword.Email).FirstOrDefault();
                if (user != null)
                {
                   
                    user.Password = resetpassword.Password;
                    await this.userContext.SaveChangesAsync();                      
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
        public string GenerateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}


                    
