using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Account
{
    public class RegisterAccount_VM
    {
        public RegisterAccount_VM()
        {
            Account = new DataModel.DomainClasses.Account();
            AccountPermissions = new List<long>();
        }
        public long AccountId { get; set; }
        public DataModel.DomainClasses.Account Account { get; set; }
      
        public List<long> AccountPermissions { get; set; }
    }
}
