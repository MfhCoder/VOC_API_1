using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SurveyFilters : BaseEntity
    {  
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

    }
}
