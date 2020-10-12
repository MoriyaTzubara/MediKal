using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum SpecialtyEnum
    {
        stam
    }
    public enum UserTypeEnum
    {
       Patient,
       Doctor,
       Manager
    }
    public enum BloodTypeEnum
    {
        הכל,
        A_plus,
        A_minus,
        B_plus,
        B_minus,
        AB_plus,
        AB_minus,
        O_plus,
        O_minus,
        לא_ידוע,
        אחר
    }
    public enum FrequencyEnum
    {
        day,
        week,
        month
    }
}
