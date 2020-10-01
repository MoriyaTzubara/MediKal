using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Doctor:User
    {
        public int LicenseNum { get; set; }
        public SpecialtyEnum Specialty { get; set; }
        public Doctor() { }
        public Doctor(int id):base(id) { }
    }
}
