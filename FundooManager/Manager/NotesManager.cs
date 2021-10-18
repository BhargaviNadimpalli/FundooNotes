
using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using Microsoft.AspNetCore.Http;
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

        public Task<string> UpdatePin(int notesId)
        {
            try
            {
                return this.repository.UpdatePin(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> UpdateArchive(int notesId)
        {
            try
            {
                return this.repository.UpdateArchive(notesId);
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

        public Task<string> RestoreFromTrash(int notesId)
        {
            try
            {
                return this.repository.RestoreFromTrash(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<NotesModel> GetRemainderNotes(int userId)
        {

            try
            {
                return this.repository.GetRemainderNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                return this.repository.GetArchiveNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<NotesModel> GetTrashNotes(int userId)
        {
            try
            {
                return this.repository.GetTrashNotes(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string AddImage(int notesId, IFormFile image)
        {
            try
            {
                return this.repository.AddImage(notesId, image);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string RemoveImage(int notesId)
        {
            try
            {
                return this.repository.RemoveImage(notesId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}