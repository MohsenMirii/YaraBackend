using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Common
{
   public class BaseResult_VM: Result_VM
    {
        public object Result { get; set; }
    }

    public class BaseResult<T>
    {
        public bool IsOk { get; set; }
        public T Result { get; set; }
    }
}
