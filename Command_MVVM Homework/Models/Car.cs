using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Command_MVVM_Homework.Models
{
    public class Car : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private Guid ? _id;

        public Guid? Id
        {
            get { return _id; }
            set { _id= value; OnPropertyChange(); }
        }




        private string? maker;

        public string? Maker
        {
            get { return maker; }
            set { maker = value; OnPropertyChange(); }
        }
        
        
        private string? model;

        public string? Model
        {
            get { return model; }
            set { model = value; OnPropertyChange(); }
        }


        private int year;

        public int Year
        {
            get { return year; }
            set {
                if (value < 0) return;
                year = value; OnPropertyChange();
            }
        }



        private double engine;

        public double Engine
        {
            get { return engine; }
            set 
            {
                if (value < 0) return;
                engine = value; OnPropertyChange();
            }
        }


        private void OnPropertyChange([CallerMemberName] string ?name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return $"{Maker} {Model} {Year} {Engine}";
        }


        public Car()
        {

        }

    }
}
