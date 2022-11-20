using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum AccountType
    {
        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }
}
