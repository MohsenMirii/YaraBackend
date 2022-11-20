using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Account
{
    public class ChangePasswordByAdminDTO
    {
        public long AccountId { get; set; }
        public long ImpressedAccountId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
