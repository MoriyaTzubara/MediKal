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

    }
}