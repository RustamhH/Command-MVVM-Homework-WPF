using Command_MVVM_Homework.Commands;
using Command_MVVM_Homework.Models;
using Command_MVVM_Homework.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Command_MVVM_Homework.ViewModels
{
    public class EditCarViewModel
    {
        public Car EditedCar { get; set; } = new();


        public RealCommand SaveChangesCommand { get; set; }


        public EditCarViewModel()
        {
            SaveChangesCommand = new(SaveChanges);
        }


        public void SaveChanges(object? param)
        {
            
        }


    }
}
