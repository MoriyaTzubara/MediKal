using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
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
        void UpdateMedicine(Medicine medicine, string Id);
        void UpdatePatient(Patient patient, int Id);
        // DELETE
        void DeleteDoctor(int id);
        void DeleteManager(int id);
        void DeletePatient(int id);
        // GET
        IEnumerable<User> GetUsers();
        IEnumerable<Patient> GetPatients();
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Manager> GetManagers();
        IEnumerable<Medicine> GetMedicines();
        IEnumerable<Prescription> GetPrescriptions();
        //GET BY ID
        User GetUserById(int id);
        Doctor GetDoctorById(int id);
        Doctor GetDoctorByPrimaryId(int PrimaryId);
        Manager GetManagerById(int id);
        Medicine GetMedicineById(string NDCid);
        Patient GetPatientById(int id);
        Patient GetPatientByPrimaryId(int PrimaryId);
        Prescription GetPrescriptionById(int id);
        Medicine GetMedicineByPrimaryId(int id);
        // FILTER
        IEnumerable<Prescription> GetPrescriptionsOfPatient(int id);
        IEnumerable<Prescription> GetPrescriptionsOfDoctor(int id);
        IEnumerable<Prescription> GetPrescriptionsOfMedicine(int medicineId);
        IEnumerable<string> GetMedicinesOfPatient(int id);
        Dictionary<string, int> GetStatisticMedicine(int medicineId, DateTime StartDate, DateTime EndDate);
        //SEND
        bool SendSMS(string phoneNumber, string receiverName, string message);
        //MEDICINES HELPERS
        void ReadExcelMedicines(string path, int sheet);
        Medicine FindMedicineInExcel(string NDCId);
    }
}
