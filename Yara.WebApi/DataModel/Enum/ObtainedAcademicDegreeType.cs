using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum ObtainedAcademicDegreeType
    {
        [Description("اصول بازار سرمایه")]
        Type1 = 1,

        [Description("تحلیلگر")]
        Type2 = 2,

        [Description("مدیریت سبد اوراق بهادار")]
        Type3 = 3,

        [Description("ارزشیابی اوراق بهادار")]
        Type4 = 4,

        [Description("تحلیلگر مالی خبره(CFA)")]
        Type5 = 5,

        [Description("مدیریت ریسک مالی (FRM)")]
        Type6 = 6,

        [Description("حسابرسان داخلی(CIA)")]
        Type7 = 7,

        [Description("حسابرسی رسمی مدیریت(CMA)")]
        Type8 = 8,
        
    }
}
