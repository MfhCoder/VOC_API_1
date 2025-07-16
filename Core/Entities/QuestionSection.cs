using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class QuestionSection : BaseEntity
    {
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string Title { get; set; }
        public int SectionOrder { get; set; }

        public ICollection<SurveyQuestion> Questions { get; set; }
    }
}
