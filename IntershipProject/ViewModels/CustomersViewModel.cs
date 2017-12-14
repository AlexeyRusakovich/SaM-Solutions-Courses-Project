using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IntershipProject.Models;

namespace IntershipProject.ViewModels
{
    class CustomersViewModel : DependencyObject
    {
        #region Constructor
        public CustomersViewModel()
        {
            AppAuthorizationViewModel.SuccessAuthorization += checkBoxCheckedHandlerObj;
        }

        #endregion

        #region Dependency properties

        #region Grids properties


        public Visibility FirstGridVisibility
        {
            get { return (Visibility)GetValue(FirstGridVisibilityProperty); }
            set { SetValue(FirstGridVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstDataGridVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstGridVisibilityProperty =
            DependencyProperty.Register("FirstGridVisibility", typeof(Visibility), typeof(CustomersViewModel), new PropertyMetadata(Visibility.Visible));



        public Visibility SecondGridVisibility
        {
            get { return (Visibility)GetValue(SecondGridVisibilityProperty); }
            set { SetValue(SecondGridVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondGridVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondGridVisibilityProperty =
            DependencyProperty.Register("SecondGridVisibility", typeof(Visibility), typeof(CustomersViewModel), new PropertyMetadata(Visibility.Collapsed));




        #endregion

        #region Error string properties

        public String ErrorStringContent
        {
            get { return (String)GetValue(ErrorStringContentProperty); }
            set { SetValue(ErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringContentProperty =
            DependencyProperty.Register("ErrorStringContent", typeof(String), typeof(CustomersViewModel), new PropertyMetadata(null));




        public Visibility ErrorStringVisibility
        {
            get { return (Visibility)GetValue(ErrorStringVisibilityProperty); }
            set { SetValue(ErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringVisibilityProperty =
            DependencyProperty.Register("ErrorStringVisibility", typeof(Visibility), typeof(CustomersViewModel), new PropertyMetadata(Visibility.Collapsed));




        #endregion

        #region Process ring properties


        public Visibility WaitinRingVisibility
        {
            get { return (Visibility)GetValue(WaitinRingVisibilityProperty); }
            set { SetValue(WaitinRingVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaitinRingVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaitinRingVisibilityProperty =
            DependencyProperty.Register("WaitinRingVisibility", typeof(Visibility), typeof(CustomersViewModel), new PropertyMetadata(Visibility.Collapsed));

        

        public bool IsWaitingRingActive
        {
            get { return (bool)GetValue(IsWaitingRingActiveProperty); }
            set { SetValue(IsWaitingRingActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaitingRingActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWaitingRingActiveProperty =
            DependencyProperty.Register("IsWaitingRingActive", typeof(bool), typeof(CustomersViewModel), new PropertyMetadata(false));



        #endregion

        #region CheckBox & RadioButtons properties

        public bool IsCheckBoxChecked
        {
            get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
            set { SetValue(IsCheckBoxCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(CustomersViewModel), new PropertyMetadata(false));





        public bool IsConsreteClientChecked
        {
            get { return (bool)GetValue(IsConsreteClientCheckedProperty); }
            set { SetValue(IsConsreteClientCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConsreteClientChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConsreteClientCheckedProperty =
            DependencyProperty.Register("IsConsreteClientChecked", typeof(bool), typeof(CustomersViewModel), new PropertyMetadata(false));





        public bool IsConcreteCompanyChecked
        {
            get { return (bool)GetValue(IsConcreteCompanyCheckedProperty); }
            set { SetValue(IsConcreteCompanyCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConcreteCompanyChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConcreteCompanyCheckedProperty =
            DependencyProperty.Register("IsConcreteCompanyChecked", typeof(bool), typeof(CustomersViewModel), new PropertyMetadata(false));






        #endregion

        #region Collections properties

        public ObservableCollection<Customers> ResultCustomers
        {
            get { return (ObservableCollection<Customers>)GetValue(ResultCustomersProperty); }
            set { SetValue(ResultCustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResultCustomers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultCustomersProperty =
            DependencyProperty.Register("ResultCustomers", typeof(ObservableCollection<Customers>), typeof(CustomersViewModel), new PropertyMetadata(null));



        public ObservableCollection<Customers> Customers
        {
            get { return (ObservableCollection<Customers>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomersProperty =
            DependencyProperty.Register("Customers", typeof(ObservableCollection<Customers>), typeof(CustomersViewModel), new PropertyMetadata(null));
        

        public ObservableCollection<String> Companies
        {
            get { return (ObservableCollection<String>)GetValue(CompaniesProperty); }
            set { SetValue(CompaniesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Companies.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompaniesProperty =
            DependencyProperty.Register("Companies", typeof(ObservableCollection<String>), typeof(CustomersViewModel), new PropertyMetadata(null));


        #endregion

        #region Selected items properties

        public Visibility SelectedGridCustomerItemsVisibility
        {
            get { return (Visibility)GetValue(SelectedGridCustomerItemsVisibilityProperty); }
            set { SetValue(SelectedGridCustomerItemsVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedGridCustomerItemsVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedGridCustomerItemsVisibilityProperty =
            DependencyProperty.Register("SelectedGridCustomerItemsVisibility", typeof(Visibility), typeof(CustomersViewModel), new PropertyMetadata(Visibility.Collapsed));
        


        public Customers SelectedGridCustomer
        {
            get { return (Customers)GetValue(SelectedGridCustomerProperty); }
            set { SetValue(SelectedGridCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedGridCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedGridCustomerProperty =
            DependencyProperty.Register("SelectedGridCustomer", typeof(Customers), typeof(CustomersViewModel), new PropertyMetadata(null));



        public ObservableCollection<Orders> SelectedGridCustomersOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(SelectedGridCustomersOrdersProperty); }
            set { SetValue(SelectedGridCustomersOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedGridCustomersOrders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedGridCustomersOrdersProperty =
            DependencyProperty.Register("SelectedGridCustomersOrders", typeof(ObservableCollection<Orders>), typeof(CustomersViewModel), new PropertyMetadata(null));
        


        public Customers SelectedCustomer
        {
            get { return (Customers)GetValue(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCustomerProperty =
            DependencyProperty.Register("SelectedCustomer", typeof(Customers), typeof(CustomersViewModel), new PropertyMetadata(null));

        

        public String SelectedCompany
        {
            get { return (String)GetValue(SelectedCompanyProperty); }
            set { SetValue(SelectedCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCompanyProperty =
            DependencyProperty.Register("SelectedCompany", typeof(String), typeof(CustomersViewModel), new PropertyMetadata(null));
        
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
                    checkBoxChecked = new MyCommands(checkBoxCheckedHandler);
                return checkBoxChecked;
            }
        }
        private async void checkBoxCheckedHandler(object param)
        {
            IsWaitingRingActive = true;
            WaitinRingVisibility = Visibility.Visible;

            if (IsCheckBoxChecked)
            {
                ResultCustomers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomers());
                Companies = new ObservableCollection<String>(await OrdersModel.getAllСompanies());
            }
            else if (!IsCheckBoxChecked)
            {
                ResultCustomers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                Companies = new ObservableCollection<string>(await OrdersModel.getCompaniesByUserId());
            }

            IsWaitingRingActive = false;
            WaitinRingVisibility = Visibility.Collapsed;
        }

        private void checkBoxCheckedHandlerObj()
        {
            checkBoxCheckedHandler(null);
        }

        #endregion

        #region Click search and clean buttons commands & handlers

        private ICommand searchCustomers;
        public ICommand SearchCustomers
        {
            get
            {
                if (searchCustomers == null)
                    searchCustomers = new MyCommands(searchCustomersClickHandler);
                return searchCustomers;
            }

        }
        private async void searchCustomersClickHandler(object param)
        {
            SelectedGridCustomerItemsVisibility = Visibility.Collapsed;
            IsWaitingRingActive = true;
            WaitinRingVisibility = Visibility.Visible;

            if (IsCheckBoxChecked)
            {
                if (IsConsreteClientChecked && SelectedCustomer != null)
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getCustomerById(SelectedCustomer.Id));
                }
                else if (IsConcreteCompanyChecked && SelectedCompany != null)
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomersByCompany(SelectedCompany));
                }
                else
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomers());
                }
            }
            else if (!IsCheckBoxChecked)
            {
                if (IsConsreteClientChecked && SelectedCustomer != null)
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getCustomerByIdAndUserId(SelectedCustomer.Id));
                }
                else if (IsConcreteCompanyChecked && SelectedCompany != null)
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getAllCustomersByCompanyAndUserId(SelectedCompany));
                }
                else
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                }
            }

            if (Customers.Count() != 0)
                foreach (var c in Customers)
                    c.ContactAdress = c.ContactAdress.Replace('\n', ' ');

            IsWaitingRingActive = false;
            WaitinRingVisibility = Visibility.Collapsed;

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
        private void cleanQueryClickHandler(object param)
        {
            IsCheckBoxChecked = false;
            SelectedCompany = null;
            SelectedCustomer = null;
            IsConcreteCompanyChecked = false;
            IsConsreteClientChecked = false;
        }

        #endregion

        #region Click go back button commands & handlers

        private ICommand goBack;

        public ICommand GoBack
        {
            get
            {
                if (goBack == null)
                    goBack = new MyCommands(goBackButtonClickHandler);
                return goBack;
            }
        }

        private void goBackButtonClickHandler(object obj)
        {
            SecondGridVisibility = Visibility.Collapsed;
            FirstGridVisibility = Visibility.Visible;
        }

        #endregion

        #region Get customer's orders commands

        private ICommand changeSelectedCustomerPanelVisibility;
        public ICommand ChangeSelectedCustomerPanelVisibility
        {
            get
            {
                if (changeSelectedCustomerPanelVisibility == null)
                    changeSelectedCustomerPanelVisibility = new MyCommands(selectDataGridCustomerHandler);
                return changeSelectedCustomerPanelVisibility;
            }
        }
        private void selectDataGridCustomerHandler(object obj)
        {
            if(SelectedGridCustomer != null)
            SelectedGridCustomerItemsVisibility = Visibility.Visible;
        }



        private ICommand getOrders;
        public ICommand GetOrders
        {
            get
            {
                if (getOrders == null)
                    getOrders = new MyCommands(getOrdersButtonClickHandler);
                return getOrders;
            }
        }
        private async void getOrdersButtonClickHandler(object obj)
        {
            FirstGridVisibility = Visibility.Collapsed;
            SecondGridVisibility = Visibility.Visible;

            SelectedGridCustomersOrders = new ObservableCollection<Orders>(await OrdersModel.getAllOrdersByCustomerId(SelectedGridCustomer.Id));

            // TODO :   обеpнуть все методы в try catch
            //          доделать 2-ой datagrid в customerView
            //          валидация

        }

        #endregion

        #endregion

    }
}
