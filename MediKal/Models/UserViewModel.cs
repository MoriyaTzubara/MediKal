using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;

namespace MediKal.Models
{
    public class UserViewModel
    {
        private User user;

        public UserViewModel(User _user)
        {
            user = _user;
        }
        
        public int Id
        {
            get { return user.Id; }
        }

        public string UserName
        {
            get { return user.UserName; }
            set { user.UserName = value; }
        }
       
        public string Mail
        {
            get { return user.Mail; }
            set { user.Mail = value; }
        }

    }
}