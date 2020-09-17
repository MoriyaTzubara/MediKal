using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Patient
    {
        public int Id { get; private set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Background { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
