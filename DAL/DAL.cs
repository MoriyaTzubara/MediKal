using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using Nexmo.Api;

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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void AddDoctor(Doctor doctor)
        {
            try
            {
                using (var db = new MediKalDB())
                {
                    db.Doctors.Add(doctor);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AddManager(Manager manager)
        {
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

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
                        User user = new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };
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
                    tmp.ImagePath = medicine.ImagePath;
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
        
        #endregion
        #region MEDICINES HELPERS
        
        public void ReadExcelMedicines(string path, int sheet)
        {
            path = $"~/DAL/MedicinesExcel/my version.xls";

            Excel excel = new Excel(System.Web.HttpContext.Current.Server.MapPath(path).Replace(@"MediKal\MediKal\DAL\MedicinesExcel\my version.xls", @"MediKal\DAL\MedicinesExcel\my version.xls"), 1);
            Medicine medicine;
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
            int i = BinarySearch(excel, id, 2, 16384);
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
                return BinarySearch(excel, x, left, middle - 1);

            return BinarySearch(excel, x, middle + 1, right);
        }
        
        #endregion
        #region GET BY ID
        
        public User GetUserById(int id)
        {
            var result = new User();
            using (var db = new MediKalDB())
            {
                foreach (var d in db.Doctors)
                {
                    if (d.Id == id)
                        return new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };

                }
                foreach (var d in db.Managers)
                {
                    if (d.Id == id)
                        return new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };
                }
                foreach (var d in db.Patients)
                {
                    if (d.Id == id)
                        return new User(d.Id) { Birthday = d.Birthday, Mail = d.Mail, Password = d.Password, Phone = d.Phone, UserName = d.UserName, UserType = d.UserType, PrimaryId = d.PrimaryId };
                }
            }
            return result;
        }

        public Doctor GetDoctorById(int id)
        {
            var result = new Doctor();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Doctors
                        where item.Id == id
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Doctor GetDoctorByPrimaryId(int PrimaryId)
        {
            var result = new Doctor();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Doctors
                        where item.PrimaryId == PrimaryId
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Manager GetManagerById(int id)
        {
            var result = new Manager();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Managers
                        where item.Id == id
                        select item).FirstOrDefault();
            }
            return result;

        }

        public Medicine GetMedicineById(string NDCid)
        {
            var result = new Medicine();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Medicines
                        where item.NDCId == NDCid
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Patient GetPatientById(int id)
        {
            var result = new Patient();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Patients
                        where item.Id == id
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Patient GetPatientByPrimaryId(int PrimaryId)
        {
            var result = new Patient();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Patients
                        where item.PrimaryId == PrimaryId
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Prescription GetPrescriptionById(int id)
        {
            var result = new Prescription();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Prescriptions
                        where item.Id == id
                        select item).FirstOrDefault();
            }
            return result;
        }

        public Medicine GetMedicineByPrimaryId(int id)
        {
            var result = new Medicine();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Medicines
                        where item.Id == id
                        select item).FirstOrDefault();
            }
            return result;
        }
        
        #endregion
        #region FILTER

        public IEnumerable<Prescription> GetPrescriptionsOfPatient(int id)
        {
            var result = new List<Prescription>();
            using (var db = new MediKalDB())
            {
                result =( from item in db.Prescriptions
                       where item.PatientId == id
                       select item).ToList();
            }
            return result;
        }

        public IEnumerable<Prescription> GetPrescriptionsOfDoctor(int id)
        {
            var result = new List<Prescription>();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Prescriptions
                       where item.DoctorId == id
                       select item).ToList();
            }
            return result;
        }

        public IEnumerable<Prescription> GetPrescriptionsOfMedicine(int medicineId)
        {
            var result = new List<Prescription>();
            using (var db = new MediKalDB())
            {
                result = (from item in db.Prescriptions
                       where item.MedicineId == medicineId
                       select item).ToList();
            }
            return result;
        }

        public Dictionary<string, int> GetStatisticMedicine(int medicineId, DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
                return new Dictionary<string, int>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            using (var db = new MediKalDB())
            {
                var months = from item in db.Prescriptions
                             where item.MedicineId == medicineId &&
                                    item.PrescriptionDate >= StartDate &&
                                    item.PrescriptionDate <= EndDate
                             select item.PrescriptionDate;

                int count = ((EndDate.Year - StartDate.Year) * 12) + EndDate.Month - StartDate.Month;
                for (int i = 0; i <= count; i++)
                {
                    dictionary[StartDate.AddMonths(i).ToString("MMMM")] = 0;
                }

                foreach (var item in months)
                {
                    dictionary[item.ToString("MMMM")] += 1;
                }
            }
            return dictionary;
        }

        public IEnumerable<string> GetMedicinesOfPatient(int id)
        {
            var result = new List<string>();
            using (var db = new MediKalDB())
            {
                result = (from pres in db.Prescriptions
                       from med in db.Medicines
                       where pres.PatientId == id && med.Id == pres.MedicineId && pres.EndTime >= DateTime.Now
                       select med.NDCId).ToList();
            }
            return result;
        }
        
        #endregion
        #region SEND
        
        public bool SendSMS(string phoneNumber, string receiverName, string message)
        {
            try
            {
                var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = "5a98600c",
                    ApiSecret = "CCsPcyYQOl8Vo3TC"
                });
                var results = client.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "Vonage APIs",
                    to = "972" + phoneNumber.Substring(1,phoneNumber.Length - 1),
                    text = "Hello," + message
                });
                return true;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        
        #endregion
    }
}
