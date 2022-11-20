using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModel.DomainClasses
{
    public class Analysis
    {
        public long Id { get; set; }
        [Column(TypeName = ("NVARCHAR(MAX)"))]
        public string Text { get; set; }
        [Column(TypeName = ("NVARCHAR(500)"))]
        public string Title { get; set; }
        [Column(TypeName = ("NVARCHAR(1000)"))]
        public string KeyWord { get; set; }
        public string AnalysisTag { get; set; }
        public long VisitsCount { get; set; }
        public long AuthorId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? DocumentID { get; set; }
        public virtual DataModel.DomainClasses.Account Author { get; set; }
        public virtual DataModel.DomainClasses.DocumentFile Document { get; set; }

    }
}
