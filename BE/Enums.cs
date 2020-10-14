using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum LevelOfRiskEnum
    {
        High,
        Medium,
        Low,
    }
    public enum SpecialtyEnum
    {
        Family_Doctor,
        ENT,
        Ophthalmologist,
        Pediatrician

    }
    public enum UserTypeEnum
    {
       Patient,
       Doctor,
       Manager
    }
    public enum BloodTypeEnum
    {
        A_plus,
        A_minus,
        B_plus,
        B_minus,
        AB_plus,
        AB_minus,
        O_plus,
        O_minus,
    }
    public enum FrequencyEnum
    {
        day,
        week,
        month
    }
}
