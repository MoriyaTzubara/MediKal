using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public DateTime? Birthday
        {
            get { return patient.Birthday; }
            set { patient.Birthday = value; }
        }
        [DisplayName("Blood Type")]
        public BloodTypeEnum BloodType
        {
            get { return patient.BloodType; }
            set { patient.BloodType = value; }
        }
        
        [DisplayName("Full Name")]
        public string FullName
        {
            get { return patient.UserName; }
            set { patient.UserName = value; }
        }

        public string Mail
        {
            get { return patient.Mail; }
            set { patient.Mail = value; }
        }

        public string Phone
        {
            get { return patient.Phone; }
            set { patient.Phone = value; }
        }

    }
}