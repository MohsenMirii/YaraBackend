using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum ServiceType
    {
        [Description("معاملات آنلاین ")]
        SecuritiesTransactions = 1,

        [Description("کال سنتر")]
        HousingFacilityBonds = 2,

        [Description("معاملات اینترنتی")]
        CallCenter = 3,

        [Description("قوانین و مقررات")]
        MobileRyan = 4,
        
    }
}
