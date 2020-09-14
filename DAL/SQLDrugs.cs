using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDrugs
    {
        public bool InsertDrug(Medicine medicine)
        {
            bool Result = true;
            using (var ctx = new DrugsContext())
            {
                ctx.Drugs.Add(medicine);
                ctx.SaveChanges();
            }
            //DrugsContext DB = new DrugsContext();
            //DB.Drugs.Add(medicine);
            ////DB.Drugs.Add(new Medicine {ActiveIngredients="",Company="",GenericName="", ImagePath="",Name="" });
            //DB.SaveChanges();
            return Result;
        }
    }
    public class DrugsContext : DbContext
    {
        public DrugsContext() : base("DrugsDB")
        {


        }

        public DbSet<Medicine> Drugs { get; set; }
    }
}
