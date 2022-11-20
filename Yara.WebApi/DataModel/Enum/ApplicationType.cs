using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum ApplicationType
    {
        [Description("بررسی مجدد")]
        Review = 1,

        [Description("پایان کار")]
        Finish = 2,
    }
}
