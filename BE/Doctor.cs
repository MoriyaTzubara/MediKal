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
        
        public Doctor() :base(){
            this.LicenseNum = 0;
            this.UserType = UserTypeEnum.Doctor;
        }
        public Doctor(int id):base(id) {
            this.LicenseNum = 0;
            this.UserType = UserTypeEnum.Doctor;

        }
        public Doctor(Doctor doctor):base(doctor) {
            this.LicenseNum = doctor.LicenseNum;
            this.UserType = UserTypeEnum.Doctor;

        }
    }
}
