using IntershipProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IntershipProject.ViewModels
{
    public class OrdersQueueViewModel : DependencyObject
    {
        #region Contructor

        public OrdersQueueViewModel()
        {
            OrdersModel.DatabaseChanged += loadOrdersHandlerObj;
        }

        #endregion

        #region Commands & handlers

        #region PageLoaded commands & handlers

        private ICommand loadOrders;
        public ICommand LoadOrders
        {
            get
            {
                if (loadOrders == null)
                    loadOrders = new MyCommands(loadOrdersHandler);
                return loadOrders;
            }
        }
        private async void loadOrdersHandlerObj()
        {
            loadOrdersHandler(null);
        }
        private async void loadOrdersHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;

                if (await DatabaseConnectionChecker.IsConnected())
                {
                    ActiveOrders = new ObservableCollection<Orders>(await OrdersModel.getActiveOrdersByUserId());
                    ActiveOrders = new ObservableCollection<Orders>(ActiveOrders.OrderBy(o => o.OrderDetails.Priority));
                    SuspendedOrders = new ObservableCollection<Orders>(await OrdersModel.getSuspendedOrdersByUserId());
                    SuspendedOrders = new ObservableCollection<Orders>(SuspendedOrders.OrderBy(o => o.OrderDetails.Priority));
                    EndedOrders = new ObservableCollection<Orders>(await OrdersModel.getEndedOrdersByUserId());
                    EndedOrders = new ObservableCollection<Orders>(EndedOrders.OrderBy(o => o.OrderDetails.Priority));
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }

        #endregion

        #region Active orders commands

        private ICommand fromActiveToEndedOrder;
        public ICommand FromActiveToEndedOrder
        {
            get
            {
                if (fromActiveToEndedOrder == null)
                    fromActiveToEndedOrder = new MyCommands(fromActiveToEndedOrderClickHandler);
                return fromActiveToEndedOrder;
            }
        }
        private async void fromActiveToEndedOrderClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.fromActiveToEndedOrder(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }


        private ICommand fromActiveToSuspendedOrder;
        public ICommand FromActiveToSuspendedOrder
        {
            get
            {
                if (fromActiveToSuspendedOrder == null)
                    fromActiveToSuspendedOrder = new MyCommands(fromActiveToSuspendedOrderClickHandler);
                return fromActiveToSuspendedOrder;
            }
        }
        private async void fromActiveToSuspendedOrderClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.fromActiveToSuspendedOrder(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }


        private ICommand fromActiveToCanceledOrder;
        public ICommand FromActiveToCanceledOrder
        {
            get
            {
                if (fromActiveToCanceledOrder == null)
                    fromActiveToCanceledOrder = new MyCommands(fromActiveToCanceledOrderClickHandler);
                return fromActiveToCanceledOrder;
            }
        }
        private async void fromActiveToCanceledOrderClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.fromActiveToCanceledOrder(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }


        private ICommand fromSuspendedToActiveOrder;
        public ICommand FromSuspendedToActiveOrder
        {
            get
            {
                if (fromSuspendedToActiveOrder == null)
                    fromSuspendedToActiveOrder = new MyCommands(fromSuspendedToActiveOrderClickHandler);
                return fromSuspendedToActiveOrder;
            }
        }
        private async void fromSuspendedToActiveOrderClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.fromSuspendedToActiveOrder(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }


        private ICommand fromSuspendedToCanceledOrder;
        public ICommand FromSuspendedToCanceledOrder
        {
            get
            {
                if (fromSuspendedToCanceledOrder == null)
                    fromSuspendedToCanceledOrder = new MyCommands(fromSuspendedToCanceledOrderClickHandler);
                return fromSuspendedToCanceledOrder;
            }
        }
        private async void fromSuspendedToCanceledOrderClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.fromSuspendedToCanceledOrder(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }



        private ICommand increasePriority;
        public ICommand IncreasePriority
        {
            get
            {
                if (increasePriority == null)
                    increasePriority = new MyCommands(increasePriorityClickHandler);
                return increasePriority;
            }
        }
        private async void increasePriorityClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if(await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if(Order != null)
                    {
                        await OrdersModel.increasePriority(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }



        private ICommand decreasePriority;
        public ICommand DecreasePriority
        {
            get
            {
                if (decreasePriority == null)
                    decreasePriority = new MyCommands(decreasePriorityClickHandler);
                return decreasePriority;
            }
        }
        private async void decreasePriorityClickHandler(object obj)
        {
            try
            {
                ErrorStringVisibility = Visibility.Collapsed;
                if (await DatabaseConnectionChecker.IsConnected())
                {
                    Orders Order = obj as Orders;
                    if (Order != null)
                    {
                        await OrdersModel.decreasePriority(Order.Id);
                    }
                }
            }
            catch
            {
                ErrorStringContent = "Ошибка. Нет соединения с БД.";
                ErrorStringVisibility = Visibility.Visible;
            }
        }

        #endregion


        #endregion

        #region Properties


        #region Error string properties

        public Visibility ErrorStringVisibility
        {
            get { return (Visibility)GetValue(ErrorStringVisibilityProperty); }
            set { SetValue(ErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringVisibilityProperty =
            DependencyProperty.Register("ErrorStringVisibility", typeof(Visibility), typeof(OrdersQueueViewModel), new PropertyMetadata(Visibility.Collapsed));




        public String ErrorStringContent
        {
            get { return (String)GetValue(ErrorStringContentProperty); }
            set { SetValue(ErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorStringContentProperty =
            DependencyProperty.Register("ErrorStringContent", typeof(String), typeof(OrdersQueueViewModel), new PropertyMetadata(null));


        #endregion

        #region ListView collections properties

        public ObservableCollection<Orders> ActiveOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(ActiveOrdersProperty); }
            set { SetValue(ActiveOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActiveOrders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActiveOrdersProperty =
            DependencyProperty.Register("ActiveOrders", typeof(ObservableCollection<Orders>), typeof(OrdersQueueViewModel), new PropertyMetadata(null));



        public ObservableCollection<Orders> SuspendedOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(SuspendedOrdersProperty); }
            set { SetValue(SuspendedOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SuspendedOrders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SuspendedOrdersProperty =
            DependencyProperty.Register("SuspendedOrders", typeof(ObservableCollection<Orders>), typeof(OrdersQueueViewModel), new PropertyMetadata(null));



        public ObservableCollection<Orders> EndedOrders
        {
            get { return (ObservableCollection<Orders>)GetValue(EndedOrdersProperty); }
            set { SetValue(EndedOrdersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndedOrders.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndedOrdersProperty =
            DependencyProperty.Register("EndedOrders", typeof(ObservableCollection<Orders>), typeof(OrdersQueueViewModel), new PropertyMetadata(null));



        #endregion



        #endregion

    }
}
