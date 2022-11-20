using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Common
{
    public class CombinationItem_VM
    {
        public CombinationItem_VM()
        {
            Document = new DataModel.DomainClasses.DocumentFile();
        }
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CategoryTitleStr { get; set; }
        public string TitleStr { get; set; }
        public string DescriptionStr { get; set; }
        public string InsertDateStr { get; set; }
        public virtual DataModel.DomainClasses.DocumentFile Document { get; set; }
    }
}
