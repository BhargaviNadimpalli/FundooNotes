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

        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                return this.repository.DeleteLabel(userId, labelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                return this.repository.EditLabel(userId, labelName, newLabelName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> GetLabel(int userId)
        {
            try
            {
                return this.repository.GetLabel(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
