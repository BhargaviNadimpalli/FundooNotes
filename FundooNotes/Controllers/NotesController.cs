using FundooManager.Interface;
using FundooModels;
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
    }
}
