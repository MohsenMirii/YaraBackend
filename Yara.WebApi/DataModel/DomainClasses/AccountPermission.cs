using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.DomainClasses
{
    public partial class AccountPermission
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long PermissionId { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
