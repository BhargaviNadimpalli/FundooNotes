using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
   public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel collaborator);

        string RemoveCollaborator(int colId);

        List<string> GetCollaborator(int noteId);

    }
}
