// <copyright file="CollaboratorController.cs" company="Bridgelabz">
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
    /// class collaborator controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// ICollaboratorManager manager
        /// </summary>
        private readonly ICollaboratorManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public CollaboratorController(ICollaboratorManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns>returns IActionResult status code after adding collaborator</returns>
        [HttpPost]
        [Route("api/addCollaborator")]
        public async Task<IActionResult> AddCollaborator([FromBody] CollaboratorModel collaborator)
        {
            try
            {
                string result = await this.manager.AddCollaborator(collaborator);
                if (result == "True")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = collaborator.SenderEmail });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="colId">The col identifier.</param>
        /// <returns>returns IActionResult status code after deleting collaborator</returns>
        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public async Task<IActionResult> RemoveCollaborator(int colId)
        {
            try
            {
                string result = await this.manager.RemoveCollaborator(colId);
                if (result == "Removed Collaborator")
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
        /// Gets the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>returns IActionResult status code after getting collaborator</returns>
        [HttpPost]
        [Route("api/getCollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                List<string> result = this.manager.GetCollaborator(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "Retrieved Collaborator", Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to retrieve" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
