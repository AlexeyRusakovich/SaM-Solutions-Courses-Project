using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntershipProject.ViewModels
{
    class OrdersRegistrationViewModel : DependencyObject
    {
        #region Dependency properties

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
        


        public string OrderDate
        {
            get { return (string)GetValue(OrderDateProperty); }
            set { SetValue(OrderDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderDateProperty =
            DependencyProperty.Register("OrderDate", typeof(string), typeof(OrdersRegistrationViewModel), new PropertyMetadata(null));
        


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




    }
}
