using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel.DomainClasses
{
    public class WageType
    {
        [Key]
        public long wgtVCodeInt { get; set; }
        [Column(TypeName = ("NVARCHAR(500)"))]
        public string wgtTitleStr { get; set; }
        public string wgtStatusInt { get; set; }
        public string wgtInsertDate { get; set; }
    }
}
