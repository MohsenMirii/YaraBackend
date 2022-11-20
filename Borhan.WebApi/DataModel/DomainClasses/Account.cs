using System;
using System.Collections.Generic;
using System.Text;


namespace DataModel.DomainClasses
{
    public partial class Account
    {
       
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int AccountStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
    }
}
