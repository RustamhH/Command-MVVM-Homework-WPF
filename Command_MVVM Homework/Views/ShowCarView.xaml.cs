using Command_MVVM_Homework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Command_MVVM_Homework.Views
{
    /// <summary>
    /// Interaction logic for ShowCarView.xaml
    /// </summary>
    public partial class ShowCarView : Window
    {
        public ShowCarView()
        {
            InitializeComponent();
            DataContext = new ShowCarViewModel();
        }
    }
}
