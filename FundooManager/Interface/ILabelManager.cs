using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
   public interface ILabelManager
    {
        string AddLabel(LabelModel labelModel);

        string DeleteLabel(int userId, string labelName);
    }
}
