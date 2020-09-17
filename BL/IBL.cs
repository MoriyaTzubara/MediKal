using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        // ADD
        void AddUser(User user);
        void AddMedicine(Medicine medicine);
        void AddPatient(Patient patient);
        void AddPrescription(Prescription prescription);
        // UPDATE
        void UpdateUser(User user);
        void UpdateMedicine(Medicine medicine);
        void UpdatePatient(Patient patient);
        void UpdatePrescription(Prescription prescription);
        // DELETE
        void DeleteUser(int id);
        void DeleteMedicine(int id);
        void DeletePatient(int id);
        void DeletePrescription(int id);
        // GET
        IEnumerable<User> GetUsers();
        IEnumerable<Medicine> GetMedicines();
        IEnumerable<Patient> GetPatients();
        IEnumerable<Prescription> GetPrescriptions();
        // GET BY ID
        User GetUserById(int id);
        Medicine GetMedicineById(int id);
        Patient GetPatientById(int id);
        Prescription GetPrescriptionById(int id);
        // FILTER
        IEnumerable<Prescription> GetPrescriptionsOfPatient(int id);
        IEnumerable<Prescription> GetPrescriptionsOfDoctor(int id);
        // VALIDATION
        bool IsMedicineImage(string imagePath);
        List<Warning> GetConflicts(int medicineId, int patientId);
        // SEND
        void SendMail(string mailAdress, string receiverName, string message);
        void SendSMS(string phoneNumber, string receiverName, string message);
        // ACCOUNT
        void SignIn(string userName, string password);
        void SignUp(User newUser);
        void LogOut();
        void ForgotPassword(string mail);

    }
}
