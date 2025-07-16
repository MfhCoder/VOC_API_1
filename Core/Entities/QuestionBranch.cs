using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class QuestionBranch : BaseEntity
    {
        public int ParentQuestionId { get; set; }
        public SurveyQuestion ParentQuestion { get; set; }
        public int? TriggerOptionId { get; set; }
        public QuestionOption TriggerOption { get; set; }
    }
}
