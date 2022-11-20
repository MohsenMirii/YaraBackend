using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Account
{
  public  class Login_VM
    {
        public Login_VM()
        {
            PermissionListVM = new List<MenuPermission_VM>();
        }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public List<MenuPermission_VM> PermissionListVM{ get; set; }
    }
    public class MenuPermission_VM
    {
        public long ActionCode { get; set; }
        public string ActionName { get; set; }
        public long SuperActionCode { get; set; }
        public string KeyWord { get; set; }
        public string MenuUrl { get; set; }
        public string Icon { get; set; }
        public int isShow { get; set; }
        public int Priority { get; set; }

    }
}
