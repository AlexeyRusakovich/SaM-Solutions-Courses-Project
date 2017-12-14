using IntershipProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IntershipProject.ViewModels
{
    public class OrdersSearchViewModel : DependencyObject, IDataErrorInfo
    {
        #region Constuctor

        public OrdersSearchViewModel()
        {
            AppAuthorizationViewModel.SuccessAuthorization += checkBoxCheckedHandlerObject;
        }

        #endregion

        #region Dependency & other properties

        #region Waiting Rind Properties

        public bool IsWaitingRingActive
        {
            get { return (bool)GetValue(IsWaitingRingActiveProperty); }
            set { SetValue(IsWaitingRingActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaitingRingActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWaitingRingActiveProperty =
            DependencyProperty.Register("IsWaitingRingActive", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));



        public Visibility WaitingRingVisibility
        {
            get { return (Visibility)GetValue(WaitingRingVisibilityProperty); }
            set { SetValue(WaitingRingVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaitingRingVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaitingRingVisibilityProperty =
            DependencyProperty.Register("WaitingRingVisibility", typeof(Visibility), typeof(OrdersSearchViewModel), new PropertyMetadata(Visibility.Collapsed));


        #endregion

        #region Selected customers, status & companies properties

        public Customers SelectedConcreteCustomer
        {
            get { return (Customers)GetValue(SelectedConcreteCustomerProperty); }
            set { SetValue(SelectedConcreteCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedConcreteCustomerProperty =
            DependencyProperty.Register("SelectedConcreteCustomer", typeof(Customers), typeof(OrdersSearchViewModel), new PropertyMetadata(null));



        public String SelectedConcreteCompany
        {
            get { return (String)GetValue(SelectedConcreteCompanyProperty); }
            set { SetValue(SelectedConcreteCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedConcreteCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedConcreteCompanyProperty =
            DependencyProperty.Register("SelectedConcreteCompany", typeof(String), typeof(OrdersSearchViewModel), new PropertyMetadata(null));



        public string SelectedOrderStatus
        {
            get { return (string)GetValue(SelectedOrderStatusProperty); }
            set { SetValue(SelectedOrderStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedOrderStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedOrderStatusProperty =
            DependencyProperty.Register("SelectedOrderStatus", typeof(string), typeof(OrdersSearchViewModel), new PropertyMetadata(null));




        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(string), typeof(OrdersSearchViewModel), new PropertyMetadata(null));



        #endregion

        #region CheckBox & radioButton properties

        public bool IsCheckBoxChecked
        {
            get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
            set { SetValue(IsCheckBoxCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));



        public bool IsConcreteClientChecked
        {
            get { return (bool)GetValue(IsConcreteClientCheckedProperty); }
            set { SetValue(IsConcreteClientCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteClientChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConcreteClientCheckedProperty =
            DependencyProperty.Register("IsConcreteClientChecked", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));



        public bool IsConcreteCompanyChecked
        {
            get { return (bool)GetValue(IsConcreteCompanyCheckedProperty); }
            set { SetValue(IsConcreteCompanyCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteCompanyChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConcreteCompanyCheckedProperty =
            DependencyProperty.Register("IsConcreteCompanyChecked", typeof(bool), typeof(OrdersSearchViewModel), new PropertyMetadata(false));


        #endregion

        #region Error string properties

        public Visibility ErrorStringVisibility
        {
            get { return (Visibility)GetValue(ErrorStringVisibilityProperty); }
            set { SetValue(ErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringVisibilityProperty =
            DependencyProperty.Register("ErrorStringVisibility", typeof(Visibility), typeof(OrdersSearchViewModel), new PropertyMetadata(Visibility.Collapsed));



        public string ErrorStringContent
        {
            get { return (string)GetValue(ErrorStringContentProperty); }
            set { SetValue(ErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringContentProperty =
            DependencyProperty.Register("ErrorStringContent", typeof(string), typeof(OrdersSearchViewModel), new PropertyMetadata(null));


        #endregion

        #region Collections properties

        
        public ObservableCollection<Customers> ConctereCustomers
        {
            get { return (ObservableCollection<Customers>)GetValue(ConctereCustomersProperty); }
            set { SetValue(ConctereCustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConctereCustomers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConctereCustomersProperty =
            DependencyProperty.Register("ConctereCustomers", typeof(ObservableCollection<Customers>), typeof(OrdersSearchViewModel), new PropertyMetadata(null));



        public ObservableCollection<String> ConctereCompanyGroup
        {
            get { return (ObservableCollection<String>)GetValue(ConctereCompanyGroupProperty); }
            set { SetValue(ConctereCompanyGroupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConctereCompanyGroup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConctereCompanyGroupProperty =
            DependencyProperty.Register("ConctereCompanyGroup", typeof(ObservableCollection<String>), typeof(OrdersSearchViewModel), new PropertyMetadata(null));



        public ObservableCollection<Orders> Orders
        {
            get { return (ObservableCollection<Orders>)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ObservableCollection<Orders>), typeof(OrdersSearchViewModel), new PropertyMetadata(null));
        


        public ObservableCollection<String> Statuses
        {
            get { return (ObservableCollection<String>)GetValue(StatusesProperty); }
            set { SetValue(StatusesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Statuses.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusesProperty =
            DependencyProperty.Register("Statuses", typeof(ObservableCollection<String>), typeof(OrdersSearchViewModel), new PropertyMetadata(null));

        
        #endregion

        #endregion

        #region Commands & Handlers

        #region CheckBox commands & handlers

        private ICommand checkBoxChecked;

        public ICommand CheckBoxChecked
        {
            get
            {
                if (checkBoxChecked == null)
                    checkBoxChecked = new MyCommands(checkBoxCheckedHandler);
                return checkBoxChecked;
            }
        }

        private async void checkBoxCheckedHandler(object obj = null)
        {
            bool IsChecked = (obj == null) ? false : (bool)obj;

            IsWaitingRingActive = true;
            WaitingRingVisibility = Visibility.Visible;

            if (!IsChecked)
            {

                ConctereCustomers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                ConctereCompanyGroup = new ObservableCollection<String>(await OrdersModel.getCompaniesByUserId());
            }
            else if (IsChecked)
            {
                ConctereCustomers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomers());
                ConctereCompanyGroup = new ObservableCollection<String>(await OrdersModel.getAllСompanies());
            }

            Statuses = new ObservableCollection<String>(await OrdersModel.getStatuses());

            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;

        }
        private void checkBoxCheckedHandlerObject()
        {
            checkBoxCheckedHandler(null);
        }

        #endregion

        #region Enter button commands & handlers

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
                    if (IsConcreteClientChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllOrdersByCustomerId(SelectedConcreteCustomer.Id));
                    }
                    else if (IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllOrdersByCompanyName(SelectedConcreteCompany));
                    }
                    else if (!IsConcreteClientChecked && !IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllOrders());
                    }
                }
                else if (!IsCheckBoxChecked)
                {
                    if (IsConcreteClientChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getOrdersByCustomerIdAndUserId(SelectedConcreteCustomer.Id));
                    }
                    else if (IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getOrdersByCompanyNameAndUserId(SelectedConcreteCompany));
                    }
                    else if (!IsConcreteClientChecked && !IsConcreteCompanyChecked)
                    {
                        Orders = new ObservableCollection<Orders>(await OrdersModel.getAllOrdersByUserId());
                    }
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
            Status = null;
        }

        #endregion

        #region DataGrid command & handlers

        private ICommand hideDataGridRowDetails;

        public ICommand HideDataGridRowDetails
        {
            get
            {
                if (hideDataGridRowDetails == null)
                    hideDataGridRowDetails = new MyCommands(RowDetailsClickHanldler);
                return hideDataGridRowDetails;
            }
        }

        private void RowDetailsClickHanldler(object sender)
        {
            Border row = sender as Border;
            if (row != null)
            {
                row.Visibility =  row.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        #endregion

        #endregion

        #region Validating


        public bool IsValid
        {
            get
            {
                foreach (string propery in ValidatesProperties)
                    if (GetValidationError(propery) != null)
                        return false;

                return true;
            }
        }
        public string Error => null;

        static readonly string[] ValidatesProperties = {

        };

        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        private string GetValidationError(string propertyName)
        {
            switch (propertyName)
            {

                default: return null;
            }
        }

        #endregion
    }
}
