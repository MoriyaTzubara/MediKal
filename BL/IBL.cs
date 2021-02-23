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
        void AddDoctor(Doctor doctor);
        void AddManager(Manager manager);
        void AddMedicine(Medicine medicine);
        void AddPatient(Patient patient);
        void AddPrescription(Prescription prescription);
        // UPDATE
        void UpdateDoctor(Doctor doctor, int Id);
        void UpdateManager(Manager manager, int Id);
        void UpdateMedicine(Medicine medicine, string NDCId);
        void UpdatePatient(Patient patient, int Id);
        // DELETE
        void DeleteDoctor(int id);
        void DeleteManager(int id);
        void DeletePatient(int id);
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
        Doctor GetDoctorByPrimaryId(int PrimaryId);
        Manager GetManagerById(int id);
        Medicine GetMedicineById(string NDCid);
        Medicine GetMedicineByPrimaryId(int id);
        Patient GetPatientById(int id);
        Patient GetPatientByPrimaryId(int PrimaryId);
        Prescription GetPrescriptionById(int id);
        // FILTER
        IEnumerable<Prescription> GetPrescriptionsOfPatient(int id);
        IEnumerable<Prescription> GetPrescriptionsOfDoctor(int id);
        IEnumerable<string> GetMedicinesOfPatient(int id);
        Dictionary<string,int> GetStatisticMedicine(int medicineId, DateTime StartDate, DateTime EndDate);
       // MEDICINES HELPERS
        Medicine FindMedicineInExcel(string NDCId);
        void ReadExcelMedicines(string path, int sheet);
        // SEND
        void SendMail(string mailAdress, string receiverName, string message);
        bool SendSMS(string phoneNumber, string receiverName, string message);
        // ACCOUNT
        User SignIn(int id, string password);
        void SignUp(User newUser);
        // CONVERT
        Patient ConvertUserToPatient(User user);
        Doctor ConvertUserToDoctor(User user);
        // VALIDATION
        bool IsId(object idn);
        bool IsEmail(string s);
        bool IsName(string s);
        bool IsUserName(string s);
    }
}
