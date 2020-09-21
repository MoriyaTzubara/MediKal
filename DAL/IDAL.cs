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
        void AddUser(User user);
        void AddMedicine(Medicine medicine);
        void AddPatient(Patient patient);
        void AddPrescription(Prescription prescription);
        // UPDATE
        void UpdateUser(User user, int Id);
        void UpdateMedicine(Medicine medicine, int Id);
        void UpdatePatient(Patient patient, int Id);
        void UpdatePrescription(Prescription prescription, int Id);
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
    }
}
