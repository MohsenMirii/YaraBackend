using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.File
{
    public class File_VM
    {
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public byte[] FileContent { get; set; }
        public int DocumentTypeInt { get; set; }
    }
}
