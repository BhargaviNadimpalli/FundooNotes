using FundooManager.Interface;
using FundooModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class NotesController : ControllerBase
    {

        private readonly INotesManager manager;

        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }

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
        [HttpPut]
        [Route("api/restoreTrash")]
        public async Task<IActionResult> RestoreFromTrash(int notesId)
        {
            try
            {
                string result = await this.manager.RestoreFromTrash(notesId);
                if (result != "Note is not present in trash")
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

        [HttpPost]
        [Route("api/GetRemainderNotes")]
        public IActionResult GetRemainderNotes(int userId)
        {
            try
            {
                var result = this.manager.GetRemainderNotes(userId);

                if (result.Count > 0)
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


        [HttpPost]
        [Route("api/GetArchiveNotes")]
        public IActionResult GetArchiveNotes(int userId)
        {
            try
            {
                var result = this.manager.GetArchiveNotes(userId);

                if (result.Count > 0)
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

        [HttpPost]
        [Route("api/GetTrashNotes")]
        public IActionResult GetTrashNotes(int userId)
        {
            try
            {
                var result = this.manager.GetTrashNotes(userId);

                if (result.Count > 0)
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
        [HttpPost]
        [Route("Image")]
        public IActionResult AddImage(int notesId, IFormFile image)
        {
            try
            {
                
                var result = this.manager.AddImage(notesId, image);

                if (result.Equals("Image added successfully"))
                {
                    return Ok(new { Success = true, message = result });
                }
                else
                {
                    return BadRequest(new { Success = false, message = result });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });

            }
        }
        [HttpDelete]
        [Route("Image")]
        public IActionResult RemoveImage(int notesId)
        {
            try
            {
                var result = this.manager.RemoveImage(notesId);

                if (result.Equals("Image deleted successfully"))
                {
                    return Ok(new { Success = true, message = result });
                }
                else
                {
                    return BadRequest(new { Success = false, message = result });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });


            }
        }
    }
}
