using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<User> Users { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
