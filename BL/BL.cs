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
                return dal.GetUsers().First(item => item.Id == id);
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
                    select item).Single();
        }

        public Manager GetManagerById(int id)
        {
            var managers = dal.GetManagers();
            return (from item in managers
                    where item.Id == id
                    select item).Single();
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
    }
}
