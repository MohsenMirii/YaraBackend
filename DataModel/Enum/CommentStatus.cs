using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum CommentStatus
    {
        [Description("Draft")]
        Draft = 1,

        [Description("ConfirmedToShow")]
        ConfirmedToShow = 2,

        [Description("Rejected")]
        Rejected = 3

    }
}
