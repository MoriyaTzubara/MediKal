using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime Birthday { get; set; }
        public UserTypeEnum UserType { get; set; }
        public User() { }
        public User(int id)
        {
            Id = id;
        }
    }
}
