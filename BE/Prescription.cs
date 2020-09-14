using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Prescription
    {
        public int Id { get; private set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DosageEnum Dosage { get; set; }//מינון
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
