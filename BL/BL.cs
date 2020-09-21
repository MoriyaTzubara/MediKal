using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BL : IBL
    {
        IDAL dal = new DAL.DAL();

        public void AddMedicine(Medicine medicine)
        {
            dal.AddMedicine(medicine);
        }

        public void AddPatient(Patient patient)
        {
            dal.AddPatient(patient);
        }

        public void AddPrescription(Prescription prescription)
        {
            dal.AddPrescription(prescription);
        }

        public void AddUser(User user)
        {
            dal.AddUser(user);
        }

        public void DeleteMedicine(int id)
        {
            dal.DeleteMedicine(id);
        }

        public void DeletePatient(int id)
        {
            dal.DeletePatient(id);
        }

        public void DeletePrescription(int id)
        {
            dal.DeletePrescription(id);
        }

        public void DeleteUser(int id)
        {
            dal.DeleteUser(id);
        }

        public void ForgotPassword(string mail)
        {
            throw new NotImplementedException();
        }

        public List<Warning> GetConflicts(int medicineId, int patientId)
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicineById(int id)
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
            throw new NotImplementedException();
        }

        public IEnumerable<Prescription> GetPrescriptionsOfPatient(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return dal.GetUsers().FirstOrDefault(item => item.Id == id);
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
            throw new NotImplementedException();
        }

        public void SendSMS(string phoneNumber, string receiverName, string message)
        {
            throw new NotImplementedException();
        }

        public void SignIn(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void SignUp(User newUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedicine(Medicine medicine,int Id)
        {
            dal.UpdateMedicine(medicine,Id);
        }

        public void UpdatePatient(Patient patient, int Id)
        {
            dal.UpdatePatient(patient,Id);
        }

        public void UpdatePrescription(Prescription prescription, int Id)
        {
            dal.UpdatePrescription(prescription,Id);
        }

        public void UpdateUser(User user, int Id)
        {
            dal.UpdateUser(user,Id);
        }
    }
}
