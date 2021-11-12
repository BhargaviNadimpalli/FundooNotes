// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    /// <summary>
    /// class notes controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// INotesManager manager
        /// </summary>
        private readonly INotesManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns a IActionResult as status code when data added successfully</returns>
        [HttpPost]
        [Route("api/addNote")] 
        public async Task<IActionResult> AddNotes([FromBody] NotesModel model)
        {
            try
            {
                string result = await this.manager.AddNotes(model);
                if (result.Equals("Note Added Successfully !"))
                {
                    return this.Ok(new { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns a IActionResult as status code when data updated successful</returns>
        [HttpPut]
        [Route("api/updateNote")]
        public async Task<IActionResult> UpdateNotes([FromBody] NotesModel model)
        {
            try
            {
                string result = await this.manager.UpdateNotes(model);
                if (result == "Note Updated Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns a IActionResult as status code when data exists</returns>
        [HttpGet]
        [Route("api/getNotes")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                List<NotesModel> notes = this.manager.GetNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Retrieved notes successful! ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No Notes present" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the color.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>returns a IActionResult as status code when color updated successful</returns>
        [HttpPut]
        [Route("api/UpdateColor")]
        public async Task<IActionResult> UpdateColor(int noteId, string color)
        {
            try
            {
                string result = await this.manager.UpdateColor(noteId, color);
                if (result == "Color Added Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns>returns a IActionResult as status code when remainder is set</returns>
        [HttpPost]
        [Route("api/Remainder")]
        public async Task<IActionResult> SetRemainder(int notesId, string remainder)
        {
            try
            {
                string result = await this.manager.SetRemainder(notesId, remainder);
                if (result == "Remainder is Set")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns a IActionResult as status code when remainder deleted</returns>
        [HttpPut]
        [Route("api/deleteRemainder")]
        public async Task<IActionResult> DeleteRemainder(int notesId)
        {
            try
            {
                string result = await this.manager.DeleteRemainder(notesId);
                if (result == "Removed Remainder !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the pin.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns a IActionResult as status code when pin updated</returns>
        [HttpPut]
        [Route("api/addPin")]
        public async Task<IActionResult> UpdatePin(int notesId)
        {
            try
            {
                string result = await this.manager.UpdatePin(notesId);
                if (result != "Note is Not present! Add Note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                { 
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds the archive.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns a IActionResult as status code when data added archive</returns>
        [HttpPut]
        [Route("api/archive")]
        public async Task<IActionResult> AddArchive(int notesId)
        {
            try
            {
                string result = await this.manager.UpdateArchive(notesId);
                if (result != "Note is Not present! Add Note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the note add to trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns a IActionResult as status code when data deleted and added to trash</returns>
        [HttpPut]
        [Route("api/Trash")]
        public async Task<IActionResult> DeleteNoteAddToTrash(int notesId)
        {
            try
            {
                string result = await this.manager.DeleteNoteAddToTrash(notesId);
                if (result != "Note is Not present! Add Note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the remainder notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns a IActionResult as status code when remainder note exists</returns>
        [HttpPost]
        [Route("api/GetRemainderNotes")]
        public IActionResult GetRemainderNotes(int userId)
        {
            try
            {
                var result = this.manager.GetRemainderNotes(userId);

                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Retrieved Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the archive notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns a IActionResult as status code when archive note exists</returns>
        [HttpGet]
        [Route("api/GetArchiveNotes")]
        public IActionResult GetArchiveNotes(int userId)
        {
            try
            {
                var result = this.manager.GetArchiveNotes(userId);

                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Retrieved Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the trash notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns a IActionResult as status code when trash note exists</returns>
        [HttpGet]
        [Route("api/GetTrashNotes")]
        public IActionResult GetTrashNotes(int userId)
        {
            try
            {
                var result = this.manager.GetTrashNotes(userId);

                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Retrieved Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieval Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="image">The image.</param>
        /// <returns>returns a IActionResult as status code when image added</returns>
        [HttpPost]
        [Route("Image")]
        public IActionResult AddImage(int notesId, IFormFile image)
        {
            try
            {                
                var result = this.manager.AddImage(notesId, image);

                if (result.Equals("Image added successfully"))
                {
                    return this.Ok(new { Success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = result });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// Removes the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>returns a IActionResult as status code when image deleted</returns>
        [HttpDelete]
        [Route("Image")]
        public IActionResult RemoveImage(int notesId)
        {
            try
            {
                var result = this.manager.RemoveImage(notesId);

                if (result.Equals("Image deleted successfully"))
                {
                    return this.Ok(new { Success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = result });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
