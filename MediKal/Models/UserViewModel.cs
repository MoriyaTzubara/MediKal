using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BE;

namespace MediKal.Models
{
    public class UserViewModel
    {
        
        public User user;

        public UserViewModel(User _user)
        {
            user = _user;
        }
        private int Id
        {
            get { return user.Id; }
        }
        [DisplayName("User name")]
        public string UserName
        {
            get { return user.UserName; }
            set { user.UserName = value; }
        }
        [DisplayName("Email")]
        public string Mail
        {
            get { return user.Mail; }
            set { user.Mail = value; }
        }

        public DateTime? Birthday
        {
            get { return user.Birthday; }
            set { user.Birthday = value; }
        }
        public string Phone
        {
            get { return user.Phone; }
            set { user.Phone = value; }
        }
        [DisplayName("User Type")]
        public UserTypeEnum UserType
        {
            get { return user.UserType; }
            set { user.UserType = value; }
        }

    }
}