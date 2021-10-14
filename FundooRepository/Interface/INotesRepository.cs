using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Interface
{
   public interface INotesRepository
    {
        Task<string> AddNotes(NotesModel model);
    }
}
