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

        Task<string> SetRemainder(int notesId, string remainder);

        Task<string> DeleteRemainder(int notesId);

        Task<string> UpdatePin(int notesId);

        Task<string> UpdateArchive(int notesId);

        Task<string> DeleteNoteAddToTrash(int notesId);

        Task<string> RestoreFromTrash(int notesId);

        List<NotesModel> GetRemainderNotes(int userId);

        List<NotesModel> GetArchiveNotes(int userId);

        List<NotesModel> GetTrashNotes(int userId);
    }
}
