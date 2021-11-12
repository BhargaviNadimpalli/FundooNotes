// <copyright file="LabelRepository.cs" company="Bridgelabz">
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
    using FundooModels;  
    using FundooRepository.Context;
    using FundooRepository.Interface;
   
    /// <summary>
    /// class label repository
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// UserContext userContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        ///  Initializes a new instance of the <see cref="LabelRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// returns string after adding label
        /// </returns>
        public async Task<string> AddLabel(LabelModel labelModel)
        {
            try
            {
                var exist = this.userContext.labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId && x.NotesId != null).SingleOrDefault();
                if (exist == null)
                {
                    this.userContext.labels.Add(labelModel);
                    await this.userContext.SaveChangesAsync();
                    return "Added Label";
                }

                return "Label Already Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
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
        public async Task<string> DeleteLabel(int userId, string labelName)
        {
            try
            {
                var exists = this.userContext.labels.Where(x => x.LabelName == labelName && x.UserId == userId).FirstOrDefault();
                if (exists != null)
                {
                    this.userContext.labels.Remove(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Deleted Label";
                }

                return "No Label Present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
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
        public async Task<string> EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                var exist = this.userContext.labels.Where(x => x.LabelName == labelName && x.UserId == userId).SingleOrDefault();
                if (exist != null)
                {
                    exist.LabelName = newLabelName;
                    this.userContext.labels.Update(exist);
                    await this.userContext.SaveChangesAsync();

                    return "Updated Label";
                }

                return "Label not present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove the Label Using LabelId
        /// </summary>
        /// <param name="labelId">The label Id</param>
        /// <returns>returns string after removing label using labelId</returns>
        public async Task<string> RemoveLabelUsingLabelId(int labelId)
        {
            try
            {
                var noteLabel = this.userContext.labels.Where(x => x.LabelId == labelId).SingleOrDefault();
                if (noteLabel != null)
                {
                    this.userContext.labels.Remove(noteLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Label is removed";
                }

                return "Remove label failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove the Label Using NoteId
        /// </summary>
        /// <param name="noteId">The note Id</param>
        /// <returns>returns string after removing label using noteId</returns>
        public async Task<string> RemoveLabelUsingNoteId(int noteId)
        {
            try
            {
                var noteLabel = this.userContext.labels.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (noteLabel != null)
                {
                    this.userContext.labels.Remove(noteLabel);
                    await this.userContext.SaveChangesAsync();
                    return "Label is removed";
                }

                return "Remove label failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
           
        /// <summary>
        /// Get the Label Using UserId
        /// </summary>
        /// <param name="userId">The user Id</param>
        /// <returns>returns string after getting label using userId</returns>
        public List<LabelModel> GetLabelUsingUserId(int userId)
        {
            try
            {
                var listLabel = this.userContext.labels.Where(label => userId == label.UserId).ToList();
                if (listLabel.Count != 0)
                {
                    return listLabel;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the Label Using LabelId
        /// </summary>
        /// <param name="labelId">The label Id</param>
        /// <returns>returns string after getting label using labelId</returns>
        public List<LabelModel> GetLabelUsingLabelId(int labelId)
        {
            try
            {
                var listLabel = this.userContext.labels.Where(label => labelId == label.LabelId).ToList();
                if (listLabel.Count != 0)
                {
                    return listLabel;
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the Label By NoteId
        /// </summary>
        /// <param name="noteId">The note Id</param>
        /// <returns>returns string after getting label using noteId</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                var label = this.userContext.labels.Where(x => x.NotesId == noteId).ToList();
                if (label.Count != 0)
                {
                    return label;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add label without note id
        /// </summary>
        /// <param name="labelModel">The label model</param>
        /// <returns>returns string after adding label without noteId</returns>
        public async Task<string> AddLabelwithoutNoteId(LabelModel labelModel)
        {
            try
            {
                var exist = this.userContext.labels.Any(x => x.LabelName == labelModel.LabelName);
                
                if (!exist)
                {
                    if (labelModel.UserId > 0 && labelModel.LabelName != null && labelModel.NotesId == null)
                    {
                        this.userContext.labels.Add(labelModel);
                        await this.userContext.SaveChangesAsync();
                        return "Added Label";
                    }

                    return "Label not added";
                }

                return "Label Already Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit label with noteId
        /// </summary>
        /// <param name="noteId">The noteId</param>
        /// <param name="labelName">The label name</param>
        /// <param name="newLabelName">The new label name</param>
        /// <returns>returns string after editing label with noteId</returns>
        public async Task<string> EditLabelWithNoteId(int noteId, string labelName, string newLabelName)
        {
            try
            {
                var exist = this.userContext.labels.Where(x => x.LabelName == labelName && x.NotesId == noteId).SingleOrDefault();
                if (exist != null)
                {
                    exist.LabelName = newLabelName;
                    this.userContext.labels.Update(exist);
                    await this.userContext.SaveChangesAsync();

                    return "Updated Label";
                }

                return "Label not present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
