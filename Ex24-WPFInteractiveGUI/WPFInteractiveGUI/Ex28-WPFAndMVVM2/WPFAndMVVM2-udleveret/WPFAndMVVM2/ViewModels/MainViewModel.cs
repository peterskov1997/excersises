﻿using System;
using System.Collections.Generic;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel
    {
        private PersonRepository personRepo = new PersonRepository();

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !

        public MainViewModel ()
        { 
            PersonsVM = new List<PersonViewModel>();
            GetAllVM();
        }

        public List<PersonViewModel> PersonsVM { get; set; }

        public void GetAllVM()
        {
            
            foreach (Person person in personRepo.GetAll())
            {
                PersonViewModel result = null;

                result = new PersonViewModel(person);

                PersonsVM.Add(result);
            }
        }

        public PersonViewModel SelectedPerson { get; set; }

    }
}