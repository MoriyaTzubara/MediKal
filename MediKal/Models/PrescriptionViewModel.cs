using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediKal.Models
{
    public class PrescriptionViewModel
    {
        public Prescription prescription;

        public PrescriptionViewModel(Prescription _prescription)
        {
            prescription = _prescription;
        }

        public string Comments
        {
            get { return prescription.Comments; }
            set { prescription.Comments = value; }
        }

        [Required(ErrorMessage = "required field")]
        public int DoctorId
        {
            get { return prescription.DoctorId; }
            set { prescription.DoctorId = value; }
        }

        [Required(ErrorMessage = "required field")]
        [DisplayName("End Time")]
        public DateTime EndTime
        {
            get { return prescription.EndTime; }
            set { prescription.EndTime = value; }
        }

        [Required(ErrorMessage = "required field")]
        public FrequencyEnum Frequency
        {
            get { return prescription.Frequency; }
            set { prescription.Frequency = value; }
        }

        [Required(ErrorMessage = "required field")]
        public int MedicineId
        {
            get { return prescription.MedicineId; }
            set { prescription.MedicineId = value; }
        }
        [Required(ErrorMessage = "required field")]
        [DisplayName("Number Of Times")]
        public int NumOfTimes
        {
            get { return prescription.NumOfTimes; }
            set { prescription.NumOfTimes = value; }
        }

        [Required(ErrorMessage = "required field")]
        public int PatientId
        {
            get { return prescription.PatientId; }
            set { prescription.PatientId = value; }
        }
        [Required(ErrorMessage = "required field")]
        [DisplayName("Start Time")]
        public DateTime StartTime
        {
            get { return prescription.StartTime; }
            set { prescription.StartTime = value; }
        }
    }
}