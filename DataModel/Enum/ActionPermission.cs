using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum ActionPermission
    {

        [Description("بانک")]
        BankOP = 1,
        [Description("درج")]
        BankOP_Insert = 2,
        [Description("ویرایش")]
        BankOP_Update = 3,

        [Description("شعب")]
        BranchOP = 4,
        [Description("درج")]
        BranchOP_Insert = 5,
        [Description("ویرایش")]
        BranchOP_Update = 6,

        [Description("اخبار")]
        NewsOP = 7,
        [Description("درج")]
        NewsOP_Insert = 8,
        [Description("ویرایش")]
        NewsOP_Update = 9,

        [Description("تحلیل ها")]
        AnalysisOP = 10,
        [Description("درج")]
        AnalysisOP_Insert = 11,
        [Description("ویرایش")]
        AnalysisOP_Update = 12,

        [Description("گزارش روزانه")]
        DailyReportOP = 15,
        [Description("درج")]
        DailyReportOP_Insert = 16,
        [Description("ویرایش")]
        DailyReportOP_Update = 17,

        [Description("کتاب های الکترونیکی")]
        TrainingOP = 18,
        [Description("درج")]
        TrainingOP_Insert = 19,
        [Description("ویرایش")]
        TrainingOP_Update = 20,

        [Description("مرکز تماس")]
        CallCenterOP = 21,
        [Description("درج")]
        CallCenterOP_Insert = 22,
        [Description("ویرایش")]
        CallCenterOP_Update = 23,

        [Description("سوالات متداول(سوالات)")]
        FrequentlyQuestions = 24,
        [Description("درج")]
        FrequentlyQuestionsOP_Insert = 25,
        [Description("ویرایش")]
        FrequentlyQuestionsOP_Update = 26,

        [Description("فیلم آموزشی")]
        LearningFilm = 27,
        [Description("درج")]
        LearningFilmOP_Insert = 28,
        [Description("ویرایش")]
        LearningFilmOP_Update = 29,

        [Description("اسلایدر")]
        SliderOP = 30,
        [Description("درج")]
        SliderOP_Insert = 31,
        [Description("ویرایش")]
        SliderOP_Update = 32,

        [Description("معاملات اینترنتی")]
        InternetTransactionsOP = 33,
        [Description("درج")]
        InternetTransactionsOP_Insert = 34,
        [Description("ویرایش")]
        InternetTransactionsOP_Update = 35,

        [Description("معاملات آنلاین")]
        OnlineOP = 36,
        [Description("درج")]
        OnlineOP_Insert = 37,
        [Description("ویرایش")]
        OnlineOP_Update = 38,

        [Description("ارتباط با ما")]
        ContactUsOP = 39,
        [Description("درج")]
        ContactUsOP_Insert = 40,
        [Description("ویرایش")]
        ContactUsOP_Update = 41,

        [Description("قوانین و مقررات")]
        RullsAndPermissionsOP = 42,
        [Description("درج")]
        RullsAndPermissionsOP_Insert = 43,
        [Description("ویرایش")]
        RullsAndPermissionsOP_Update = 44,

        [Description("مدیریت کاربران")]
        AdminOP = 45,
        [Description("ثبت نام کاربران")]
        AdminOP_RegisterAccount = 46,
        [Description("ویرایش")]
        AdminOP_Update = 47,
        [Description("تغییر پسورد ")]
        AdminOP_ChangePassword = 48,

        [Description("کارمزد")]
        WageOP = 49,
        [Description("درج")]
        WageOP_Insert = 50,
        [Description("ویرایش")]
        WageOP_Update = 51,

        [Description("سوالات متداول(گروه ها)")]
        FrequentlyQuestionGroupsOP = 52,
        [Description("درج")]
        FrequentlyQuestionGroupsOP_Insert = 53,
        [Description("ویرایش")]
        FrequentlyQuestionGroupsOP_Update = 54,

        [Description("نظرات کاربران")]
        CommentsOP = 55,
        [Description("مدیریت")]
        CommentsOP_Management = 56,

        [Description("آمار بازدید")]
        VisitStatisticsOP = 57,
        [Description("مشاهده")]
        VisitStatisticsOP_Management = 58,

        [Description("فرم های ارسال شده")]
        InsertContactUsOP = 59,
        [Description("مشاهده")]
        InsertContactUsOP_Management = 60,

        [Description("همکاري با ما")]
        AboutsOP = 61,
        [Description("مشاهده")]
        AboutsOP_Management = 62,

        [Description("سرمایه گذاران")]
        ProfessionalInvestorOP = 63,
        [Description("مشاهده و ویرایش")]
        ProfessionalInvestorOP_Update = 64,

    }
}
