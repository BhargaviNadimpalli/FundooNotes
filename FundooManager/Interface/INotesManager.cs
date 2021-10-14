using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
   public interface INotesManager
    {
        Task<string> AddNotes(NotesModel model);

        Task<string> UpdateNotes(NotesModel model);
        List<NotesModel> GetNotes(int userId);

        Task<string> UpdateColor(int noteId, string color);
    }
}
