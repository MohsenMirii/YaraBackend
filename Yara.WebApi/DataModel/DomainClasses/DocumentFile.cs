using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel.DomainClasses
{
    public partial class DocumentFile
    {
        public long Id { get; set; }
        [Column(TypeName = ("NVARCHAR(500)"))]
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public byte[] FileContent { get; set; }
        public int DocumentTypeInt { get; set; }
        public long PointerID { get; set; }
     
       
        


    }
}
