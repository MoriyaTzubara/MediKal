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
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
            }catch(Exception e) { throw new Exception(e.Message); }
        }

        public void AddPatient(Patient patient)
        {
            try { 
            using (var db = new MediKalDB())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void AddPrescription(Prescription prescription)
        {
            try { 
            using (var db = new MediKalDB())
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void AddUser(User user)
        {
            try { 
            using (var db = new MediKalDB())
            {
                db.Users.Add(user);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void DeleteMedicine(int id)
        {
            try { 
            using (var db = new MediKalDB())
            {
                Medicine medicine = db.Medicines.Find(id);
                db.Medicines.Remove(medicine);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void DeletePatient(int id)
        {
            try { 
            using (var db = new MediKalDB())
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void DeletePrescription(int id)
        {
            try { 
            using (var db = new MediKalDB())
            {
                Prescription prescription = db.Prescriptions.Find(id);
                db.Prescriptions.Remove(prescription);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void DeleteUser(int id)
        {
            try { 
            using (var db = new MediKalDB())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<Medicine> GetMedicines()
        {
            try { 
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<Patient> GetPatients()
        {
            try { 
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            try {
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<User> GetUsers()
        {
            try { 
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void UpdateMedicine(Medicine medicine)
        {
            try { 
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
            catch (Exception e) { throw new Exception(e.Message); }

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
