using Bogus;
using Bogus.Bson;
using Command_MVVM_Homework.Commands;
using Command_MVVM_Homework.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Command_MVVM_Homework.Views;

namespace Command_MVVM_Homework.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Car>? Cars { get; set; } = new();
        public Car? SelectedCar { get; set; } = new();

        public RealCommand ?SaveCommand { get; set; }
        public RealCommand ?EditCommand { get; set; }
        public RealCommand ?ShowCommand { get; set; }
        public RealCommand ?DeleteCommand { get; set; }


        public MainViewModel()
        {
            Cars = GenerateFakeData(10);
            SaveCommand   =   new(Save);
            DeleteCommand =   new(Delete);
            ShowCommand   =   new(Show);
            EditCommand   =   new(Edit);
           
        }


        public ObservableCollection<Car> GenerateFakeData(int itemCount)
        {
            var faker = new Faker<Car>()
                .RuleFor(x=>x.Id,f=>f.Random.Guid())
                .RuleFor(x => x.Maker, f => f.Vehicle.Manufacturer())
                .RuleFor(x => x.Model, f => f.Vehicle.Model())
                .RuleFor(x => x.Year, f => f.Random.Int(1990,2023))
                .RuleFor(x => x.Engine, f => Convert.ToDouble(f.Random.Float(0,5).ToString("0.00")));


            var fakeData = faker.Generate(itemCount);
            return new ObservableCollection<Car>(fakeData);


            
        
        }



        public void Save(object? param)
        {
            try
            {
                JsonSerializerOptions op = new JsonSerializerOptions();
                op.WriteIndented = true;
                File.WriteAllText(SelectedCar.Model+".json",JsonSerializer.Serialize(SelectedCar, op));
                MessageBox.Show("Saved Succesfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void Delete(object?param)
        {
            if(MessageBox.Show("Are you sure?", "Deletion", MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                Cars.Remove(SelectedCar);
            }
            
        }

        public void Show(object?param)
        {
            ShowCarView showCarView = new();
            ShowCarViewModel scvm = showCarView.DataContext as ShowCarViewModel;
            scvm.SelectedCar = SelectedCar;
            showCarView.ShowDialog();
        }

        public void Edit(object?param)
        {
            EditCarView editCarView = new();
            EditCarViewModel ecvm = editCarView.DataContext as EditCarViewModel;
            ecvm.EditedCar = SelectedCar;
            editCarView.ShowDialog();
            SelectedCar = ecvm.EditedCar;
            
            
        }


    }
}
