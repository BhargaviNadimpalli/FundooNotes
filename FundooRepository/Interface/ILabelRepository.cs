using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
   public interface ILabelRepository
    {
        string AddLabel(LabelModel labelModel);

        string DeleteLabel(int userId, string labelName);

        string EditLabel(int userId, string labelName, string newLabelName);

        List<string> GetLabel(int userId);

    }
}
