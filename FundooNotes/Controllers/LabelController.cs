// <copyright file="LabelController.cs" company="Bridgelabz">
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
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// class label controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// ILabelManager manager
        /// </summary>
        private readonly ILabelManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public LabelController(ILabelManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPost]
        [Route("api/addLabel")]
        public async Task<IActionResult> AddLabel([FromBody] LabelModel label)
        {
            try
            {
                string result = await this.manager.AddLabel(label);
                if (result == "Added Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpDelete]
        [Route("api/deleteLabel")]
        public async Task<IActionResult> DeleteLabel(int userId, string labelName)
        {
            try
            {
                string result = await this.manager.DeleteLabel(userId, labelName);
                if (result == "Deleted Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edits the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPut]
        [Route("api/editLabel")]
        public async Task<IActionResult> EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                string result = await this.manager.EditLabel(userId, labelName, newLabelName);
                if (result != "Label not present")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Removes the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpDelete]
        [Route("api/removeLabelUsingLabelId")]
        public async Task<IActionResult> RemoveLabelUsingLabelId(int labelId)
        {
            try
            {
                string result = await this.manager.RemoveLabelUsingLabelId(labelId);
                if (result == "Label is removed")
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
        /// Removes the label using note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpDelete]
        [Route("api/removeLabelusingNoteId")]
        public async Task<IActionResult> RemoveLabelUsingNoteId(int noteId)
        {
            try
            {
                string result = await this.manager.RemoveLabelUsingNoteId(noteId);
                if (result == "Label is removed")
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
        /// Gets the label using user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpGet]
        [Route("api/GetLabelUsingUserId")]
        public IActionResult GetLabelUsingUserId(int userId)
        {
            try
            {
                List<LabelModel> result = this.manager.GetLabelUsingUserId(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the label using label identifier.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpGet]
        [Route("api/GetLabelUsingLabelId")]
        public IActionResult GetLabelUsingLabelId(int labelId)
        {
            try
            {
                List<LabelModel> result = this.manager.GetLabelUsingLabelId(labelId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpGet]
        [Route("api/GetLabelByNoteId")]
        public IActionResult GetLabelByNoteId(int noteId)
        {
            try
            {
                List<LabelModel> result = this.manager.GetLabelByNoteId(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<LabelModel>>() { Status = true, Message = "Retrieved Label", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<List<LabelModel>>() { Status = false, Message = "Couldn't retrieve", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds the label without note identifier.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPost]
        [Route("api/addLabelwithoutNoteId")]
        public async Task<IActionResult> AddLabelwithoutNoteId([FromBody] LabelModel labelModel)
        {
            try
            {
                string result = await this.manager.AddLabelwithoutNoteId(labelModel);
                if (result == "Added Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edits the label with note identifier.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPut]
        [Route("api/editLabelwithNoteId")]
        public async Task<IActionResult> EditLabelWithNoteId(int noteId, string labelName, string newLabelName)
        {
            try
            {
                string result = await this.manager.EditLabel(noteId, labelName, newLabelName);
                if (result != "Label not present")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
