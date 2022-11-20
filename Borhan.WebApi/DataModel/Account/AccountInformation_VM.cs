using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Enum;

namespace DataModel.Account
{
    public class AccountInformation_VM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public AccountType AccountType { get; set; }

    }
}
