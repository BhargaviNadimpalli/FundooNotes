// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using Experimental.System.Messaging; 
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;  

    /// <summary>
    /// class user repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interface.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// UserContext userContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// returns string after registering user
        /// </returns>
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

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// returns string after login user
        /// </returns>
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

        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>returns string after encrypt password</returns>
        public string EncryptPassword(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// returns string after forgot password
        /// </returns>
        public string ForgotPassword(string email)
        {
            try
            {
                var userCheck = this.userContext.Users
                                    .Where(e => e.Email == email).FirstOrDefault();
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

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="email">The email.</param>
        public void SendEmail(string email)
        {
            try
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

                var receiveQueue = new MessageQueue(@".\Private$\MailQueue");
                var receiveMsg = receiveQueue.Receive();
                receiveMsg.Formatter = new BinaryMessageFormatter();
                MailMessage mail = new MailMessage();
                mail.Body = "Reset Password link : www.reset-password.link";
                mail.From = new MailAddress("bhargavinadimpalli423@gmail");
                mail.To.Add(email);
                mail.Subject = "Test Mail";
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

        /// <summary>
        /// Reset the password.
        /// </summary>
        /// <param name="resetpassword">The reset password.</param>
        /// <returns>
        /// returns string after reset password
        /// </returns>
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
    }
}
