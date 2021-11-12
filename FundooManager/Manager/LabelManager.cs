// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModels;
    using FundooRepository.Interface;
  
    /// <summary>
    /// class label manager
    /// </summary>
    /// <seealso cref="FundooManager.Interface.ILabelManager" />
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// ILabelRepository repository
        /// </summary>
        private readonly ILabelRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// returns string after adding label
        /// </returns>
        public Task<string> AddLabel(LabelModel labelModel)
        {
            try
            {
                return this.repository.AddLabel(labelModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// returns string after deleting label
        /// </returns>
        public Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                return this.repository.DeleteLabel(userId, labelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Edits the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>
        /// returns string after editing label
        /// </returns>
        public Task<string> EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                return this.repository.EditLabel(userId, labelName, newLabelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Removes the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// returns string after removing label using labelId
        /// </returns>
        public Task<string> RemoveLabelUsingLabelId(int labelId)
        {
            try
            {
                return this.repository.RemoveLabelUsingLabelId(labelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Removes the label using note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// returns string after removing label using noteId
        /// </returns>
        public Task<string> RemoveLabelUsingNoteId(int noteId)
        {
            try
            {
                return this.repository.RemoveLabelUsingNoteId(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns string after getting label using userId
        /// </returns>
        public List<LabelModel> GetLabelUsingUserId(int userId)
        {
            try
            {
                return this.repository.GetLabelUsingUserId(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>
        /// returns string after getting label using labelId
        /// </returns>
        public List<LabelModel> GetLabelUsingLabelId(int labelId)
        {
            try
            {
                return this.repository.GetLabelUsingLabelId(labelId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        /// returns string after getting label using noteId
        /// </returns>
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                return this.repository.GetLabelByNoteId(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Adds the label without note identifier.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// returns string after adding label without noteId
        /// </returns>
        public Task<string> AddLabelwithoutNoteId(LabelModel labelModel)
        {
            try
            {
                return this.repository.AddLabelwithoutNoteId(labelModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Edits the label with note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>
        /// returns string after editing label with noteId
        /// </returns>
        public Task<string> EditLabelWithNoteId(int noteId, string labelName, string newLabelName)
        {
            try
            {
                return this.repository.EditLabelWithNoteId(noteId, labelName, newLabelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
