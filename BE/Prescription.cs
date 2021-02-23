using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int NumOfTimes { get; set; }
        public FrequencyEnum Frequency { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MedicineId { get; set; }
        public string Comments { get; set; }
    }
}
