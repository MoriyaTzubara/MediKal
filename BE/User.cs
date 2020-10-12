using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        [Key]
        public int PrimaryId { get; private set; }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime? Birthday { get; set; }
        public UserTypeEnum UserType { get; set; }
        public User() {
            this.Birthday = null;
            this.Mail = "";
            this.Password = "";
            this.Phone = "";
            this.UserName = "";
            Id = 0;
        }
        public User(int id)
        {
            this.Birthday = null;
            this.Mail = "";
            this.Password = "";
            this.Phone = "";
            this.UserName = "";
            Id = id;

        }
        public User(User user)
        {
            this.Birthday = user.Birthday;
            this.Id = user.Id;
            this.Mail = user.Mail;
            this.Password = user.Password;
            this.Phone = user.Phone;
            this.PrimaryId = user.PrimaryId;
            this.UserName = user.UserName;
        }
    }
}
