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
        //void AddUser(User user);
        void AddDoctor(Doctor doctor);
        void AddManager(Manager manager);
        void AddMedicine(Medicine medicine);
        void AddPatient(Patient patient);
        void AddPrescription(Prescription prescription);
        // UPDATE
        //void UpdateUser(User user, int Id);
        void UpdateDoctor(Doctor doctor, int Id);
        void UpdateManager(Manager manager, int Id);
        void UpdateMedicine(Medicine medicine, int Id);
        void UpdatePatient(Patient patient, int Id);
        void UpdatePrescription(Prescription prescription, int Id);
        // DELETE
        //void DeleteUser(int id);
        void DeleteDoctor(int id);
        void DeleteManager(int id);
        void DeleteMedicine(int id);
        void DeletePatient(int id);
        void DeletePrescription(int id);
        // GET
        IEnumerable<User> GetUsers();
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Manager> GetManagers();
        IEnumerable<Patient> GetPatients();
        IEnumerable<Medicine> GetMedicines();
        IEnumerable<Prescription> GetPrescriptions();
        // GET BY ID
        User GetUserById(int id);
        Doctor GetDoctorById(int id);
        Manager GetManagerById(int id);
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
        bool SendSMS(string phoneNumber, string receiverName, string message);
        // ACCOUNT
        void SignIn(string userName, string password);
        void SignUp(User newUser);
        void LogOut();
        void ForgotPassword(string mail);

    }
}
