using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Common
{
    public class DataList_VM<T>
    {
        public List<T> DataList { get; set; }
        public int TotalCountInt { get; set; }
        public int DataTypeInt { get; set; }
    }
}
