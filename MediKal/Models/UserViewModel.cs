using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public int Id
        {
            get { return user.Id; }
        }
        public int PrimaryId
        {
            get { return user.PrimaryId; }
        }
        [Required(ErrorMessage = "required field")]
        [DisplayName("Full name")]
        public string UserName
        {
            get { return user.UserName; }
            set { user.UserName = value; }
        }
        [Required(ErrorMessage = "required field")]
        [DisplayName("Email")]
        public string Mail
        {
            get { return user.Mail; }
            set { user.Mail = value; }
        }
        [Required(ErrorMessage = "required field")]
        public DateTime? Birthday
        {
            get { return user.Birthday; }
            set { user.Birthday = value; }
        }
        [Required(ErrorMessage = "required field")]
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
        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return user.Password; }
            set { user.Password = value; }
        }

        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
