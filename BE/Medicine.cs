using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Medicine
    {
        public int Id { get; private set; }
        public string GenericName { get; set; }
        public string Name { get; set; }
        public string ActiveIngredients { get; set; }
        public string ImagePath { get; set; }
        public string Company { get; set; }
    }
}
