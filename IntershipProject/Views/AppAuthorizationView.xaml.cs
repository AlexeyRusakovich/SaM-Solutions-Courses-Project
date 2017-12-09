using IntershipProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity.Attributes;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace IntershipProject.Views
{
    /// <summary>
    /// Логика взаимодействия для AppAuthorizationView.xaml
    /// </summary>
    public partial class AppAuthorizationView : Page
    {
        public AppAuthorizationView()
        {
            InitializeComponent();
        }        

        [Dependency]
        public AppAuthorizationViewModel viewModel
        {
            set { DataContext = value; }
        }
    }
}
