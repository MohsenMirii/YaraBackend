using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum ProfessionalInvestorType
    {
        [Description("Person")]
        Person = 1,

        [Description("Company")]
        Company = 2,
    }
}
