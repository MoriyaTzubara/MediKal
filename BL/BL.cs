using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Nexmo.Api;
using BE;
using DAL;

namespace BL
{
    public class BL : IBL
    {
        IDAL dal = new DAL.DAL();

        #region ADD

        public void AddDoctor(Doctor doctor)
        {
            if (!Validation.IsId(doctor.Id))
                throw new Exception("This ID isn't valid");
            if (!Validation.ValidIdDB(doctor.Id))
                throw new Exception("This ID already exists");
            if (!Validation.IsEmail(doctor.Mail))
                throw new Exception("This email isn't valid");
            dal.AddDoctor(doctor);
        }
        
        public void AddMedicine(Medicine medicine)
        {
            if (!Validation.IsNDCId(medicine.NDCId))
                throw new Exception("This ID already exists ");
            dal.AddMedicine(medicine);
        }

        public void AddPatient(Patient patient)
        {
            if (!Validation.IsId(patient.Id))
                throw new Exception("This ID isn't valid");
            if (!Validation.ValidIdDB(patient.Id))
                throw new Exception("This ID already exists ");
            if (!Validation.IsEmail(patient.Mail))
                throw new Exception("This email isn't valid");
            dal.AddPatient(patient);
        }

        public void AddPrescription(Prescription prescription)
        {
            dal.AddPrescription(prescription);
        }

        public void AddManager(Manager manager)
        {
            if (!Validation.IsId(manager.Id))
                throw new Exception("This ID isn't valid");
            if (!Validation.ValidIdDB(manager.Id))
                throw new Exception("This ID already exists");
            if (!Validation.IsEmail(manager.Mail))
                throw new Exception("This email isn't valid");
            dal.AddManager(manager);
        }

        #endregion
        #region DELETE

        public void DeletePatient(int id)
        {
            dal.DeletePatient(id);
        }
        
        public void DeleteDoctor(int id)
        {
            dal.DeleteDoctor(id);
        }

        public void DeleteManager(int id)
        {
            dal.DeleteManager(id);
        }
        
        #endregion
        #region UPDATE
        
        public void UpdateMedicine(Medicine medicine, string NDCId)
        {
            dal.UpdateMedicine(medicine, NDCId);
        }

        public void UpdatePatient(Patient patient, int Id)
        {
            if (!Validation.IsEmail(patient.Mail))
                throw new Exception("This email isn't valid");
            dal.UpdatePatient(patient, Id);
        }
        
        public void UpdateDoctor(Doctor doctor, int Id)
        {
            if (!Validation.IsEmail(doctor.Mail))
                throw new Exception("This email isn't valid");
            dal.UpdateDoctor(doctor, Id);
        }

        public void UpdateManager(Manager manager, int Id)
        {
            if (!Validation.IsEmail(manager.Mail))
                throw new Exception("This email isn't valid");
            dal.UpdateManager(manager, Id);
        }

        #endregion
        #region GET
        
        public IEnumerable<Doctor> GetDoctors()
        {
            return dal.GetDoctors();
        }
        
        public IEnumerable<Manager> GetManagers()
        {
            return dal.GetManagers();
        }
        
        public IEnumerable<Medicine> GetMedicines()
        {
            return dal.GetMedicines();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return dal.GetPatients();
        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            return dal.GetPrescriptions();
        }
        
        public IEnumerable<User> GetUsers()
        {
            return dal.GetUsers();
        }
        
        #endregion
        #region GET BY ID
        
        public Medicine GetMedicineById(string NDCid)
        {
            return dal.GetMedicineById(NDCid);
        }
        
        public Medicine GetMedicineByPrimaryId(int id)
        {
            return dal.GetMedicineByPrimaryId(id);
        }
        
        public Patient GetPatientByPrimaryId(int PrimaryId)
        {
            return dal.GetPatientByPrimaryId(PrimaryId);
        }

        public Patient GetPatientById(int id)
        {
            return dal.GetPatientById(id);
        }
        
        public Prescription GetPrescriptionById(int id)
        {
            return dal.GetPrescriptionById(id);
        }
        
        public Doctor GetDoctorById(int id)
        {
            return dal.GetDoctorById(id);
        }
        
        public Doctor GetDoctorByPrimaryId(int PrimaryId)
        {
            return dal.GetDoctorByPrimaryId(PrimaryId);
        }
        
        public Manager GetManagerById(int id)
        {
            return dal.GetManagerById(id);
        }
        
        public User GetUserById(int id)
        {
            try
            {
                return dal.GetUserById(id);
            }
            catch (ArgumentNullException e) { throw e; }
        }
        
        #endregion
        #region FILTER
        
        public IEnumerable<Prescription> GetPrescriptionsOfDoctor(int PrimaryId)
        {
            return dal.GetPrescriptionsOfDoctor(PrimaryId);
        }

        public IEnumerable<Prescription> GetPrescriptionsOfPatient(int PrimaryId)
        {
            return dal.GetPrescriptionsOfPatient(PrimaryId);
        }
        
        public IEnumerable<string> GetMedicinesOfPatient(int id)
        {
            return dal.GetMedicinesOfPatient(id);
        }
        
