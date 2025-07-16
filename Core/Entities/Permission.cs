using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Permission : BaseEntity
    {

        public int? ModuleId { get; set; }
        public Module Module { get; set; }
        public int? SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
