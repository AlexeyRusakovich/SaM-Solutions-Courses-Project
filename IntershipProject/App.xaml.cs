using IntershipProject.Models;
using IntershipProject.ViewModels;
using IntershipProject.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace IntershipProject
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer unityContainer = new UnityContainer();



            #region Setting views datacontext
            
            MainViewModel mainViewModel = unityContainer.Resolve<MainViewModel>();

            mainViewModel.appAuthorization = new AppAuthorizationView() { DataContext = unityContainer.Resolve<AppAuthorizationViewModel>() };
            mainViewModel.customers = new CustomersView() { DataContext = unityContainer.Resolve<CustomersViewModel>()  };
            mainViewModel.orderRegistration = new OrdersRegistrationView() { DataContext = unityContainer.Resolve<OrdersRegistrationViewModel>() };
            mainViewModel.ordersSearch = new OrdersSearchView() { DataContext = unityContainer.Resolve<OrdersQueueViewModel>() };
            mainViewModel.ordersQueue = new OrdersQueueView() { DataContext = unityContainer.Resolve<OrdersSearchViewModel>() };
            mainViewModel.ordersHistoryView = new OrdersHistoryView() { DataContext = unityContainer.Resolve<OrdersHistoryViewModel>() };

            mainViewModel.changeWindowContentFunc(MainViewModel.Pages.CUSTOMERS);

            MainView mainView = new MainView() { DataContext = mainViewModel };

            #endregion


            mainView.Show();
        }
    }
}
