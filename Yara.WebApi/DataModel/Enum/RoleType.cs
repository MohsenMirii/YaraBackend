using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum RoleType
    {
        [Description("SuperAdmin")]
        SuperAdmin = 1,

        [Description("FirstLevelAdmin")]
        FirstLevelAdmin = 2,
    }
}
