using FundooModels;
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

        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == true).ToList();
                if (exists != null)
                {
                    return exists;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> UpdateNotes(NotesModel model)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == model.NotesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Notes = model.Notes;
                    exists.Title = model.Title;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Note Updated Successfully !";
                }

                return "Note is Not present. Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
       public async Task<string> UpdateColor(int noteId, string color)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (exists != null)
                {
                    if (color != null)
                    {
                        exists.Color = color;
                        this.userContext.notes.Update(exists);
                        await this.userContext.SaveChangesAsync();
                        return "Color Added Successfully !";
                    }
                    else
                    {
                        return "Color not Added Successfully !";
                    }
                }

                return "Note Not present! Add Note";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> SetRemainder(int notesId, string remainder)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Remainder = remainder;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Remainder is Set";
                }

                return "Remainder failed";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteRemainder(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (exists != null)
                {
                    exists.Remainder = null;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                    return "Removed Remainder !";
                }

                return "Note not present!";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> AddPin(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Unpin Note";
                    }
                    else
                    {
                        exists.Is_Pin = true;
                        message = "Pinned";
                        if (exists.Is_Archive == true)
                        {
                            exists.Is_Archive = false;
                            message = "Note unarchived and pinned";
                        }
                    }

                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is not present! Add Note";
                }

                return message;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> AddArchive(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Archive == true)
                    {
                        exists.Is_Archive = false;
                        message = "Note unarchived";
                    }
                    else
                    {
                        exists.Is_Archive = true;
                        message = "Note archived";
                        if (exists.Is_Pin == true)
                        {
                            exists.Is_Pin = false;
                            message = "Note unpinned and archived";
                        }
                    }

                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is Not present! Add Note";
                }

                return message;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteNoteAddToTrash(int notesId)
        {
            try
            {
                var exists = this.userContext.notes.Where(x => x.NotesId == notesId && x.Is_Trash == false).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    exists.Is_Trash = true;
                    message = "Note trashed";

                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Note unpinned and trashed";
                    }

                    exists.Remainder = null;
                    this.userContext.notes.Update(exists);
                    await this.userContext.SaveChangesAsync();
                }
                else
                {
                    message = "Note is Not present! Add Note";
                }

                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
