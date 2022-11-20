using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Account
{
    public class ChangePasswordDTO
    {
        public string PreviousPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public int AccountId { get; set; }
    }

}
