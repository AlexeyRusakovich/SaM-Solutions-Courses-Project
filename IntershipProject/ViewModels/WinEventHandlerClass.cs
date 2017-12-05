using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IntershipProject.Views;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace IntershipProject.ViewModels
{
    public class WinEventHandlerClass : DependencyObject
    {

        public WinEventHandlerClass()
        {
            MainContent = appAuthorization;
            AppAuthorizationViewManager.SuccessAuthorization += SuccessAuthorizationEventHandler;
        }

        #region DependencyProperties


        public Visibility MenuVisibility
        {
            get { return (Visibility)GetValue(MenuVisibilityProperty); }
            set { SetValue(MenuVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuVisibilityProperty =
            DependencyProperty.Register("MenuVisibility", typeof(Visibility), typeof(WinEventHandlerClass), new PropertyMetadata(Visibility.Collapsed));
        


        public int MainWindowWidth
        {
            get { return (int)GetValue(MainWindowWidthProperty); }
            set { SetValue(MainWindowWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainWindowWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainWindowWidthProperty =
            DependencyProperty.Register("MainWindowWidth", typeof(int), typeof(WinEventHandlerClass), new PropertyMetadata(400));



        public int MainWindowHeight
        {
            get { return (int)GetValue(MainWindowHeightProperty); }
            set { SetValue(MainWindowHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainWindowWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainWindowHeightProperty =
            DependencyProperty.Register("MainWindowHeight", typeof(int), typeof(WinEventHandlerClass), new PropertyMetadata(400));



        public System.Windows.Controls.Page MainContent
        {
            get { return (System.Windows.Controls.Page)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(System.Windows.Controls.Page), typeof(WinEventHandlerClass));



        #endregion DependencyProperties & Properties

        #region Simple Properties

        private enum Pages { CUSTOMERS, ADD_ORDERS, SEARCH_ORDERS, ORDERS_HISTORY, ORDER_QUEUE };

        private CustomerSearch customerSearch = new CustomerSearch();
        private Customers customers = new Customers();
        private OrderRegistration orderRegistration = new OrderRegistration();
        private OrdersSearch ordersSearch = new OrdersSearch();
        private AppAuthorization appAuthorization = new AppAuthorization();
        private OrdersQueue ordersQueue = new OrdersQueue();

        #endregion

        #region Commands & Handlers

        #region Handlers of menu buttons clicks

        public void SuccessAuthorizationEventHandler()
        {
            MainContent = customerSearch;
            MenuVisibility = Visibility.Visible;
        }


        private ICommand setCustomerContent;
        public ICommand SetCustomerContent
        {
            get
            {
                if (setCustomerContent == null)
                    setCustomerContent = new MyCommands(setCustomerContentFunc);
                return setCustomerContent;
            }
        }
        private void setCustomerContentFunc(object obj)
        {
            changeWindowContentFunc(Pages.CUSTOMERS);
        }



        private ICommand setAddOrderContent;
        public ICommand SetAddOrderContent
        {
            get
            {
                if (setAddOrderContent == null)
                    setAddOrderContent = new MyCommands(setAddOrderContentFunc);
                return setAddOrderContent;
            }
        }
        private void setAddOrderContentFunc(object obj)
        {
            changeWindowContentFunc(Pages.ADD_ORDERS);
        }


        private ICommand setSearchOrderContent;
        public ICommand SetSearchOrderContent
        {
            get
            {
                if (setSearchOrderContent == null)
                    setSearchOrderContent = new MyCommands(setSearchOrderContentFunc);
                return setSearchOrderContent;
            }
        }
        private void setSearchOrderContentFunc(object obj)
        {
            changeWindowContentFunc(Pages.SEARCH_ORDERS);
        }



        private ICommand setOrderQueueContent;
        public ICommand SetOrderQueueContent
        {
            get
            {
                if (setOrderQueueContent == null)
                    setOrderQueueContent = new MyCommands(setOrderQueueContentFunc);
                return setOrderQueueContent;
            }
        }
        private void setOrderQueueContentFunc(object obj)
        {
            changeWindowContentFunc(Pages.ORDER_QUEUE);
        }



        private ICommand setOrderHistoryContent;
        public ICommand SetOrderHistoryContent
        {
            get
            {
                if (setOrderHistoryContent == null)
                    setOrderHistoryContent = new MyCommands(setOrderHistoryContentFunc);
                return setOrderHistoryContent;
            }
        }
        private void setOrderHistoryContentFunc(object obj)
        {
            changeWindowContentFunc(Pages.ORDERS_HISTORY);
        }



        private void changeWindowContentFunc(Pages pageName)
        {
            switch (pageName)
            {
                case Pages.CUSTOMERS:
                    MainContent = customerSearch;
                    break;

                //case "Orders history":
                //    MainContent = ;
                //    break;

                case Pages.ADD_ORDERS:
                    MainContent = orderRegistration;
                    break;

                case Pages.SEARCH_ORDERS:
                    MainContent = ordersSearch;
                    break;

                case Pages.ORDER_QUEUE:
                    MainContent = ordersQueue;
                    break;

            }
        }

        #endregion Handlers of menu buttons clicks

        #region Windows Handlers

        private ICommand changeWindowState;
        public ICommand ChangeWindowState
        {
            get
            {
                if (changeWindowState == null)
                    changeWindowState = new MyCommands(ChangingWindowState);
                return changeWindowState;

            }
        }
        private void ChangingWindowState(object parameter)
        {
            if (App.Current.MainWindow.WindowState == WindowState.Maximized)
                App.Current.MainWindow.WindowState = WindowState.Normal;
            else
                App.Current.MainWindow.WindowState = WindowState.Maximized;
        }


        private ICommand hideWindow;
        public ICommand HideWindow
        {
            get
            {
                if (hideWindow == null)
                    hideWindow = new MyCommands(HidingWindow);
                return hideWindow;

            }
        }
        private void HidingWindow(object obj)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }


        private ICommand dragMoveWindow;
        public ICommand DragMoveWindow
        {
            get
            {
                if (dragMoveWindow == null)
                    dragMoveWindow = new MyCommands(MovingWindow);
                return dragMoveWindow;
            }
        }
        private void MovingWindow(object obj)
        {
            App.Current.MainWindow.DragMove();
        }


        private ICommand closeWindow;       
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null)
                    closeWindow = new MyCommands(ClosingWindow);
                return closeWindow;
            }
        }
        private void ClosingWindow(object parameter)
        {
            App.Current.Shutdown();
        }

        #endregion Windows Handlers

        #endregion Commands & Handlers
    }
}
