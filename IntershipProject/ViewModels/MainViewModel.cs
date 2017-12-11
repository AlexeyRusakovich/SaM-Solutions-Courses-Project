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
using IntershipProject.Models;

namespace IntershipProject.ViewModels
{
    public class MainViewModel : DependencyObject
    {
        #region Constructor

        public MainViewModel()
        {
            MainContent = appAuthorization;
            AppAuthorizationViewModel.SuccessAuthorization += SuccessAuthorizationEventHandler;
            AppLoggingChecker.onAppLogin += OnLogin;
        }

        #endregion

        #region DependencyProperties
        

        public Visibility MenuVisibility
        {
            get { return (Visibility)GetValue(MenuVisibilityProperty); }
            set { SetValue(MenuVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuVisibilityProperty =
            DependencyProperty.Register("MenuVisibility", typeof(Visibility), typeof(MainViewModel), new PropertyMetadata(Visibility.Collapsed));

        public System.Windows.Controls.Page MainContent
        {
            get { return (System.Windows.Controls.Page)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(System.Windows.Controls.Page), typeof(MainViewModel));



        #endregion DependencyProperties & Properties

        #region Simple View Properties

        private enum Pages { CUSTOMERS, ADD_ORDERS, SEARCH_ORDERS, ORDERS_HISTORY, ORDER_QUEUE };

        private CustomerSearchView customerSearch = new CustomerSearchView();
        private CustomersView customers = new CustomersView();
        private OrderRegistrationView orderRegistration = new OrderRegistrationView();
        private OrdersSearchView ordersSearch = new OrdersSearchView();
        private AppAuthorizationView appAuthorization = new AppAuthorizationView();
        private OrdersQueueView ordersQueue = new OrdersQueueView();

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

        #region Handling login\unlogin to the app 

        private static int currentUserId;
        public static int CurrentUserId
        {
            get
            {
                return currentUserId;
            }
            set
            {
                currentUserId = value;
            }
        }

        private ICommand unloggingFromApp;

        public ICommand UnloggingFromApp
        {
            get
            {
                if (unloggingFromApp == null)
                    unloggingFromApp = new MyCommands(OnUnLogin);
                return unloggingFromApp;
            }
        }

        public Visibility CurrentUserNameVisibility
        {
            get { return (Visibility)GetValue(CurrentUserNameVisibilityProperty); }
            set { SetValue(CurrentUserNameVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentUserNameVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserNameVisibilityProperty =
            DependencyProperty.Register("CurrentUserNameVisibility", typeof(Visibility), typeof(MainViewModel), new PropertyMetadata(Visibility.Collapsed));
        

        public string CurrentUserName
        {
            get { return (string)GetValue(CurrentUserNameProperty); }
            set { SetValue(CurrentUserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentUserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserNameProperty =
            DependencyProperty.Register("CurrentUserName", typeof(string), typeof(MainViewModel), new PropertyMetadata(""));



        private async void OnLogin()
        {
            CurrentUserName = await AppLoggingChecker.GetUserNameById(currentUserId);
            CurrentUserNameVisibility = Visibility.Visible;
        }

        private void OnUnLogin(object parameter)
        {
            MenuVisibility = Visibility.Collapsed;
            CurrentUserNameVisibility = Visibility.Collapsed;
            MainContent = appAuthorization;
            
        }

        #endregion

        #endregion Commands & Handlers
    }
}
