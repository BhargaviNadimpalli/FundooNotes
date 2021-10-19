// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
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
    /// Interface label manager
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>returns string after adding label</returns>
        Task<string> AddLabel(LabelModel labelModel);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>returns string after deleting label</returns>
        Task<string> DeleteLabel(int userId, string labelName);

        /// <summary>
        /// Edits the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>returns string after editing label</returns>
        Task<string> EditLabel(int userId, string labelName, string newLabelName);

        /// <summary>
        /// Removes the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>returns string after removing label using labelId</returns>
        Task<string> RemoveLabelUsingLabelId(int labelId);

        /// <summary>
        /// Removes the label using note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>returns string after removing label using noteId</returns>
        Task<string> RemoveLabelUsingNoteId(int noteId);

        /// <summary>
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string after getting label using userId</returns>
        List<LabelModel> GetLabelUsingUserId(int userId);

        /// <summary>
        /// Gets the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>returns string after getting label using labelId</returns>
        List<LabelModel> GetLabelUsingLabelId(int labelId);

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>returns string after getting label using noteId</returns>
        List<LabelModel> GetLabelByNoteId(int noteId);
    }
}
