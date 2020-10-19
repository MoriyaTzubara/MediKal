using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediKal.Models
{
    public class DoctorViewModel
    {
        public Doctor doctor;
        public DoctorViewModel(Doctor _doctor)
        {
            doctor = _doctor;
        }
        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "required field")]
        public DateTime? Birthday
        {
            get { return doctor.Birthday; }
            set { doctor.Birthday = value; }
        }

        [Required(ErrorMessage = "required field")]
        [DisplayName("ID")]
        public int Id
        {
            get { return doctor.Id; }
            set { doctor.Id = value; }
        }

        [Required(ErrorMessage = "required field")]
        [DisplayName("License Number")]
        public int LicenseNum
        {
            get { return doctor.LicenseNum; }
            set { doctor.LicenseNum = value; }
        }
        [Required(ErrorMessage = "required field")]
        public string Mail
        {
            get { return doctor.Mail; }
            set { doctor.Mail = value; }
        }
        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return doctor.Password; }
            set { doctor.Password = value; }
        }
        [Required(ErrorMessage = "required field")]
        [StringLength(10, ErrorMessage = "Can't be more than 10 digits")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "phone number illegal")]
        public string Phone
        {
            get { return doctor.Phone; }
            set { doctor.Phone = value; }
        }

        [Required(ErrorMessage = "required field")]
        public SpecialtyEnum Specialty
        {
            get { return doctor.Specialty; }
            set { doctor.Specialty = value; }
        }
        [Required(ErrorMessage = "required field")]
        [StringLength(30, ErrorMessage = "Can't be more than 30 letters")]
        [DisplayName("Full Name")]
        public string UserName
        {
            get { return doctor.UserName; }
            set { doctor.UserName = value; }
        }

    }
}