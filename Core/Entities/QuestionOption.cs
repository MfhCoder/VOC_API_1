using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class QuestionOption : BaseEntity
    {
        public int QuestionId { get; set; }
        public SurveyQuestion Question { get; set; }

        public string OptionText { get; set; }
        public bool IsTerminate { get; set; } = false;
        public bool TriggersBranch { get; set; } = false;

        public ICollection<QuestionBranch> TriggeredBranches { get; set; }
        public ICollection<FeedbackAnswer> Answers { get; set; }
    }
}
