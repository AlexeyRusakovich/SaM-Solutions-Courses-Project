using IntershipProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IntershipProject.ViewModels
{
    class OrdersRegistrationViewModel : DependencyObject, IDataErrorInfo
    {

        #region Constuctor

        public OrdersRegistrationViewModel()
        {
            AppAuthorizationViewModel.SuccessAuthorization += OnAuthorization;
            OrdersModel.DatabaseChanged += OnAuthorization;
        }

        #endregion

        #region Dependency properties

        #region Error string properties

        public Visibility AddErrorStringVisibility
        {
            get { return (Visibility)GetValue(AddErrorStringVisibilityProperty); }
            set { SetValue(AddErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddErrorStringVisibilityProperty =
            DependencyProperty.Register("AddErrorStringVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Collapsed));



        public string AddErrorStringContent
        {
            get { return (string)GetValue(AddErrorStringContentProperty); }
            set { SetValue(AddErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddErrorStringContentProperty =
            DependencyProperty.Register("AddErrorStringContent", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));


        public Visibility ChangeErrorStringVisibility
        {
            get { return (Visibility)GetValue(ChangeErrorStringVisibilityProperty); }
            set { SetValue(ChangeErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeErrorStringVisibilityProperty =
            DependencyProperty.Register("ChangeErrorStringVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Collapsed));



        public string ChangeErrorStringContent
        {
            get { return (string)GetValue(ChangeErrorStringContentProperty); }
            set { SetValue(ChangeErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChangeErrorStringContentProperty =
            DependencyProperty.Register("ChangeErrorStringContent", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));


        #endregion

        #region Waiting Rind Properties

        public bool IsWaitingRingActive
        {
            get { return (bool)GetValue(IsWaitingRingActiveProperty); }
            set { SetValue(IsWaitingRingActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaitingRingActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWaitingRingActiveProperty =
            DependencyProperty.Register("IsWaitingRingActive", typeof(bool), typeof(OrdersRegistrationViewModel), new PropertyMetadata(false));



        public Visibility WaitingRingVisibility
        {
            get { return (Visibility)GetValue(WaitingRingVisibilityProperty); }
            set { SetValue(WaitingRingVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaitingRingVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaitingRingVisibilityProperty =
            DependencyProperty.Register("WaitingRingVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Collapsed));


        #endregion

        #region Customer registration grid visibility properties

        public Visibility SelectExistingCustomerGridVisibility
        {
            get { return (Visibility)GetValue(SelectExistingCustomerGridVisibilityProperty); }
            set { SetValue(SelectExistingCustomerGridVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectCurrentCustomerGridVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectExistingCustomerGridVisibilityProperty =
            DependencyProperty.Register("SelectExistingCustomerGridVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Visible));
        


        public Visibility SelectNewCustomerGridVisibility
        {
            get { return (Visibility)GetValue(SelectNewCustomerGridVisibilityProperty); }
            set { SetValue(SelectNewCustomerGridVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectNewCustomerGridVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectNewCustomerGridVisibilityProperty =
            DependencyProperty.Register("SelectNewCustomerGridVisibility", typeof(Visibility), typeof(OrdersRegistrationViewModel), new PropertyMetadata(Visibility.Collapsed));


        #endregion

        #region Order registration properties

        public Customers SelectedCustomer
        {
            get { return (Customers)GetValue(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedCustomer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedCustomerProperty =
            DependencyProperty.Register("SelectedCustomer", typeof(Customers), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



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



        public String ServieceCost
        {
            get { return (String)GetValue(ServieceCostProperty); }
            set { SetValue(ServieceCostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServieceCostProperty =
            DependencyProperty.Register("ServieceCost", typeof(String), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public String ServieceCount
        {
            get { return (String)GetValue(ServieceCountProperty); }
            set { SetValue(ServieceCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServieceCountProperty =
            DependencyProperty.Register("ServieceCount", typeof(String), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public String Discount
        {
            get { return (String)GetValue(DiscountProperty); }
            set { SetValue(DiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Discount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiscountProperty =
            DependencyProperty.Register("Discount", typeof(String), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));

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



        public ObservableCollection<Customers> Customers
        {
            get { return (ObservableCollection<Customers>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomersProperty =
            DependencyProperty.Register("Customers", typeof(ObservableCollection<Customers>), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));
               


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



        public string NewServieceCost
        {
            get { return (string)GetValue(NewServieceCostProperty); }
            set { SetValue(NewServieceCostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewServieceCostProperty =
            DependencyProperty.Register("NewServieceCost", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string NewServieceCount
        {
            get { return (string)GetValue(NewServieceCountProperty); }
            set { SetValue(NewServieceCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServieceCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewServieceCountProperty =
            DependencyProperty.Register("NewServieceCount", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));



        public string NewDiscount
        {
            get { return (string)GetValue(NewDiscountProperty); }
            set { SetValue(NewDiscountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Discount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewDiscountProperty =
            DependencyProperty.Register("NewDiscount", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));

        #endregion

        #endregion

        #region Commands & handlers

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
        private async void editClickHandler(object obj)
        {
            try
            {
                ChangeErrorStringContent = null;
                ChangeErrorStringVisibility = Visibility.Collapsed;
                IsWaitingRingActive = true;
                WaitingRingVisibility = Visibility.Visible;

                if (await DatabaseConnectionChecker.IsConnected())
                {
                    int Cost = 0;
                    int.TryParse(NewServieceCost, out Cost);
                    int Count = 0;
                    int.TryParse(NewServieceCount, out Count);
                    int discount = 0;
                    int.TryParse(NewDiscount, out discount);


                    if (EditButtonContent == "Редактировать")
                    {
                        if (IsChangeOrderValid())
                        {


                            if (await OrdersModel.IsOrderAndCustomerExist(

                                    SelectedChangeDataGridItem.Id,
                                    SelectedChangeDataGridItem.CustomerId,
                                    SelectedChangeDataGridItem.OrderDetailsId,
                                    NewCompanyAdress,
                                    NewPhoneNumber,
                                    NewOrderDescription,
                                    Cost,
                                    Count,
                                    discount
                                ))
                            {
                                CancelButtonVisibility = Visibility.Visible;
                                EditButtonContent = "Сохранить";
                            }
                            else
                            {
                                ChangeErrorStringContent = "Изменяемого заказа не существует.";
                                ChangeErrorStringVisibility = Visibility.Visible;
                            }
                        }
                    }
                    else if (EditButtonContent == "Сохранить")
                    {
                        if (IsChangeOrderValid())
                        {
                            if (await OrdersModel.UpdateOrder(
                                     SelectedChangeDataGridItem.OrderDetailsId,
                                     SelectedChangeDataGridItem.CustomerId,
                                     NewCompanyAdress,
                                     NewPhoneNumber,
                                     NewOrderDescription,
                                     Cost,
                                     Count,
                                     discount
                                 ))
                            {
                                EditButtonContent = "Редактировать";
                                CancelButtonVisibility = Visibility.Collapsed;
                            }
                            else
                            {
                                ChangeErrorStringContent = "Произошла ошибка изменения заказа.";
                                ChangeErrorStringVisibility = Visibility.Visible;
                            }

                        }
                    }
                }
            }
            catch
            {
                ChangeErrorStringContent = "Ошибка. Нет соединения с БД.";
                ChangeErrorStringVisibility = Visibility.Visible;
            }

            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;

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


        private ICommand selectExistingCustomer;
        public ICommand SelectExistingCustomer
        {
            get
            {
                if (selectExistingCustomer == null)
                    selectExistingCustomer = new MyCommands(selectExistingCustomerClickHandler);
                return selectExistingCustomer;

            }
        }
        private void selectExistingCustomerClickHandler(object obj)
        {
            SelectExistingCustomerGridVisibility = Visibility.Visible;
            SelectNewCustomerGridVisibility = Visibility.Collapsed;
        }


        private ICommand selectNewCustomer;
        public ICommand SelectNewCustomer
        {
            get
            {
                if (selectNewCustomer == null)
                    selectNewCustomer = new MyCommands(selectNewCustomerClickHandler);
                return selectNewCustomer;

            }
        }
        private void selectNewCustomerClickHandler(object obj)
        {
            SelectExistingCustomerGridVisibility = Visibility.Collapsed;
            SelectNewCustomerGridVisibility = Visibility.Visible;
        }


        private ICommand registerOrder;
        public ICommand RegisterOrder
        {
            get
            {
                if (registerOrder == null)
                    registerOrder = new MyCommands(registerOrderClickHandler);
                return registerOrder;

            }
        }
        private async void registerOrderClickHandler(object obj)
        {
            try
            {
                IsWaitingRingActive = true;
                WaitingRingVisibility = Visibility.Visible;
                AddErrorStringVisibility = Visibility.Collapsed;

                if (await DatabaseConnectionChecker.IsConnected())
                {
                    if (SelectExistingCustomerGridVisibility == Visibility.Visible)
                    {
                        if (IsOrderValid)
                        {
                            int Cost = 0;
                            int.TryParse(ServieceCost, out Cost);
                            int Count = 0;
                            int.TryParse(ServieceCount, out Count);
                            int discount = 0;
                            int.TryParse(Discount, out discount);

                            if (await OrdersModel.AddOrder(

                                    SelectedCustomer.Id,
                                    OrderDescription,
                                    Cost,
                                    Count,
                                    discount

                                ))
                                MessageBox.Show("Заказ успешно добавлен!");
                            else
                                MessageBox.Show("Произошла ошибка добавления заказа.");
                        }
                    }
                    else if (SelectNewCustomerGridVisibility == Visibility.Visible)
                    {
                        if (IsNewOrderValid)
                        {

                            int Cost = 0;
                            int.TryParse(ServieceCost, out Cost);
                            int Count = 0;
                            int.TryParse(ServieceCount, out Count);
                            int discount = 0;
                            int.TryParse(Discount, out discount);

                            if (await OrdersModel.AddOrderWithNewCustomer(

                                    CustomerCompanyName,
                                    CustomerFistName,
                                    CustomerLastName,
                                    CompanyAdress,
                                    PhoneNumber,
                                    OrderDescription,
                                    Cost,
                                    Count,
                                    discount
                                ))
                                MessageBox.Show("Заказ успешно добавлен!");
                            else
                                MessageBox.Show("Произошла ошибка добавления заказа.");
                        }
                    }
                }
            }
            catch
            {
                AddErrorStringContent = "Ошибка. Нет соединения с БД.";
                AddErrorStringVisibility = Visibility.Visible;
            }

            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;

        }



        private ICommand changeOrder;
        public ICommand ChangeOrder
        {
            get
            {
                if (changeOrder == null)
                    changeOrder = new MyCommands(changeOrderClickHandler);
                return changeOrder;
            }
        }
        private async void changeOrderClickHandler(object obj)
        {
            try
            {
                IsWaitingRingActive = true;
                WaitingRingVisibility = Visibility.Visible;
                ChangeErrorStringVisibility = Visibility.Collapsed;

                if (await DatabaseConnectionChecker.IsConnected())
                {

                    if (IsChangeOrderValid())
                    {
                        int Cost = 0;
                        int.TryParse(NewServieceCost, out Cost);
                        int Count = 0;
                        int.TryParse(NewServieceCount, out Count);
                        int discount = 0;
                        int.TryParse(NewDiscount, out discount);

                        if (await OrdersModel.UpdateOrder(

                                SelectedChangeDataGridItem.Id,
                                SelectedChangeDataGridItem.CustomerId,
                                NewCompanyAdress,
                                NewPhoneNumber,
                                NewOrderDescription,
                                Cost,
                                Count,
                                discount

                            ))
                            MessageBox.Show("Заказ успешно изменен!");
                        else
                            MessageBox.Show("Произошла ошибка при изменении заказа.");
                    }
                }
            }
            catch
            {
                ChangeErrorStringContent = "Ошибка. Нет соединения с БД.";
                ChangeErrorStringVisibility = Visibility.Visible;
            }

            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;
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
            if (SelectedChangeDataGridItem != null)
            {
                NewCustomer = SelectedChangeDataGridItem.Customers;
                NewCompanyAdress = SelectedChangeDataGridItem.Customers.ContactAdress.Replace('\n', ' ');
                NewDiscount = SelectedChangeDataGridItem.OrderDetails.Discount.ToString();
                NewOrderDescription = SelectedChangeDataGridItem.OrderDetails.OrderDescription;
                NewServieceCost = SelectedChangeDataGridItem.OrderDetails.UnitPrice.ToString();
                NewServieceCount = SelectedChangeDataGridItem.OrderDetails.Quantity.ToString();
                NewPhoneNumber = SelectedChangeDataGridItem.Customers.ContactPhone;
            }
        }

        private async void OnAuthorization()
        {
            AddErrorStringVisibility = Visibility.Collapsed;
            ChangeErrorStringVisibility = Visibility.Collapsed;
            IsWaitingRingActive = true;
            WaitingRingVisibility = Visibility.Visible;

            try
            {
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Customers = new ObservableCollection<Customers>(await CustomersModel.getCustomersByUserId());
                    ChangeOrders = new ObservableCollection<Orders>(await OrdersModel.getChangeableOrdersByUserId());
                }
            }
            catch
            {
                AddErrorStringContent = "Ошибка. Нет соединения с БД.";
                AddErrorStringVisibility = Visibility.Visible;
                ChangeErrorStringContent = "Ошибка. Нет соединения с БД.";
                ChangeErrorStringVisibility = Visibility.Visible;
            }

            IsWaitingRingActive = false;
            WaitingRingVisibility = Visibility.Collapsed;

        }

        #endregion

        #endregion

        #region Validating

        public bool IsNewOrderValid
        {
            get
            {
                foreach (string propery in ValidatesNewOrderProperties)
                    if (GetValidationError(propery) != null)
                        return false;

                return true;
            }
        }

        public bool IsOrderValid
        {
            get
            {

                foreach (string propery in ValidatesOrderProperties)
                    if (GetValidationError(propery) != null)
                        return false;

                return true;

            }
            
        }

        public bool IsChangeOrderValid()
        {
                foreach (string propery in ValidatesChangeOrderProperties)
                    if (GetValidationError(propery) != null)
                        return false;

                return true;
        }

        public string Error
        {
            get { return null; }
            
        }

        static readonly string[] ValidatesNewOrderProperties = {

            "CustomerCompanyName",
            "CustomerFistName",
            "CustomerLastName",
            "CompanyAdress",
            "PhoneNumber",
            "OrderDescription",
            "ServieceCost",
            "ServieceCount",
            "Discount"
        };

        static readonly string[] ValidatesOrderProperties = {

            "SelectedCustomer",
            "OrderDescription",
            "ServieceCost",
            "ServieceCount",
            "Discount"
        };

        static readonly string[] ValidatesChangeOrderProperties = {

            "SelectedChangeDataGridItem",
            "NewCompanyAdress",
            "NewPhoneNumber",
            "NewOrderDescription",
            "NewServieceCost",
            "NewServieceCount",
            "NewDiscount"
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
                case "SelectedCustomer":
                    if (SelectedCustomer == null)
                        return "Поле не должно быть пустым.";
                    return null;

                case "SelectedChangeDataGridItem":
                    if (SelectedChangeDataGridItem == null)
                        return "Поле не должно быть пустым.";
                    return null;


                case "NewOrderDescription":
                    if (string.IsNullOrWhiteSpace(NewOrderDescription))
                        return "Описание не должно быть пустым.";
                    return null;

                case "NewServieceCost":
                    return Validating.ValidateValue(NewServieceCost, 1, 100000);

                case "CustomerCompanyName":
                    return Validating.ValidateStandartString(CustomerCompanyName);

                case "NewServieceCount":
                    return Validating.ValidateValue(NewServieceCount, 1, 10000);

                case "NewDiscount":
                    return Validating.ValidateValue(NewDiscount, 0, 100);

                case "CustomerFistName":
                    return Validating.ValidateStandartString(CustomerFistName);

                case "CustomerLastName":
                    return Validating.ValidateStandartString(CustomerLastName);

                case "NewCompanyAdress":
                    if (string.IsNullOrWhiteSpace(NewCompanyAdress))
                        return "Адресс не должен быть пустым.";
                    return null;                   

                case "CompanyAdress":
                    if (string.IsNullOrWhiteSpace(CompanyAdress))
                        return "Адресс не должен быть пустым.";
                    return null;
                    
                case "NewPhoneNumber":
                    return Validating.ValidatePhoneNumber(NewPhoneNumber);

                case "PhoneNumber":
                    return Validating.ValidatePhoneNumber(PhoneNumber);

                case "OrderDescription":
                    if (string.IsNullOrWhiteSpace(OrderDescription))
                        return "Описание не должно быть пустым.";
                    return null;

                case "ServieceCost":
                    return Validating.ValidateValue(ServieceCost, 1, 100000);

                case "ServieceCount":
                    return Validating.ValidateValue(ServieceCount, 1, 10000);

                case "Discount":
                    return Validating.ValidateValue(Discount, 0, 100);

                default: return null;
            }
        }

        #endregion

    }
}
