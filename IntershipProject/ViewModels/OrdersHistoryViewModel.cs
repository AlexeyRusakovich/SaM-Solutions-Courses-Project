using IntershipProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IntershipProject.ViewModels
{
    class OrdersHistoryViewModel : DependencyObject
    {

        #region Constructor

        public OrdersHistoryViewModel()
        {
            AppAuthorizationViewModel.SuccessAuthorization += CheckBoxCheckedHandlerObj;

        }

        #endregion

        #region Dependency properties

        #region Error string properties

        public Visibility ErrorStringVisibility
        {
            get { return (Visibility)GetValue(ErrorStringVisibilityProperty); }
            set { SetValue(ErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringVisibilityProperty =
            DependencyProperty.Register("ErrorStringVisibility", typeof(Visibility), typeof(OrdersHistoryViewModel), new PropertyMetadata(Visibility.Collapsed));



        public string ErrorStringContent
        {
            get { return (string)GetValue(ErrorStringContentProperty); }
            set { SetValue(ErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringContentProperty =
            DependencyProperty.Register("ErrorStringContent", typeof(string), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));


        #endregion

        #region Waiting Rind Properties

        public bool IsWaitingRingActive
        {
            get { return (bool)GetValue(IsWaitingRingActiveProperty); }
            set { SetValue(IsWaitingRingActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaitingRingActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWaitingRingActiveProperty =
            DependencyProperty.Register("IsWaitingRingActive", typeof(bool), typeof(OrdersHistoryViewModel), new PropertyMetadata(false));



        public Visibility WaitingRingVisibility
        {
            get { return (Visibility)GetValue(WaitingRingVisibilityProperty); }
            set { SetValue(WaitingRingVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaitingRingVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaitingRingVisibilityProperty =
            DependencyProperty.Register("WaitingRingVisibility", typeof(Visibility), typeof(OrdersHistoryViewModel), new PropertyMetadata(Visibility.Collapsed));


        #endregion

        #region Selected items

        public Customers SelectedConcreteCustomer
        {
            get { return (Customers)GetValue(SelectedConcreteCustomerProperty); }
            set { SetValue(SelectedConcreteCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedConcreteCustomerProperty =
            DependencyProperty.Register("SelectedConcreteCustomer", typeof(Customers), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));


        public String SelectedConcreteCompany
        {
            get { return (String)GetValue(SelectedConcreteCompanyProperty); }
            set { SetValue(SelectedConcreteCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedConcreteCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedConcreteCompanyProperty =
            DependencyProperty.Register("SelectedConcreteCompany", typeof(String), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));


        #endregion

        #region Radio buttons properties

        public bool IsCheckBoxChecked
        {
            get { return (bool )GetValue(IsCheckBoxCheckedProperty); }
            set { SetValue(IsCheckBoxCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool ), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));

        public bool IsConcreteClientChecked
        {
            get { return (bool)GetValue(IsConcreteClientCheckedProperty); }
            set { SetValue(IsConcreteClientCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteClientChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConcreteClientCheckedProperty =
            DependencyProperty.Register("IsConcreteClientChecked", typeof(bool), typeof(OrdersHistoryViewModel), new PropertyMetadata(false));



        public bool IsConcreteCompanyChecked
        {
            get { return (bool)GetValue(IsConcreteCompanyCheckedProperty); }
            set { SetValue(IsConcreteCompanyCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteCompanyChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConcreteCompanyCheckedProperty =
            DependencyProperty.Register("IsConcreteCompanyChecked", typeof(bool), typeof(OrdersHistoryViewModel), new PropertyMetadata(false));

        #endregion

        #region Collection properties
        

        public ObservableCollection<Orders> Orders
        {
            get { return (ObservableCollection<Orders>)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ObservableCollection<Orders>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));
        


        public ObservableCollection<Customers> Customers
        {
            get { return (ObservableCollection<Customers>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomersProperty =
            DependencyProperty.Register("Customers", typeof(ObservableCollection<Customers>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));



        public ObservableCollection<String> Companies
        {
            get { return (ObservableCollection<String>)GetValue(CompaniesProperty); }
            set { SetValue(CompaniesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Companies.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompaniesProperty =
            DependencyProperty.Register("Companies", typeof(ObservableCollection<String>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));
        

        #endregion

        #endregion

        #region Commands & handlers

        #region CheckBox command & handlers

        private ICommand checkBoxChecked;

        public ICommand CheckBoxChecked
        {
            get
            {
                if (checkBoxChecked == null)
                    checkBoxChecked = new MyCommands(CheckBoxCheckedHandler);
                return checkBoxChecked;
            }
        }

        private async void CheckBoxCheckedHandler(object obj)
        {
            IsWaitingRingActive = true;
            WaitingRingVisibility = Visibility.Visible;

            if (!IsCheckBoxChecked)
            {

                Customers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                Companies = new ObservableCollection<String>(await OrdersModel.getCompaniesByUserId());
            }
            else if (IsCheckBoxChecked)
            {
                Customers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomers());
                Companies = new ObservableCollection<String>(await OrdersModel.getAllСompanies());
            }

            if (Customers.Count() != 0)
                foreach (var c in Customers)
                    c.ContactAdress = c.ContactAdress.Replace('\n', ' ');


            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;
        }

        private void CheckBoxCheckedHandlerObj()
        {
            CheckBoxCheckedHandler(null);
            searchOrdsersClickHandler(null);
        }

        #endregion

        #region Enter button command & handlers

        private ICommand searchOrders;
        public ICommand SearchOrders
        {
            get
            {
                if (searchOrders == null)
                    searchOrders = new MyCommands(searchOrdsersClickHandler);
                return searchOrders;
            }
        }
        private async void searchOrdsersClickHandler(object obj)
        {
            WaitingRingVisibility = Visibility.Visible;
            IsWaitingRingActive = true;
            ErrorStringVisibility = Visibility.Collapsed;

            if (await DatabaseConnectionChecker.IsConnected())
            {
                if (IsCheckBoxChecked)
                {
                    if (IsConcreteClientChecked && SelectedConcreteCustomer != null)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrdersByCustomerId(SelectedConcreteCustomer.Id));
                    }
                    else if (IsConcreteCompanyChecked && SelectedConcreteCompany != null)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrdersByCompanyName(SelectedConcreteCompany));
                    }
                    else if (!IsConcreteClientChecked && !IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrders());
                    }
                    else
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrders());
                }
                else if (!IsCheckBoxChecked)
                {
                    if (IsConcreteClientChecked && SelectedConcreteCustomer != null)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByCustomerIdAndUserId(SelectedConcreteCustomer.Id));
                    }
                    else if (IsConcreteCompanyChecked && SelectedConcreteCompany != null)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByCompanyNameAndUserId(SelectedConcreteCompany));
                    }
                    else if (!IsConcreteClientChecked && !IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByUserId());
                    }
                    else
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByUserId());
                }
            }
            else
            {
                ErrorStringContent = "Отсутствует подключение к БД.";
                ErrorStringVisibility = Visibility.Visible;
            }

            WaitingRingVisibility = Visibility.Collapsed;
            IsWaitingRingActive = false;

        }


        private ICommand cleanQuery;
        public ICommand CleanQuery
        {
            get
            {
                if (cleanQuery == null)
                    cleanQuery = new MyCommands(cleanQueryClickHandler);
                return cleanQuery;
            }
        }
        private void cleanQueryClickHandler(object obj)
        {
            IsCheckBoxChecked = false;
            IsConcreteClientChecked = false;
            IsConcreteCompanyChecked = false;
            SelectedConcreteCompany = null;
            SelectedConcreteCustomer = null;
        }

        #endregion

        #endregion

    }
}
