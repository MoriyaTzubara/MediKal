using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patient:User
    {
        public string Background { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        
        public Patient() { }
        public Patient(int id) : base(id) { }
    }
}
