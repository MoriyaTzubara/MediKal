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
    }
}
