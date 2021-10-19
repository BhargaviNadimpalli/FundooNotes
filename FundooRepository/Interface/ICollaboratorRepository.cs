// <copyright file="IcollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModels;

    /// <summary>
    /// Interface collaborator repository
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns>returns string after adding collaborator</returns>
        Task<string> AddCollaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="colId">The col identifier.</param>
        /// <returns>returns string after removing collaborator</returns>
        Task<string> RemoveCollaborator(int colId);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>returns string after getting collaborator</returns>
        List<string> GetCollaborator(int noteId);
    }
}