        public IEnumerable<Prescription> GetPrescriptionsOfMedicine(int medicineId)
        {
            return dal.GetPrescriptionsOfMedicine(medicineId);
        }
        
        public Dictionary<string, int> GetStatisticMedicine(int medicineId, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetStatisticMedicine(medicineId, StartDate, EndDate);
        }
        
        #endregion
        #region ACCOUNT
        
        public User SignIn(int id, string password)
        {
            User user = GetUserById(id);
            if (user != null && user.Password == password)
                return user;
            throw new Exception("user was not found");
        }

        public void SignUp(User newUser)
        {
            if (!Validation.IsId(newUser.Id))
                throw new Exception("This ID is't valid");
            if (GetUserById(newUser.Id) == null)
                throw new Exception("You are not registered, please contact the manager");
            if (newUser.UserType == UserTypeEnum.Doctor)
                dal.UpdateDoctor((Doctor)newUser, newUser.Id);
            if (newUser.UserType == UserTypeEnum.Manager)
                dal.UpdateManager((Manager)newUser, newUser.Id);
            if (newUser.UserType == UserTypeEnum.Patient)
                dal.UpdatePatient((Patient)newUser, newUser.Id);
        }
        
        #endregion
        #region SEND
        
        public void SendMail(string mailAdress, string receiverName, string message)
        {
            MailMessage mail;
            SmtpClient smtp;
            mail = new MailMessage();
            mail.To.Add(mailAdress);
            mail.From = new MailAddress("deamlandapp@gmail.com");
            mail.Body = $"Hello {receiverName}, <br>" + message;
            mail.IsBodyHtml = true;
            smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("deamlandapp@gmail.com", "0533151327");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch
            {
                throw new Exception("Send mail failed");
            }
        }

        public bool SendSMS(string phoneNumber, string receiverName, string message)
        {
           return dal.SendSMS(phoneNumber, receiverName, message);
        }
        
        #endregion
        #region MEDICINES HELPERS
        
        public void ReadExcelMedicines(string path, int sheet)
        {
            dal.ReadExcelMedicines(path, sheet);
        }

        public Medicine FindMedicineInExcel(string NDCId)
        {
            try
            {
                return dal.FindMedicineInExcel(NDCId);
            }
            catch (Exception e) { throw e; }
        }
        
        #endregion
        #region CONVERT
        
        public Doctor ConvertUserToDoctor(User user)
        {
            Doctor tmp = new Doctor();
            tmp.Birthday = user.Birthday;
            tmp.Mail = user.Mail;
            tmp.Password = user.Password;
            tmp.Phone = user.Phone;
            tmp.UserName = user.UserName;
            tmp.UserType = user.UserType;
            tmp.PrimaryId = user.PrimaryId;
            tmp.Id = user.Id;
            return tmp;
        }
        
        public Patient ConvertUserToPatient(User user)
        {
            Patient tmp = new Patient();
            tmp.Birthday = user.Birthday;
            tmp.Mail = user.Mail;
            tmp.Password = user.Password;
            tmp.Phone = user.Phone;
            tmp.UserName = user.UserName;
            tmp.UserType = user.UserType;
            tmp.PrimaryId = user.PrimaryId;
            tmp.Id = user.Id;
            return tmp;
        }
        
        #endregion
        #region VAIDATION
        
        public bool IsEmail(string s)
        {
            if (s == null || s == "")
                return false;
            if (s[0] == '@')
                return false;
            if (s.Contains('@') != true || s.Substring(s.IndexOf("@") + 1).Contains(".") != true)
                return false;
            foreach (var item in s)
            {
                if (item != '@' && item != '.' && item != '_' && !char.IsLetter(item) && char.IsWhiteSpace(item))
                    return false;
            }
            return true;
        }

        public bool IsId(object idn)
        {
            if (idn == null || idn.ToString() == "000000000")
                return false;
            string idnumber = "";
            if (idn is string)
                idnumber = idn.ToString();
            else if (idn is int)
                idnumber = idn.ToString();
            else
                return false;

            if (idnumber.Length != 9)
                return false;
            int[] id = new int[idnumber.Length];
            for (int i = 0; i < idnumber.Length; i++)
                id[i] = idnumber[i] - '0';
            for (int i = 1; i < 8; i = i + 2)
            {
                int a = id[i] * 2;
                if (a > 9)
                    a = (a % 10) + (a / 10);
                id[i] = a;
            }
            int sumOfDigits = 0;
            for (int i = 0; i < id.Length; i++)
                sumOfDigits += id[i];
            return sumOfDigits % 10 == 0;
        }

        public bool IsName(string s)
        {
            if (s == null || s == "")
                return false;
            foreach (var item in s)
            {
                if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                    return false;
            }
            return true;
        }

        public bool IsUserName(string s)
        {
            if (s == null || s == "")
                return false;
            int numbers = 0;
            foreach (var item in s)
            {
                if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                    numbers++;
            }
            if (numbers == s.Length)
                return false;
            return true;
        }
        
        #endregion

    }
}
