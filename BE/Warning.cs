using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Warning
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LevelOfRisk { get; set; }
        public string ConflictingMedicines { get; set; }

    }
}
