using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Doctor:User
    {
        public int LicenseNum { get; set; }
        public SpecialtyEnum Specialty { get; set; }
    }
}
