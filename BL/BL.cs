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

        public void AddMedicine(Medicine medicine)
        {
            if (!Validation.IsNDCId(medicine.NDCId))
                throw new Exception("ת.ז. זו קיימת כבר");
            dal.AddMedicine(medicine);
        }

        public void AddPatient(Patient patient)
        {
            if(!Validation.ValidIdDB(patient.Id))
                throw new Exception("ת.ז. זו קיימת כבר");
            if (!Validation.IsEmail(patient.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.AddPatient(patient);
        }

        public void AddPrescription(Prescription prescription)
        {
            dal.AddPrescription(prescription);
        }

        public void AddManager(Manager manager)
        {
            if (!Validation.ValidIdDB(manager.Id))
                throw new Exception("ת.ז. זו קיימת כבר");
            if (!Validation.IsEmail(manager.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.AddManager(manager);
        }

        public void DeleteMedicine(double NDCid)
        {
            dal.DeleteMedicine(NDCid);
        }

        public void DeletePatient(int id)
        {
            dal.DeletePatient(id);
        }

        public void DeletePrescription(int id)
        {
            dal.DeletePrescription(id);
        }

        //public void DeleteUser(int id)
        //{
        //    dal.DeleteUser(id);
        //}

        public void ForgotPassword(string mail)
        {
            throw new NotImplementedException();
        }

        public List<Warning> GetConflicts(double medicineId, int patientId)
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicineById(double NDCid)
        {
            return dal.GetMedicines().FirstOrDefault(item => item.NDCId == NDCid);
        }
        public Medicine GetMedicineByPrimaryId(int id)
        {
            return dal.GetMedicines().FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return dal.GetMedicines();
        }

        public Patient GetPatientById(int id)
        {
            return dal.GetPatients().FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return dal.GetPatients();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return dal.GetPrescriptions().FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            return dal.GetPrescriptions();
        }

        public IEnumerable<Prescription> GetPrescriptionsOfDoctor(int id)
        {
            var prescriptions = dal.GetPrescriptions();
            return from item in prescriptions
                   where item.DoctorId == id
                   select item;
        }

        public IEnumerable<Prescription> GetPrescriptionsOfPatient(int id)
        {
            var prescriptions = dal.GetPrescriptions();
            return from item in prescriptions
                   where item.PatientId == id
                   select item;
        }

        public User GetUserById(int id)
        {
            try
            {
                return GetUsers().FirstOrDefault(item => item.Id == id);
            }
            catch (ArgumentNullException e) { throw e; }
        }

        public IEnumerable<User> GetUsers()
        {
            return dal.GetUsers();
        }

        public bool IsMedicineImage(string imagePath)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void SendMail(string mailAdress, string receiverName, string message)
        {
            MailMessage mail;
            SmtpClient smtp;
            mail = new MailMessage();
            mail.To.Add(mailAdress);//dam@zichron.org
            mail.From = new MailAddress("deamlandapp@gmail.com");
            mail.Body = $"שלום {receiverName}, <br>" + message;
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
            try
            {
                var client = new Client(creds: new Nexmo.Api.Request.Credentials
                {
                    ApiKey = "458e9f53",
                    ApiSecret = "yFQBWJUuLGPsYiH3"
                });
                var results = client.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "Vonage APIs",
                    to = "972" + (int.Parse(phoneNumber)).ToString(),
                    text = $"Hello,{receiverName}!\n{message}",
                    type = "unicode"

                });
                return true;
            } catch(Exception e) { throw new Exception(e.Message); }
        }

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
                throw new Exception("מספר ת.ז לא תקין");
            if (GetUserById(newUser.Id) == null)
                throw new Exception("אינך רשום במערכת, אנא פנה למנהל");
            if (newUser.UserType == UserTypeEnum.Doctor)
                dal.UpdateDoctor((Doctor) newUser, newUser.Id);
            if (newUser.UserType == UserTypeEnum.Manager)
                dal.UpdateManager((Manager)newUser, newUser.Id);
            if (newUser.UserType == UserTypeEnum.Patient)
                dal.UpdatePatient((Patient)newUser, newUser.Id);
        }
        public void UpdateMedicine(Medicine medicine,double NDCId)
        {
            dal.UpdateMedicine(medicine,NDCId);
        }

        public void UpdatePatient(Patient patient, int Id)
        {
            if (!Validation.IsEmail(patient.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.UpdatePatient(patient,Id);
        }

        public void UpdatePrescription(Prescription prescription, int Id)
        {
            dal.UpdatePrescription(prescription,Id);
        }

        //public void UpdateUser(User user, int Id)
        //{
        //    dal.UpdateUser(user,Id);
        //}
        public IEnumerable<Doctor> GetDoctors()
        {
            return dal.GetDoctors();
        }
        public IEnumerable<Manager> GetManagers()
        {
            return dal.GetManagers();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!Validation.ValidIdDB(doctor.Id))
                throw new Exception("ת.ז. זו קיימת כבר");
            if(!Validation.IsEmail(doctor.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.AddDoctor(doctor);
        }


        public void UpdateDoctor(Doctor doctor, int Id)
        {
            if (!Validation.IsEmail(doctor.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.UpdateDoctor(doctor, Id);
        }

        public void UpdateManager(Manager manager, int Id)
        {
            if (!Validation.IsEmail(manager.Mail))
                throw new Exception("כתובת מייל לא חוקית");
            dal.UpdateManager(manager, Id);
        }

        public void DeleteDoctor(int id)
        {
            dal.DeleteDoctor(id);
        }

        public void DeleteManager(int id)
        {
            dal.DeleteManager(id);
        }

        public Doctor GetDoctorById(int id)
        {
            var doctors = dal.GetDoctors();
            return (from item in doctors
                    where item.Id == id
                    select item).FirstOrDefault();
        }

        public Manager GetManagerById(int id)
        {
            var managers = dal.GetManagers();
            return (from item in managers
                    where item.Id == id
                    select item).FirstOrDefault();
        }

        public void ReadExcelMedicines(string path, int sheet)
        {
            dal.ReadExcelMedicines(path,sheet);
        }

        public Medicine FindMedicineInExcel(string NDCId)
        {
            try
            {
                return dal.FindMedicineInExcel(NDCId);
            }
            catch (Exception e) { throw e; }
        }
        public Doctor ConvertUserToDoctor(User user)
        {
            Doctor tmp = new Doctor();
            tmp.Birthday = user.Birthday;
            tmp.Mail = user.Mail;
            tmp.Password = user.Password;
            tmp.Phone = user.Phone;
            tmp.UserName = user.UserName;
            tmp.UserType = user.UserType;
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
            return tmp;
        }
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
            if (idn == null || idn == "000000000")
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

    }
}
