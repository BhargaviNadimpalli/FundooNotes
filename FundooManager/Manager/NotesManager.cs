// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Http;
   
    /// <summary>
    /// class Notes manager
    /// </summary>
    /// <seealso cref="FundooManager.Interface.INotesManager" />
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// INotesRepository repository
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns string after adding note
        /// </returns>
        public Task<string> AddNotes(NotesModel model)
        {
            try
            {
                return this.repository.AddNotes(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns string after getting note
        /// </returns>
        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                return this.repository.GetNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns string after updating note
        /// </returns>
        public Task<string> UpdateNotes(NotesModel model)
        {
            try
            {
                return this.repository.UpdateNotes(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the color.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>
        /// returns string after updating color
        /// </returns>
        public Task<string> UpdateColor(int noteId, string color)
        {
            try
            {
                return this.repository.UpdateColor(noteId, color);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns>
        /// returns string after setting remainder
        /// </returns>
        public Task<string> SetRemainder(int notesId, string remainder)
        {
            try
            {
                return this.repository.SetRemainder(notesId, remainder);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after deleting remainder
        /// </returns>
        public Task<string> DeleteRemainder(int notesId)
        {
            try
            {
                return this.repository.DeleteRemainder(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the pin.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after updating pin
        /// </returns>
        public Task<string> UpdatePin(int notesId)
        {
            try
            {
                return this.repository.UpdatePin(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the archive.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after updating archive
        /// </returns>
        public Task<string> UpdateArchive(int notesId)
        {
            try
            {
                return this.repository.UpdateArchive(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the note add to trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after deleting note and adding to trash
        /// </returns>
        public Task<string> DeleteNoteAddToTrash(int notesId)
        {
            try
            {
                return this.repository.DeleteNoteAddToTrash(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Restores from trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after restoring from trash
        /// </returns>
        public Task<string> RestoreFromTrash(int notesId)
        {
            try
            {
                return this.repository.RestoreFromTrash(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the remainder notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns string after getting remainder notes
        /// </returns>
        public List<NotesModel> GetRemainderNotes(int userId)
        {
            try
            {
                return this.repository.GetRemainderNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the archive notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns string after getting archive notes
        /// </returns>
        public List<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                return this.repository.GetArchiveNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the trash notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns string after getting trash note
        /// </returns>
        public List<NotesModel> GetTrashNotes(int userId)
        {
            try
            {
                return this.repository.GetTrashNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="image">The image.</param>
        /// <returns>
        /// returns string after adding image
        /// </returns>
        public string AddImage(int notesId, IFormFile image)
        {
            try
            {
                return this.repository.AddImage(notesId, image);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Removes the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// returns string after removing image
        /// </returns>
        public string RemoveImage(int notesId)
        {
            try
            {
                return this.repository.RemoveImage(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}