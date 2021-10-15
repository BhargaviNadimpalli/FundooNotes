
using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }
      

        public Task<string> AddNotes(NotesModel model)
        {

            try
            {
                return this.repository.AddNotes(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                return this.repository.GetNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> UpdateNotes(NotesModel model)
        {
            try
            {
                return this.repository.UpdateNotes(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<string> UpdateColor(int noteId, string color)
        {
            try
            {
                return this.repository.UpdateColor(noteId, color);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> SetRemainder(int notesId, string remainder)
        {
            try
            {
                return this.repository.SetRemainder(notesId, remainder);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> DeleteRemainder(int notesId)
        {
            try
            {
                return this.repository.DeleteRemainder(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> AddPin(int notesId)
        {
            try
            {
                return this.repository.AddPin(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> AddArchive(int notesId)
        {
            try
            {
                return this.repository.AddArchive(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> DeleteNoteAddToTrash(int notesId)
        {
            try
            {
                return this.repository.DeleteNoteAddToTrash(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}