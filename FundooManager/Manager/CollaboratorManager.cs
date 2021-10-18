using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository repository;
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return this.repository.AddCollaborator(collaborator);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> GetCollaborator(int noteId)
        {
            try
            {
                return this.repository.GetCollaborator(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string RemoveCollaborator(int colId)
        {
            try
            {
                return this.repository.RemoveCollaborator(colId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
