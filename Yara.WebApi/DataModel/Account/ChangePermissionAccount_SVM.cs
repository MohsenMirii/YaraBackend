using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Account
{
    public class ChangePermissionAccount_SVM
    {
        public ChangePermissionAccount_SVM()
        {
            AccountPermissions = new List<long>();
        }
        public long AccountId { get; set; }
        public long ImpressedAccountId { get; set; }
       
        public List<long> AccountPermissions { get; set; }
    }
}
