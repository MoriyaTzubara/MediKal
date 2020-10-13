using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediKal.Models
{
    public class PatientViewModel
    {
        public Patient patient;

        public PatientViewModel(Patient _patient)
        {
            patient = _patient;
        }
        [DisplayName("ID")]
        [Required(ErrorMessage = "required field")]
        public int Id
        {
            get { return patient.Id; }
            set { patient.Id = value; }
        }
        public string Background
        {
            get { return patient.Background; }
            set { patient.Background = value; }
        }
        [Required(ErrorMessage = "required field")]
        public DateTime? Birthday
        {
            get { return patient.Birthday; }
            set { patient.Birthday = value; }
        }
        [DisplayName("Blood Type")]
        [Required(ErrorMessage = "required field")]
        public BloodTypeEnum BloodType
        {
            get { return patient.BloodType; }
            set { patient.BloodType = value; }
        }
        [Required(ErrorMessage = "required field")]
        [DisplayName("Full Name")]
        public string FullName
        {
            get { return patient.UserName; }
            set { patient.UserName = value; }
        }
        [Required(ErrorMessage = "required field")]
        public string Mail
        {
            get { return patient.Mail; }
            set { patient.Mail = value; }
        }
        [Required(ErrorMessage = "required field")]
        public string Phone
        {
            get { return patient.Phone; }
            set { patient.Phone = value; }
        }
        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return patient.Password; }
            set { patient.Password = value; }
        }

        [Required(ErrorMessage = "required field")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}