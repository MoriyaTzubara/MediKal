using BE;
using System;
using System.Collections.Generic;
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

        public string ConfirmPassword { get; set; }


        public DateTime? Birthday
        {
            get { return doctor.Birthday; }
            set { doctor.Birthday = value; }
        }

        public int Id
        {
            get { return doctor.Id; }
            set { doctor.Id = value; }
        }

        public int LicenseNum
        {
            get { return doctor.LicenseNum; }
            set { doctor.LicenseNum = value; }
        }

        public string Mail
        {
            get { return doctor.Mail; }
            set { doctor.Mail = value; }
        }

        public string Password
        {
            get { return doctor.Password; }
            set { doctor.Password = value; }
        }

        public string Phone
        {
            get { return doctor.Phone; }
            set { doctor.Phone = value; }
        }

        public SpecialtyEnum Specialty
        {
            get { return doctor.Specialty; }
            set { doctor.Specialty = value; }
        }

        public string UserName
        {
            get { return doctor.UserName; }
            set { doctor.UserName = value; }
        }

    }
}