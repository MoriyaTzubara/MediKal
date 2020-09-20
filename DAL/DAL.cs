using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL : IDAL
    {
        public void AddMedicine(Medicine medicine)
        {
                using (var db = new MediKalDB())
                {
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
        }

        public void AddPatient(Patient patient)
        {
            using (var db = new MediKalDB())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            using (var db = new MediKalDB())
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (var db = new MediKalDB())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteMedicine(int id)
        {
            using (var db = new MediKalDB())
            {
                Medicine medicine = db.Medicines.Find(id);
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
        }

        public void DeletePatient(int id)
        {
            using (var db = new MediKalDB())
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public void DeletePrescription(int id)
        {
            using (var db = new MediKalDB())
            {
                Prescription prescription = db.Prescriptions.Find(id);
                db.Prescriptions.Remove(prescription);
                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var db = new MediKalDB())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            List<Medicine> result = new List<Medicine>();
            using (var db = new MediKalDB())
            {
                foreach (var medicine in db.Medicines)
                {
                    result.Add(medicine);
                }
            }
            return result;
        }

        public IEnumerable<Patient> GetPatients()
        {
            List<Patient> result = new List<Patient>();
            using (var db = new MediKalDB())
            {
                foreach (var patient in db.Patients)
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            List<Prescription> result = new List<Prescription>();
            using (var db = new MediKalDB())
            {
                foreach (var prescription in db.Prescriptions)
                {
                    result.Add(prescription);
                }
            }
            return result;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> result = new List<User>();
            using (var db = new MediKalDB())
            {
                foreach (var user in db.Users)
                {
                    result.Add(user);
                }
            }
            return result;
        }

        public void UpdateMedicine(Medicine medicine)
        {
            using (var db = new MediKalDB())
            {
                var tmp = db.Medicines.First(m => m.Id == medicine.Id);
                if (medicine.ActiveIngredients != null)
                    tmp.ActiveIngredients = medicine.ActiveIngredients;
                if (medicine.Company != null)
                    tmp.Company = medicine.Company;
                if (medicine.GenericName != null)
                    tmp.GenericName = medicine.GenericName;
                if (medicine.ImagePath != null)
                    tmp.ImagePath = medicine.ImagePath;
                if (medicine.Name != null)
                    tmp.Name = medicine.Name;
                db.SaveChanges();
            }
        }

        public void UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void UpdatePrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
