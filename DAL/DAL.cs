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
        #region ADD
        public void AddMedicine(Medicine medicine)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void AddPatient(Patient patient)
        {
            try
            {
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
            try
            {
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
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void AddDoctor(Doctor doctor)
        {
            User tmp = new User();
            tmp.Birthday = doctor.Birthday;
            tmp.Mail = doctor.Mail;
            tmp.Password = doctor.Password;
            tmp.Phone = doctor.Phone;
            tmp.UserName = doctor.UserName;
            tmp.UserType = doctor.UserType;
            AddUser(tmp);
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Doctors.Add(doctor);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void AddManager(Manager manager)
        {
            User tmp = new User();
            tmp.Birthday = manager.Birthday;
            tmp.Mail = manager.Mail;
            tmp.Password = manager.Password;
            tmp.Phone = manager.Phone;
            tmp.UserName = manager.UserName;
            tmp.UserType = manager.UserType;
            AddUser(tmp);
        }
        #endregion
        #region DELETE
        public void DeleteMedicine(int id)
        {
            try
            {
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
            try
            {
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
            try
            {
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
            try
            {
                using (var db = new MediKalDB())
                {
                    User user = db.Users.Find(id);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public void DeleteDoctor(int id)
        {
                try
                {
                    using (var db = new MediKalDB())
                    {
                        User user = db.Users.Find(id);
                        Doctor doctor = db.Doctors.Find(id);
                        db.Doctors.Remove(doctor);
                        db.Users.Remove(user);
                        db.SaveChanges();
                    }
                }
                catch (Exception e) { throw new Exception(e.Message); }
            }

        public void DeleteManager(int id)
        {
            DeleteUser(id);
        }
        #endregion
        #region GET
        public IEnumerable<Medicine> GetMedicines()
        {
            try
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
            catch (Exception e) { throw new Exception(e.Message);
    }

}

        public IEnumerable<Patient> GetPatients()
        {
            try
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            try
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
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<User> GetUsers()
        {
            try
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
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public IEnumerable<Doctor> GetDoctors()
        {
            //try
            //{
            //    List<Doctor> result = new List<Doctor>();
            //    using (var db = new MediKalDB())
            //    {
            //        foreach (var doctor in db.Doctors)
            //        {
            //            result.Add(doctor);
            //        }
            //    }
            //    return result;
            //}
            //catch (Exception e) { throw new Exception(e.Message); }
            throw new NotImplementedException();

        }
        public IEnumerable<Manager> GetManagers()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region UPDATE
        public void UpdateMedicine(Medicine medicine, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Medicines.First(m => m.Id == Id);
                    tmp.ActiveIngredients = medicine.ActiveIngredients;
                    tmp.Company = medicine.Company;
                    tmp.GenericName = medicine.GenericName;
                    tmp.ImagePath = medicine.ImagePath;
                    tmp.Name = medicine.Name;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }

        public void UpdatePatient(Patient patient, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Patients.First(p => p.Id == Id);
                    tmp.Background = patient.Background;
                    tmp.Birthday = patient.Birthday;
                    tmp.BloodType = patient.BloodType;
                    tmp.UserName = patient.UserName;
                    tmp.Mail = patient.Mail;
                    tmp.Phone = patient.Phone;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdatePrescription(Prescription prescription, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Prescriptions.First(p => p.Id == Id);
                    tmp.Comments = prescription.Comments;
                    tmp.DoctorId = prescription.DoctorId;
                    tmp.EndTime = prescription.EndTime;
                    tmp.Frequency = prescription.Frequency;
                    tmp.MedicineId = prescription.MedicineId;
                    tmp.NumOfTimes = prescription.NumOfTimes;
                    tmp.PatientId = prescription.PatientId;
                    tmp.StartTime = prescription.StartTime;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdateUser(User user, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Users.First(u => u.Id == Id);
                    tmp.Birthday = user.Birthday;
                    tmp.Mail = user.Mail;
                    tmp.Password = user.Password;
                    tmp.Phone = user.Phone;
                    tmp.UserName = user.UserName;
                    tmp.UserType = user.UserType;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdateDoctor(Doctor doctor, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var helper = db.Doctors.First(d => d.Id == Id);
                    User tmp = new User();
                    tmp.Birthday = doctor.Birthday;
                    tmp.Mail = doctor.Mail;
                    tmp.Password = doctor.Password;
                    tmp.Phone = doctor.Phone;
                    tmp.UserName = doctor.UserName;
                    tmp.UserType = doctor.UserType;
                    UpdateUser(tmp, Id);
                    helper.LicenseNum = doctor.LicenseNum;
                    helper.Specialty = doctor.Specialty;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdateManager(Manager manager, int Id)
        {
            try
            {
                    User tmp = new User();
                    tmp.Birthday = manager.Birthday;
                    tmp.Mail = manager.Mail;
                    tmp.Password = manager.Password;
                    tmp.Phone = manager.Phone;
                    tmp.UserName = manager.UserName;
                    tmp.UserType = manager.UserType;
                    UpdateUser(tmp, Id);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        #endregion

    }
}
