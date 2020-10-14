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
            //try
            //{
                using (var db = new MediKalDB())
                {
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
            //}
            //catch (Exception e) { throw new Exception(e.Message); }
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
           // try
            //{
                using (var db = new MediKalDB())
                {
                    db.Prescriptions.Add(prescription);
                    db.SaveChanges();
                }
            //}
           // catch (Exception e) { throw new Exception(e.Message); }

        }

        //public void AddUser(User user)
        //{
        //    try
        //    {
        //        using (var db = new MediKalDB())
        //        {
        //            db.Users.Add(user);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception e) { throw new Exception(e.Message); }

        //}

        public void AddDoctor(Doctor doctor)
        {
            //User tmp = new User();
            //tmp.Birthday = doctor.Birthday;
            //tmp.Mail = doctor.Mail;
            //tmp.Password = doctor.Password;
            //tmp.Phone = doctor.Phone;
            //tmp.UserName = doctor.UserName;
            //tmp.UserType = doctor.UserType;
            //AddUser(tmp);
            //try
            //{
                using (var db = new MediKalDB())
                {
                    db.Doctors.Add(doctor);
                    db.SaveChanges();
                }
            //}
            //catch (Exception e) { throw new Exception(e.Message); }
        }

        public void AddManager(Manager manager)
        {
            //User tmp = new User();
            //tmp.Birthday = manager.Birthday;
            //tmp.Mail = manager.Mail;
            //tmp.Password = manager.Password;
            //tmp.Phone = manager.Phone;
            //tmp.UserName = manager.UserName;
            //tmp.UserType = manager.UserType;
            //AddUser(tmp);
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Managers.Add(manager);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        #endregion
        #region DELETE
        public void DeleteMedicine(string NDCid)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    Medicine medicine = db.Medicines.First(m => m.NDCId == NDCid);
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
                    Patient patient = db.Patients.First(d => d.Id == id);
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

        //public void DeleteUser(int id)
        //{
        //    try
        //    {
        //        using (var db = new MediKalDB())
        //        {
        //            Doctor userD = db.Doctors.Find(id);
        //            if (userD != null)
        //                db.Doctors.Remove(userD);
        //            else
        //            {
        //                Manager userM = db.Managers.Find(id);
        //                if (userM != null)
        //                    db.Managers.Remove(userM);
        //                else
        //                {
        //                    Patient userP = db.Patients.Find(id);
        //                    if (userP != null)
        //                        db.Patients.Remove(userP);
        //                }
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception e) { throw new Exception(e.Message); }

        //}
        public void DeleteDoctor(int id)
        {
                try
                {
                    using (var db = new MediKalDB())
                    {
                        Doctor doctor = db.Doctors.First(d => d.Id == id);
                        db.Doctors.Remove(doctor);
                        db.SaveChanges();
                    }
                }
                catch (Exception e) { throw new Exception(e.Message); }
            }

        public void DeleteManager(int id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    Manager manager = db.Managers.First(d => d.Id == id);
                    db.Managers.Remove(manager);
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        #endregion
        #region GET
        public IEnumerable<Medicine> GetMedicines()
        {
            //try
            //{
                List<Medicine> result = new List<Medicine>();
                using (var db = new MediKalDB())
                {
                    foreach (var medicine in db.Medicines)
                    {
                        result.Add(medicine);
                    }
                }
                return result;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}

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
            //try
            //{
                List<Prescription> result = new List<Prescription>();
                using (var db = new MediKalDB())
                {
                    foreach (var prescription in db.Prescriptions)
                    {
                        result.Add(prescription);
                    }
                }
                return result;
            //}
            //catch (Exception e) { throw new Exception(e.Message); }

        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                List<User> result = new List<User>();
                using (var db = new MediKalDB())
                {
                    foreach (var d in db.Doctors)
                    {
                        User user = new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType ,PrimaryId = d.PrimaryId};
                        result.Add(user);
                    }
                    foreach (var d in db.Managers)
                    {
                        User user = new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };
                        result.Add(user);
                    }
                    foreach (var d in db.Patients)
                    {
                        User user = new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };
                        result.Add(user);
                    }
                }
                return result;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public IEnumerable<Doctor> GetDoctors()
        {
            try
            {
                List<Doctor> result = new List<Doctor>();
                using (var db = new MediKalDB())
                {
                    foreach (var doctor in db.Doctors)
                    {
                        result.Add(doctor);
                    }
                }
                return result;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public IEnumerable<Manager> GetManagers()
        {
            try
            {
                List<Manager> result = new List<Manager>();
                using (var db = new MediKalDB())
                {
                    foreach (var manager in db.Managers)
                    {
                        result.Add(manager);
                    }
                }
                return result;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        #endregion
        #region UPDATE
        public void UpdateMedicine(Medicine medicine, string NDCId)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Medicines.First(m => m.NDCId == NDCId);
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
                    tmp.Password = patient.Password;
                    tmp.Mail = patient.Mail;
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

        //public void UpdateUser(User user, int Id)
        //{
        //    try
        //    {
        //        using (var db = new MediKalDB())
        //        {
        //            var tmp = db.Users.First(u => u.Id == Id);
        //            tmp.Birthday = user.Birthday;
        //            tmp.Mail = user.Mail;
        //            tmp.Password = user.Password;
        //            tmp.Phone = user.Phone;
        //            tmp.UserName = user.UserName;
        //            tmp.UserType = user.UserType;
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception e) { throw new Exception(e.Message); }
        //}

        public void UpdateDoctor(Doctor doctor, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Doctors.First(d => d.Id == Id);
                    tmp.Birthday = doctor.Birthday;
                    tmp.Mail = doctor.Mail;
                    tmp.Password = doctor.Password;
                    tmp.Phone = doctor.Phone;
                    tmp.UserName = doctor.UserName;
                    tmp.UserType = doctor.UserType;
                    tmp.LicenseNum = doctor.LicenseNum;
                    tmp.Specialty = doctor.Specialty;
                    tmp.Password = doctor.Password;
                    tmp.Mail = doctor.Mail;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdateManager(Manager manager, int Id)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    var tmp = db.Managers.First(m => m.Id == Id);
                    tmp.Birthday = manager.Birthday;
                    tmp.Mail = manager.Mail;
                    tmp.Password = manager.Password;
                    tmp.Phone = manager.Phone;
                    tmp.UserName = manager.UserName;
                    tmp.UserType = manager.UserType;
                    db.SaveChanges();
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void ReadExcelMedicines(string path, int sheet)
        {
            path = $"~/DAL/MedicinesExcel/my version.xls";

            Excel excel = new Excel(System.Web.HttpContext.Current.Server.MapPath(path).Replace(@"MediKal\MediKal\DAL\MedicinesExcel\my version.xls", @"MediKal\DAL\MedicinesExcel\my version.xls"), 1);
            Medicine medicine ;
            for (int i = 2; i < 102; i++)
            {
                medicine = new Medicine();
                medicine.NDCId = excel.ReadCell(i, 1);
                medicine.Name = excel.ReadCell(i, 2);
                medicine.Company = excel.ReadCell(i, 3);
                medicine.GenericName = excel.ReadCell(i, 4);
                medicine.ServingOption = excel.ReadCell(i, 5);
                AddMedicine(medicine);
            }
        }
        public Medicine FindMedicineInExcel(string NDCId)
        {
            if (NDCId.Length != 9)
                return null;
            if (NDCId[4] != '-') 
                return null;
            string startupPath = Environment.CurrentDirectory;
            string path = $"~/DAL/MedicinesExcel/my version.xls";
            
            Excel excel = new Excel(System.Web.HttpContext.Current.Server.MapPath(path).Replace(@"MediKal\MediKal\DAL\MedicinesExcel\my version.xls", @"MediKal\DAL\MedicinesExcel\my version.xls"), 1);
            Medicine medicine;
            double id = Double.Parse(NDCId.Replace("-", "."));
            int i = BinarySearch(excel,id, 2, 16384);
            if (i != -1)
                {
                    medicine = new Medicine();
                    medicine.NDCId = excel.ReadCell(i, 1);
                    medicine.Name = excel.ReadCell(i, 2);
                    medicine.Company = excel.ReadCell(i, 3);
                    medicine.GenericName = excel.ReadCell(i, 4);
                    medicine.ServingOption = excel.ReadCell(i, 5);
                    return medicine;
                }
            return null;
        }
        int BinarySearch(Excel excel, double x, int left, int right)
        {
            if (left > right)
                return -1;

            int middle = (left + right) / 2;
            if (Double.Parse(excel.ReadCell(middle, 1).Replace("-", ".")) == x)
                return middle;

            if (x < Double.Parse(excel.ReadCell(middle, 1).Replace("-", ".")))
                return BinarySearch(excel,x, left, middle - 1);

            return BinarySearch(excel,x, middle + 1, right);
        }


        #endregion


    }
}
