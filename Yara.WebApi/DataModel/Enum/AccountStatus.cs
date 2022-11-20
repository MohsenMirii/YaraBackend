using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum AccountStatus
    {
        [Description("DeActive")]
        DeActive = 1,

        [Description("Active")]
        Active = 2
    }
}
