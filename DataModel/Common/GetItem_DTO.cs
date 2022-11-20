using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Common
{
    public class GetItemDTO
    {
        public int TableCodeInt { get; set; }
        public long PointerIdLng { get; set; }
        public int Status { get; set; }
        public int StartIndex { get; set; } = 0;
        public int PageSize { get; set; } = 3;
        
    }
}
