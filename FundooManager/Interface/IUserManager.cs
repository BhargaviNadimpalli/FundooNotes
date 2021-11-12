// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooManager.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModels;

    /// <summary>
    /// interface user manager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>returns string after registering user</returns>
        Task<string> Register(UserModel user);

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>returns string after login user</returns>
        string Login(LoginDetails login);

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns string after forget password</returns>
        string ForgotPassword(string email);

        /// <summary>
        /// Reset the password.
        /// </summary>
        /// <param name="resetpassword">The reset password.</param>
        /// <returns>returns string after reset password</returns>
        Task<string> ResetPassword(LoginDetails resetpassword);

        /// <summary>
        /// Generate the token.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns>returns string after generating token</returns>
        string GenerateToken(string Email);
    }
}
