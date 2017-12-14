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

        public Visibility HistoryErrorStringVisibility
        {
            get { return (Visibility)GetValue(HistoryErrorStringVisibilityProperty); }
            set { SetValue(HistoryErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryErrorStringVisibilityProperty =
            DependencyProperty.Register("HistoryErrorStringVisibility", typeof(Visibility), typeof(OrdersSearchViewModel), new PropertyMetadata(Visibility.Collapsed));



        public string HistoryErrorStringContent
        {
            get { return (string)GetValue(HistoryErrorStringContentProperty); }
            set { SetValue(HistoryErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryErrorStringContentProperty =
            DependencyProperty.Register("HistoryErrorStringContent", typeof(string), typeof(OrdersSearchViewModel), new PropertyMetadata(null));


        #endregion

        #region Waiting Rind Properties

        public bool IsHistoryWaitingRingActive
        {
            get { return (bool)GetValue(IsHistoryWaitingRingActiveProperty); }
            set { SetValue(IsHistoryWaitingRingActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaitingRingActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHistoryWaitingRingActiveProperty =
            DependencyProperty.Register("IsHistoryWaitingRingActive", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));



        public Visibility HistoryWaitingRingVisibility
        {
            get { return (Visibility)GetValue(HistoryWaitingRingVisibilityProperty); }
            set { SetValue(HistoryWaitingRingVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaitingRingVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryWaitingRingVisibilityProperty =
            DependencyProperty.Register("HistoryWaitingRingVisibility", typeof(Visibility), typeof(OrdersSearchViewModel), new PropertyMetadata(Visibility.Collapsed));


        #endregion

        #region Selected items

        public Customers HistorySelectedConcreteCustomer
        {
            get { return (Customers)GetValue(HistorySelectedConcreteCustomerProperty); }
            set { SetValue(HistorySelectedConcreteCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistorySelectedConcreteCustomerProperty =
            DependencyProperty.Register("HistorySelectedConcreteCustomer", typeof(Customers), typeof(OrdersSearchViewModel), new PropertyMetadata(null));


        public String HistorySelectedConcreteCompany
        {
            get { return (String)GetValue(HistorySelectedConcreteCompanyProperty); }
            set { SetValue(HistorySelectedConcreteCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedConcreteCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistorySelectedConcreteCompanyProperty =
            DependencyProperty.Register("HistorySelectedConcreteCompany", typeof(String), typeof(OrdersSearchViewModel), new PropertyMetadata(null));


        #endregion

        #region Radio buttons properties

        public bool IsHistoryCheckBoxChecked
        {
            get { return (bool )GetValue(IsHistoryCheckBoxCheckedProperty); }
            set { SetValue(IsHistoryCheckBoxCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHistoryCheckBoxCheckedProperty =
            DependencyProperty.Register("IsHistoryCheckBoxChecked", typeof(bool ), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));

        public bool IsHistoryConcreteClientChecked
        {
            get { return (bool)GetValue(IsHistoryConcreteClientCheckedProperty); }
            set { SetValue(IsHistoryConcreteClientCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteClientChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHistoryConcreteClientCheckedProperty =
            DependencyProperty.Register("IsHistoryConcreteClientChecked", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));



        public bool IsHistoryConcreteCompanyChecked
        {
            get { return (bool)GetValue(IsHistoryConcreteCompanyCheckedProperty); }
            set { SetValue(IsHistoryConcreteCompanyCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteCompanyChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHistoryConcreteCompanyCheckedProperty =
            DependencyProperty.Register("IsHistoryConcreteCompanyChecked", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));

        #endregion

        #region Collection properties
        

        public ObservableCollection<Orders> HistoryOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(HistoryOrdersProperty); }
            set { SetValue(HistoryOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryOrdersProperty =
            DependencyProperty.Register("HistoryOrders", typeof(ObservableCollection<Orders>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));
        


        public ObservableCollection<Customers> HistoryCustomers
        {
            get { return (ObservableCollection<Customers>)GetValue(HistoryCustomersProperty); }
            set { SetValue(HistoryCustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryCustomersProperty =
            DependencyProperty.Register("HistoryCustomers", typeof(ObservableCollection<Customers>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));



        public ObservableCollection<String> HistoryCompanies
        {
            get { return (ObservableCollection<String>)GetValue(HistoryCompaniesProperty); }
            set { SetValue(HistoryCompaniesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Companies.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryCompaniesProperty =
            DependencyProperty.Register("HistoryCompanies", typeof(ObservableCollection<String>), typeof(OrdersHistoryViewModel), new PropertyMetadata(null));











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
            IsHistoryWaitingRingActive = true;
            HistoryWaitingRingVisibility = Visibility.Visible;

            if (!IsHistoryCheckBoxChecked)
            {

                HistoryCustomers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                HistoryCompanies = new ObservableCollection<String>(await OrdersModel.getCompaniesByUserId());
            }
            else if (IsHistoryCheckBoxChecked)
            {
                HistoryCustomers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomers());
                HistoryCompanies = new ObservableCollection<String>(await OrdersModel.getAllСompanies());
            }


            IsHistoryWaitingRingActive = false;
            HistoryWaitingRingVisibility = Visibility.Collapsed;
        }

        private void CheckBoxCheckedHandlerObj()
        {
            CheckBoxCheckedHandler(null);
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
            HistoryWaitingRingVisibility = Visibility.Visible;
            IsHistoryWaitingRingActive = true;
            HistoryErrorStringVisibility = Visibility.Collapsed;

            if (await DatabaseConnectionChecker.IsConnected())
            {
                if (IsHistoryCheckBoxChecked)
                {
                    if (IsHistoryConcreteClientChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrdersByCustomerId(HistorySelectedConcreteCustomer.Id));
                    }
                    else if (IsHistoryConcreteCompanyChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrdersByCompanyName(HistorySelectedConcreteCompany));
                    }
                    else if (!IsHistoryConcreteClientChecked && !IsHistoryConcreteCompanyChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrders());
                    }
                }
                else if (!IsHistoryCheckBoxChecked)
                {
                    if (IsHistoryConcreteClientChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByCustomerIdAndUserId(HistorySelectedConcreteCustomer.Id));
                    }
                    else if (IsHistoryConcreteCompanyChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getHistoryOrdersByCompanyNameAndUserId(HistorySelectedConcreteCompany));
                    }
                    else if (!IsHistoryConcreteClientChecked && !IsHistoryConcreteCompanyChecked)
                    {
                        HistoryOrders = new ObservableCollection<Orders>(await OrdersModel.getAllHistoryOrdersByUserId());
                    }
                }
            }
            else
            {
                HistoryErrorStringContent = "Отсутствует подключение к БД.";
                HistoryErrorStringVisibility = Visibility.Visible;
            }

            HistoryWaitingRingVisibility = Visibility.Collapsed;
            IsHistoryWaitingRingActive = false;

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
            IsHistoryCheckBoxChecked = false;
            IsHistoryConcreteClientChecked = false;
            IsHistoryConcreteCompanyChecked = false;
            HistorySelectedConcreteCompany = null;
            HistorySelectedConcreteCustomer = null;
        }

        #endregion

        #endregion

    }
}
