using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.DomainClasses
{
    public partial class Permission
    {
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        
        [Column(Order = 1)]
        public long ParentId { get; set; }
        
        [Column(Order = 2)]
        public int Priority { get; set; }

        
        [MaxLength(1000) ,Column(Order = 3)]
        public string ActionName { get; set; }

        [MaxLength(1000), Column(Order = 4)]
        public string MenuUrl { get; set; }
        
       
        [MaxLength(1000), Column(Order = 5)]
        public string Icon { get; set; }

        [MaxLength(1000), Column(Order = 6)]
        public string KeyWord { get; set; }

        [MaxLength(1000), Column(Order = 7)]
        public int isShow { get; set; }

    }
}
