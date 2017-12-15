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
    class OrdersRegistrationViewModel : DependencyObject
    {

        #region Constuctor

        public OrdersRegistrationViewModel()
        {
            AppAuthorizationViewModel.SuccessAuthorization += OnAuthorization;
        }

        #endregion

        #region Dependency properties

        #region Order registration properties

        public string CustomerCompanyName
        {
            get { return (string)GetValue(CustomerCompanyNameProperty); }
            set { SetValue(CustomerCompanyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomerCompanyName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerCompanyNameProperty =
            DependencyProperty.Register("CustomerCompanyName", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string CustomerFistName
        {
            get { return (string)GetValue(CustomerFistNameProperty); }
            set { SetValue(CustomerFistNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomerFistName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerFistNameProperty =
            DependencyProperty.Register("CustomerFistName", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string CustomerLastName
        {
            get { return (string)GetValue(CustomerLastNameProperty); }
            set { SetValue(CustomerLastNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomerLastName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerLastNameProperty =
            DependencyProperty.Register("CustomerLastName", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string CompanyAdress
        {
            get { return (string)GetValue(CompanyAdressProperty); }
            set { SetValue(CompanyAdressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompanyAdress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanyAdressProperty =
            DependencyProperty.Register("CompanyAdress", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PhoneNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string OrderDescription
        {
            get { return (string)GetValue(OrderDescriptionProperty); }
            set { SetValue(OrderDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderDescriptionProperty =
            DependencyProperty.Register("OrderDescription", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public int ServieceCost
        {
            get { return (int)GetValue(ServieceCostProperty); }
            set { SetValue(ServieceCostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServieceCostProperty =
            DependencyProperty.Register("ServieceCost", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));



        public int ServieceCount
        {
            get { return (int)GetValue(ServieceCountProperty); }
            set { SetValue(ServieceCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServieceCountProperty =
            DependencyProperty.Register("ServieceCount", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));



        public int Discount
        {
            get { return (int)GetValue(DiscountProperty); }
            set { SetValue(DiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Discount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));

        #endregion

        #region Order change properties
        

        public Orders SelectedChangeDataGridItem
        {
            get { return (Orders)GetValue(SelectedChangeDataGridItemProperty); }
            set { SetValue(SelectedChangeDataGridItemProperty, value); }
        }


        // Using a DependencyProperty as the backing store for SelectedChangeDataGridItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedChangeDataGridItemProperty =
            DependencyProperty.Register("SelectedChangeDataGridItem", typeof(Orders), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public ObservableCollection<Orders> ChangeOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(ChangeOrdersProperty); }
            set { SetValue(ChangeOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChangeOrders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeOrdersProperty =
            DependencyProperty.Register("ChangeOrders", typeof(ObservableCollection<Orders>), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public ObservableCollection<Customers> ChangeCustomers
        {
            get { return (ObservableCollection<Customers>)GetValue(ChangeCustomersProperty); }
            set { SetValue(ChangeCustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChangeCustomers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeCustomersProperty =
            DependencyProperty.Register("ChangeCustomers", typeof(ObservableCollection<Customers>), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));
               


        public Customers NewCustomer
        {
            get { return (Customers)GetValue(NewCustomerProperty); }
            set { SetValue(NewCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewCustomerProperty =
            DependencyProperty.Register("NewCustomer", typeof(Customers), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));




        public string NewCompanyAdress
        {
            get { return (string)GetValue(NewCompanyAdressProperty); }
            set { SetValue(NewCompanyAdressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompanyAdress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewCompanyAdressProperty =
            DependencyProperty.Register("NewCompanyAdress", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string NewPhoneNumber
        {
            get { return (string)GetValue(NewPhoneNumberProperty); }
            set { SetValue(NewPhoneNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PhoneNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewPhoneNumberProperty =
            DependencyProperty.Register("NewPhoneNumber", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string NewOrderDescription
        {
            get { return (string)GetValue(NewOrderDescriptionProperty); }
            set { SetValue(NewOrderDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewOrderDescriptionProperty =
            DependencyProperty.Register("NewOrderDescription", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public int NewServieceCost
        {
            get { return (int)GetValue(NewServieceCostProperty); }
            set { SetValue(NewServieceCostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewServieceCostProperty =
            DependencyProperty.Register("NewServieceCost", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));



        public int NewServieceCount
        {
            get { return (int)GetValue(NewServieceCountProperty); }
            set { SetValue(NewServieceCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewServieceCountProperty =
            DependencyProperty.Register("NewServieceCount", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));



        public int NewDiscount
        {
            get { return (int)GetValue(NewDiscountProperty); }
            set { SetValue(NewDiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Discount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewDiscountProperty =
            DependencyProperty.Register("NewDiscount", typeof(int), typeof(OrdersRegistrationViewModel), new PropertyMetadata(0));

        #endregion

        #region Enter buttons commands & handlers



        public string EditButtonContent
        {
            get { return (string)GetValue(EditButtonContentProperty); }
            set { SetValue(EditButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditButtonContentProperty =
            DependencyProperty.Register("EditButtonContent", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata("Редактировать"));



        public Visibility CancelButtonVisibility
        {
            get { return (Visibility)GetValue(CancelButtonVisibilityProperty); }
            set { SetValue(CancelButtonVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelButtomVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelButtonVisibilityProperty =
            DependencyProperty.Register("CancelButtonVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Collapsed));
        


        private ICommand edit;
        public ICommand Edit
        {
            get
            {
                if (edit == null)
                    edit = new MyCommands(editClickHandler);
                return edit;
            }
        }
        private void editClickHandler(object obj)
        {
            if(EditButtonContent == "Редактировать")
            {
                CancelButtonVisibility = Visibility.Visible;
                EditButtonContent = "Сохранить";
            }
            else if(EditButtonContent == "Сохранить")
            {
                EditButtonContent = "Редактировать";
                CancelButtonVisibility = Visibility.Collapsed;
                // database query
            }

        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                    cancel = new MyCommands(cancelClickHandler);
                return cancel;
            }
        }
        private void cancelClickHandler(object obj)
        {
            CancelButtonVisibility = Visibility.Collapsed;

            EditButtonContent = "Редактировать";

        }


        #endregion

        #region OrderChange commands & handlers

        private ICommand fillFields;

        public ICommand FillFields
        {
            get
            {
                if (fillFields == null)
                    fillFields = new MyCommands(dataGridItemSelectedHandler);
                return fillFields;
            }
        }

        private void dataGridItemSelectedHandler(object obj)
        {
           if(SelectedChangeDataGridItem != null)
            {
                NewCustomer = SelectedChangeDataGridItem.Customers;
                NewCompanyAdress = SelectedChangeDataGridItem.Customers.ContactAdress;
                NewDiscount = SelectedChangeDataGridItem.OrderDetails.Discount;
                NewOrderDescription = SelectedChangeDataGridItem.OrderDetails.OrderDescription;
                NewServieceCost = SelectedChangeDataGridItem.OrderDetails.UnitPrice;
                NewServieceCount = SelectedChangeDataGridItem.OrderDetails.Quantity;
                NewPhoneNumber = SelectedChangeDataGridItem.Customers.ContactPhone;
            }
        }

        private async void OnAuthorization()
        {
            ChangeCustomers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
            ChangeOrders = new ObservableCollection<Orders>(await OrdersModel.getOrdersByUserId());
        }

        #endregion

        #endregion

    }
}
