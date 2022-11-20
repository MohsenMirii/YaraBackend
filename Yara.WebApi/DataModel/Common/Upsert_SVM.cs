using System;
using System.Collections.Generic;
using System.Text;
using DataModel.File;

namespace DataModel.Common
{
    public class Upsert_SVM<T>
    {
        public Upsert_SVM()
        {
            FileVM = new File_VM();
        }
        public T Data { get; set; }
        public File_VM FileVM { get; set; }
    }
}
