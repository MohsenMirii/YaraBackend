using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum AccountPermissionStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("DeActive")]
        DeActive = 2
    }
}
