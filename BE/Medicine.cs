using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Medicine
    {
        public int Id { get; set; }
        public string ServingOption { get; set; }
        public string NDCId { get; set; }
        public string GenericName { get; set; }
        public string Name { get; set; }
        public List<string> ActiveIngredients { get; set; }
        public string ImagePath { get; set; }
        public string Company { get; set; }
        
        public Medicine() {  }
        public Medicine(int id) { Id = id; }
    }
}
