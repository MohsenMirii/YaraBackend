using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{

    public enum InvestmentConditionsType
    {
        [Description("دارای مدرک علمی تعیین شده توسط فرابورس")]
        Type1 = 1,

        [Description("کارمند ارکان بازار سرمایه")]
        Type2 = 2,

        [Description("سابقه عضویت در هیئت مدیره نهادهای مالی")]
        Type3 = 3,

        [Description("حداقل ارزش معاملات 20 ملیارد ریال")]
        Type4 = 4,

        [Description("حداقل ارزش پرتقوی 50 ملیارد ریال")]
        Type5 = 5,

        [Description("فعال در بانک، بیمه و تمامی نهادهای مالی")]
        Type6 = 6,

        [Description("حقوق صاحبان سهام سه سال آخر بیش از 100 میلیارد ریاد")]
        Type7 = 7,

        [Description("میانگین ارزش پرتقوی 3 سال آخر (انتهای هر ماه) بیش از 100 میلیارد ریال")]
        Type8 = 8,

        [Description("گردش حساب بانکی طی 6 ماه اخیر (انتهای هر ماه) بیش از 100 میلیارد ریال")]
        Type9 = 9,
    }
}
