﻿using BE;
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
        private int Id
        {
            get { return medicine.Id; }
        }
        [DisplayName("Name")]
        public string UserName
        {
            get { return medicine.Name; }
            set { medicine.Name = value; }
        }
        [DisplayName("Generic name")]
        public string GenericName
        {
            get { return medicine.GenericName; }
            set { medicine.Name = value; }
        }
        [DisplayName("Active ingredients")]
        public string ActiveIngredients
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
        [DisplayName("Image path")]
        public string ImagePath
        {
            get { return medicine.ImagePath; }
            set { medicine.ImagePath = value; }
        }
    }
}