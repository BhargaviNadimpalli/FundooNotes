using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
   public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;
        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task<string> AddNotes(NotesModel model)
        {

            try
            {
                if (model.Title != null || model.Notes != null)
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
    }
}
