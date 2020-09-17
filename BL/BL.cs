using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    class BL : IBL
    {
        public void AddMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void AddPrescription(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedicine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePrescription(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients()
        {
            throw new NotImplementedException();
        }

        public Prescription GetPrescriptionById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
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

        public void UpdateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
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
