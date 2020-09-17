using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MediKal.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DAL
{
    public class DAL : IDAL
    {
        public void AddMedicine(Medicine medicine)
        {
                using (var db = new MedicinesContext())
                {
                    db.Medicines.Add(medicine);
                    db.SaveChanges();
                }
        }

        public void AddPatient(Patient patient)
        {
            using (var db = new PatientsContext())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            using (var db = new PrescriptionsContext())
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (var db = new UsersContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteMedicine(int id)
        {
            using (var db = new MedicinesContext())
            {
                Medicine medicine = db.Medicines.Find(id);
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
        }

        public void DeletePatient(int id)
        {
            using (var db = new PatientsContext())
            {
                Patient patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public void DeletePrescription(int id)
        {
            using (var db = new PrescriptionsContext())
            {
                Prescription prescription = db.Prescriptions.Find(id);
                db.Prescriptions.Remove(prescription);
                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var db = new UsersContext())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            List<Medicine> result = new List<Medicine>();
            using (var db = new MedicinesContext())
            {
                foreach (var medicine in db.Medicines)
                {
                    result.Add(medicine);
                }
            }
            return result;
        }

        public IEnumerable<Patient> GetPatients()
        {
            List<Patient> result = new List<Patient>();
            using (var db = new PatientsContext())
            {
                foreach (var patient in db.Patients)
                {
                    result.Add(patient);
                }
            }
            return result;
        }

        public IEnumerable<Prescription> GetPrescriptions()
        {
            List<Prescription> result = new List<Prescription>();
            using (var db = new PrescriptionsContext())
            {
                foreach (var prescription in db.Prescriptions)
                {
                    result.Add(prescription);
                }
            }
            return result;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> result = new List<User>();
            using (var db = new UsersContext())
            {
                foreach (var user in db.Users)
                {
                    result.Add(user);
                }
            }
            return result;
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
