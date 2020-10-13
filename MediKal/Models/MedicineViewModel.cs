using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MediKal.Models
{
    public class MedicineViewModel
    {
        public Medicine medicine;

        public MedicineViewModel(Medicine _medicine)
        {
            medicine = _medicine;
        }
        public string NDCId
        {
            get { return medicine.NDCId; }
            set { medicine.NDCId = value; }
        }
        [DisplayName("Serving Option")]
        public string ServingOption
        {
            get { return medicine.ServingOption; }
            set { medicine.ServingOption = value; }
        }
        [DisplayName("Name")]
        public string Name
        {
            get { return medicine.Name; }
            set { medicine.Name = value; }
        }
        [DisplayName("Generic Name")]
        public string GenericName
        {
            get { return medicine.GenericName; }
            set { medicine.Name = value; }
        }
        [DisplayName("Active Ingredients")]
        public List<string> ActiveIngredients
        {
            get { return medicine.ActiveIngredients; }
            set { medicine.ActiveIngredients = value; }
        }
        [DisplayName("Company")]
        public string Company
        {
            get { return medicine.Company; }
            set { medicine.Company = value; }
        }
        [DisplayName("Image Path")]
        public string ImagePath
        {
            get { return medicine.ImagePath; }
            set { medicine.ImagePath = value; }
        }
    }
}