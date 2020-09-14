using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CRUDdrugs
    {
        public bool AddDrug(Medicine medicine)
        {
            //checking the data beforehand
            DAL.SQLDrugs dal = new DAL.SQLDrugs();
            bool Result = dal.InsertDrug(medicine);
            return Result;
        }
    }
}
