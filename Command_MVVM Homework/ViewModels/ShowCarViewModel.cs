using Command_MVVM_Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_MVVM_Homework.ViewModels
{
    public class ShowCarViewModel
    {
        public Car SelectedCar { get; set; } = new();

        public ShowCarViewModel()
        {
            
        }

    }
}
