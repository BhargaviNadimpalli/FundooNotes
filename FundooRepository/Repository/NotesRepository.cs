// <copyright file="NotesRepository.cs" company="Bridgelabz">
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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// class notes repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interface.INotesRepository" />
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// UserContext userContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// IConfiguration configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        /// <param name="configuration">The configuration.</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns string after adding note
        /// </returns>
        public async Task<string> AddNotes(NotesModel model)
        {
            try
            {
                if (model.Title != null || model.Notes != null || model.Remainder != null)
                {
                    this.userContext.notes.Add(model);
                    await this.userContext.SaveChangesAsync();
                    return "Note Added Successfully !";
                }
                else
                {
                    return "Note is Not Added !";
                }
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
        public async Task<string> UpdateNotes(NotesModel model)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == model.NotesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Notes = model.Notes;
                    exists.Title = model.Title;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Note Updated Successfully !";
                }

                return "Note is Not present. Add Note";
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
        public async Task<string> UpdateColor(int noteId, string color)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (exists != null)
                {
                    if (color != null)
                    {
                        exists.Color = color;
                        this.userContext.notes.Update(exists);
                        await this.userContext.SaveChangesAsync();
                        return "Color Added Successfully !";
                    }
                    else
                    {
                        return "Color not Added Successfully !";
                    }
                }

                return "Note Not present! Add Note";
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
        /// returns string after set remainder
        /// </returns>
        public async Task<string> SetRemainder(int notesId, string remainder)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Remainder = remainder;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Remainder is Set";
                }

                return "Remainder failed";
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
        public async Task<string> DeleteRemainder(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Remainder = null;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Removed Remainder !";
                }

                return "Note not present!";
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
        public async Task<string> UpdatePin(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Unpin Note";
                    }
                    else
                    {
                        exists.Is_Pin = true;
                        message = "Pinned";
                        if (exists.Is_Archive == true)
                        {
                            exists.Is_Archive = false;
                            message = "Note unarchived and pinned";
                        }
                    }

                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is not present! Add Note";
                }

                return message;
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
        public async Task<string> UpdateArchive(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Archive == true)
                    {
                        exists.Is_Archive = false;
                        message = "Note unarchived";
                    }
                    else
                    {
                        exists.Is_Archive = true;
                        message = "Note archived";
                        if (exists.Is_Pin == true)
                        {
                            exists.Is_Pin = false;
                            message = "Note unpinned and archived";
                        }
                    }

                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is Not present! Add Note";
                }

                return message;
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
        /// returns string after deleting note adding to trash
        /// </returns>
        public async Task<string> DeleteNoteAddToTrash(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId && x.Is_Trash == false).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    exists.Is_Trash = true;
                    message = "Note trashed";

                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Note unpinned and trashed";
                    }

                    exists.Remainder = null;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is Not present! Add Note";
                }

                return message;
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
        public async Task<string> RestoreFromTrash(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId && x.Is_Trash == true).SingleOrDefault();
                if (exists != null)
                {
                    exists.Is_Trash = false;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Removed from trash !";
                }

                return "Note is not present in trash";
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
                var exists = this.userContext.notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == true).ToList();
                if (exists != null)
                {
                    return exists;
                }

                return null;
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
        /// returns string after getting remainder note
        /// </returns>
        public List<NotesModel> GetRemainderNotes(int userId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Remainder != null).ToList();
                if (exists != null)
                {
                    return exists;
                }

                return null;
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
        /// returns string after getting archive note
        /// </returns>
        public List<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == true).ToList();
                if (exists != null)
                {
                    return exists;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
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
                var exists = this.userContext.notes.Where(x => x.UserId == userId && x.Is_Trash == true).ToList();
                if (exists != null)
                {
                    return exists;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
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
                var noteData = this.userContext.notes.Find(notesId);
                if (noteData != null)
                {
                    Account account = new Account(this.configuration["CloudinaryAccount:CloudName"], this.configuration["CloudinaryAccount:ApiKey"], this.configuration["CloudinaryAccount:ApiSecret"]);
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    noteData.Image = uploadResult.Url.ToString();
                    this.userContext.SaveChanges();
                    return "Image added successfully";
                }

                return "Image is not added";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
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
                var noteData = this.userContext.notes.Find(notesId);
                if (noteData != null)
                {
                    noteData.Image = null;
                    this.userContext.SaveChanges();

                    return "Image deleted successfully";
                }

                return "Image is not deleted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
