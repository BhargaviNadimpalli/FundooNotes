// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModels;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// interface notes repository
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string after adding note</returns>
        Task<string> AddNotes(NotesModel model);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string after updating note</returns>
        Task<string> UpdateNotes(NotesModel model);

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string after getting note</returns>
        List<NotesModel> GetNotes(int userId);

        /// <summary>
        /// Updates the color.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>returns string after updating color</returns>
        Task<string> UpdateColor(int noteId, string color);

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns>returns string after set remainder</returns>
        Task<string> SetRemainder(int notesId, string remainder);

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns string after deleting remainder</returns>
        Task<string> DeleteRemainder(int notesId);

        /// <summary>
        /// Updates the pin.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns string after updating pin</returns>
        Task<string> UpdatePin(int notesId);

        /// <summary>
        /// Updates the archive.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns string after updating archive</returns>
        Task<string> UpdateArchive(int notesId);

        /// <summary>
        /// Deletes the note add to trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns string after deleting note adding to trash</returns>
        Task<string> DeleteNoteAddToTrash(int notesId);

        /// <summary>
        /// Gets the remainder notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string after getting remainder note</returns>
        List<NotesModel> GetRemainderNotes(int userId);

        /// <summary>
        /// Gets the archive notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string after getting archive note</returns>
        List<NotesModel> GetArchiveNotes(int userId);

        /// <summary>
        /// Gets the trash notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string after getting trash note</returns>
        List<NotesModel> GetTrashNotes(int userId);

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="image">The image.</param>
        /// <returns>returns string after adding image</returns>
        string AddImage(int notesId, IFormFile image);

        /// <summary>
        /// Removes the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns string after removing image</returns>
        string RemoveImage(int notesId);
    }
}
