using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Common
{
    public class RelatedSubject_VM : GetOneItemDTO
    {
        public RelatedSubject_VM()
        {
            KeyWord = new List<string>();
        }
        public List<string> KeyWord { get; set; }
    }
}
