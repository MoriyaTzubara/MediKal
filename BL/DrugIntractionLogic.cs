using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class DrugIntractionLogic
    {
        public List<string> checkInteractions(List<string> DrugCodesNDC)

        {

            List<string> result = new List<string>();
            DrugIntractions dal = new DrugIntractions();
            result = dal.CheckPerscription(DrugCodesNDC);
            return result;

        }
    }
}
