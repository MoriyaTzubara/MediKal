using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MediKalDB : DbContext
    {
        public MediKalDB() : base("name=MediKalDB")
        {
        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
