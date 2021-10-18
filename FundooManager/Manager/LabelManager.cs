using FundooManager.Interface;
using FundooModels;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository repository;
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                return this.repository.AddLabel(labelModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
