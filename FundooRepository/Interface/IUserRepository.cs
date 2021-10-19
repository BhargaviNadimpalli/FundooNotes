// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interface
{
    using System.Threading.Tasks;
    using FundooModels;

    /// <summary>
    /// interface user repository
    /// </summary>
    public interface IUserRepository
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
        /// <returns>returns string after forgot password</returns>
        string ForgotPassword(string email);

        /// <summary>
        /// Reset the password.
        /// </summary>
        /// <param name="resetpassword">The reset password.</param>
        /// <returns>returns string after reset password</returns>
        Task<string> ResetPassword(LoginDetails resetpassword);
    }
}
