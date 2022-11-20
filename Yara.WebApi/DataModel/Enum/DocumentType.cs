using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum DocumentType
    {
        [Description("Picture")]
        Picture = 1,

        [Description("Video")]
        Video = 2,

        [Description("PDF")]
        PDF = 3,

        [Description("Word")]
        Word = 4,

        [Description("Appendix")]
        Appendix = 5,
    }
}
