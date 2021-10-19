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
                var exist = this.userContext.labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId).SingleOrDefault();
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
    }
}
