using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;

namespace MediKal.Models
{
    public class WarningViewModel
    {
        public Warning warning;

        public WarningViewModel(Warning _warning)
        {
            warning = _warning;
        }

        public string Description
        {
            get { return warning.Description; }
            set { warning.Description = value; }
        }

        public string ConflictingMedicines
        {
            get { return warning.ConflictingMedicines; }
            set { warning.ConflictingMedicines = value; }
        }

        public string LevelOfRisk
        {
            get { return warning.LevelOfRisk; }
            set { warning.LevelOfRisk = value; }
        }


        public int Id
        {
            get { return warning.Id; }
            set { warning.Id = value; }
        }


    }
}