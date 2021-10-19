// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;

    /// <summary>
    /// class collaborator repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interface.ICollaboratorRepository" />
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// UserContext userContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns>
        /// returns string after adding collaborator
        /// </returns>
        public async Task<string> AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                if (collaborator.NoteId > 0 && collaborator.ReceiverEmail != null)
                {
                    this.userContext.collaborators.Add(collaborator);
                   await this.userContext.SaveChangesAsync();
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="colId">The col identifier.</param>
        /// <returns>
        /// returns string after removing collaborator
        /// </returns>
        public async Task<string> RemoveCollaborator(int colId)
        {
            try
            {
                var colExists = this.userContext.collaborators.Where(x => x.CollaboratorId == colId).FirstOrDefault();
                if (colExists != null)
                {
                    this.userContext.collaborators.Remove(colExists);
                    await this.userContext.SaveChangesAsync();
                    return "Removed Collaborator";
                }

                return "Cant Remove Collaborator";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// returns string after getting collaborator
        /// </returns>
       public List<string> GetCollaborator(int noteId)
        {
            try
            {
                var exists = this.userContext.collaborators.Where(x => x.NoteId == noteId).Select(x => x.SenderEmail).ToList();
                if (exists.Count > 0)
                {
                    return exists;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
