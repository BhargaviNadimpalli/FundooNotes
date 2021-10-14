﻿using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
