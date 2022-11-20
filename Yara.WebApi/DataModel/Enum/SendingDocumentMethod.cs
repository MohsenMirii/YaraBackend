using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataModel.Enum
{
    public enum SendingDocumentMethod
    {
        [Description("آپلود در پرسشنامه")]
        UploadInQuestionnaire = 1,

        [Description("ارسال در سامانه چت")]
        SendInChatSystem = 2,
    }
}
