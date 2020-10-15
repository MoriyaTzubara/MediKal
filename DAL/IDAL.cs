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
        void UpdateMedicine(Medicine medicine, string Id);
        void UpdatePatient(Patient patient, int Id);
        void UpdatePrescription(Prescription prescription, int Id);
        // DELETE
        //void DeleteUser(int id);
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
        void ReadExcelMedicines(string path, int sheet);
        Medicine FindMedicineInExcel(string NDCId);

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
    }
}
