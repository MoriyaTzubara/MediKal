using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
