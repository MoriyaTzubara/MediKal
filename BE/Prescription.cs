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
        public int NumOfTimes { get; set; }//כמה פעמים לוקחים את התרופה
        public FrequencyEnum Frequency { get; set; }//כל כמה זמן לקחת
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MedicineId { get; set; }
        public string Comments { get; set; }
    }
}
