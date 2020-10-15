using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediKal.Models
{
    public static class Extensions
    {
        static public string GetHiddenMail(this string mail)
        {
            return mail.Replace(mail.Substring(4, mail.Length - 14), string.Concat(Enumerable.Repeat("*", mail.Length - 14)));
        }
        static public Patient GetPatient(this Prescription prescription)
        {
            IBL bl = new BL.BL();
            return bl.GetPatientByPrimaryId(prescription.PatientId);
        }
        static public Doctor GetDoctor(this Prescription prescription)
        {
            IBL bl = new BL.BL();
            return bl.GetDoctorByPrimaryId(prescription.DoctorId);
        }
        static public Medicine GetMedicine(this Prescription prescription)
        {
            IBL bl = new BL.BL();
            return bl.GetMedicineByPrimaryId(prescription.MedicineId);
        }
        static public int GetAge(this Patient user)
        {
            // Save today's date.
            var today = DateTime.Today;
            var birthdate = user.Birthday.GetValueOrDefault();
            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) 
                age--;
            return age;
        }
        static public MvcHtmlString DropDownEnumListForMedicines(this HtmlHelper htmlHelper, string name)
        {
            IBL bl = new BL.BL();
            var medicines = bl.GetMedicines();
            string options = "<option>Choose medicine...</option>";
            foreach (var item in medicines)
            {
                options += $"<option id='medicine{item.Id}' value ='{item.Id}' data-Name='{item.Name}' data-ServingOption='{item.ServingOption}'> {item.GenericName} </option>";
            }
            return new MvcHtmlString($"<select required name='{name}' id='medicines' class='medicinesSelect' >{options}</select>");

        }
    }
}