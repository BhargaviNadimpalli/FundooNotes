using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {

        public readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                string message = string.Empty;
                var emailExists = this.userContext.Users.Where(x => x.Email == collaborator.ColEmail).SingleOrDefault();
                if (emailExists != null)
                {
                    var owner = (from user in this.userContext.Users
                                 join notes in this.userContext.notes
                                 on user.UserId equals notes.UserId
                                 where notes.NotesId == collaborator.NotesId && user.Email == collaborator.ColEmail
                                 select new { userId = user.UserId }).SingleOrDefault();
                    if (owner == null)
                    {
                        var colExists = this.userContext.collaborators.Where(x => x.ColEmail == collaborator.ColEmail && x.NotesId == collaborator.NotesId).SingleOrDefault();
                        if (colExists == null)
                        {
                            this.userContext.Add(collaborator);
                            this.userContext.SaveChanges();
                            message = "Collaborator Added!";
                        }
                        else
                        {
                            message = "This email already exists";
                        }
                    }
                    else
                    {
                        message = "This email already exists";
                    }
                }
                else
                {
                    message = "Invalid Email";
                }

                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveCollaborator(int colId)
        {
            try
            {
                var colExists = this.userContext.collaborators.Where(x => x.ColId == colId).FirstOrDefault();
                if (colExists != null)
                {
                    this.userContext.collaborators.Remove(colExists);
                    this.userContext.SaveChanges();
                    return "Removed Collaborator";
                }

                return "Cant Remove Collaborator";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
