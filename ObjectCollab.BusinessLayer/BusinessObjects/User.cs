using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.Enums;

namespace ObjectCollab.BusinessLayer.BusinessObjects
{
    public interface IUserBO
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        
        Role Role { get; set; }
    }

    public class UserBO : IUserBO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] RowVersion { get; set; }
        public Role Role { get; set; }


    
    }
}
