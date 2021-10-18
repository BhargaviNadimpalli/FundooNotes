using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        public readonly UserContext userContext;

        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                var exist = this.userContext.labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId).SingleOrDefault();
                if (exist == null)
                {
                    this.userContext.labels.Add(labelModel);
                    this.userContext.SaveChanges();
                    return "Added Label";
                }

                return "Label Already Exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                var exists = this.userContext.labels.Where(x => x.LabelName == labelName && x.UserId == userId).ToList();
                if (exists.Count > 0)
                {
                    this.userContext.labels.RemoveRange(exists);
                    this.userContext.SaveChanges();
                    return "Deleted Label";
                }

                return "No Label Present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
