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

namespace IntershipProject.ViewModels
{
    public class WinEventHandlerClass : DependencyObject
    {

        public WinEventHandlerClass()
        {
            MainContent = customers;
        }        

        #region DependencyProperties


        public Visibility CustomerStackPanelVisibility
        {
            get { return (Visibility)GetValue(CustomerStackPanelVisibilityProperty); }
            set { SetValue(CustomerStackPanelVisibilityProperty, value); }
        }        

        public static readonly DependencyProperty CustomerStackPanelVisibilityProperty =
            DependencyProperty.Register("CustomerStackPanelVisibility", typeof(Visibility), typeof(WinEventHandlerClass), new PropertyMetadata(Visibility.Collapsed));



        public Visibility OrdersStackPanelVisibility
        {
            get { return (Visibility)GetValue(OrdersStackPanelVisibilityProperty); }
            set { SetValue(OrdersStackPanelVisibilityProperty, value); }
        }
        
        public static readonly DependencyProperty OrdersStackPanelVisibilityProperty =
            DependencyProperty.Register("OrdersStackPanelVisibility", typeof(Visibility), typeof(WinEventHandlerClass), new PropertyMetadata(Visibility.Collapsed));



        public System.Windows.Controls.Page MainContent
        {
            get { return (System.Windows.Controls.Page)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(System.Windows.Controls.Page), typeof(WinEventHandlerClass));



        #endregion DependencyProperties & Properties

        #region Simple Properties

        private CustomerSearch customerSearch = new CustomerSearch();
        private Customers customers = new Customers();
        private OrderRegistration orderRegistration = new OrderRegistration();
        private OrdersSearch ordersSearch = new OrdersSearch();

        #endregion

        #region Commands & Handlers

        #region Handlers of menu buttons clicks

        private ICommand changeCustomerSPVisibilty;
        public ICommand ChangeCustomerSPVisibilty
        {
            get
            {
                if (changeCustomerSPVisibilty == null)
                    changeCustomerSPVisibilty = new MyCommands((object obj) => CustomerStackPanelVisibility =  (CustomerStackPanelVisibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed);
                return changeCustomerSPVisibilty;

            }
        }

        private ICommand changeOrdersSPVisibilty;
        public ICommand ChangeOrdersSPVisibilty
        {
            get
            {
                if (changeOrdersSPVisibilty == null)
                    changeOrdersSPVisibilty = new MyCommands((object obj) => OrdersStackPanelVisibility = (OrdersStackPanelVisibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed);
                return changeOrdersSPVisibilty;

            }
        }

        private ICommand changeWindowContent;
        public ICommand ChangeWindowContent
        {
            get
            {
                if (changeWindowContent == null)
                    changeWindowContent = new MyCommands(changeWindowContentFunc);
                return changeWindowContent;

            }
        }
        private void changeWindowContentFunc(object param)
        {
            switch (param as string)
            {
                case "customerSearch":
                    MainContent = customerSearch;
                    break;

                case "customers":
                    MainContent = customers;
                    break;

                case "orderRegistration":
                    MainContent = orderRegistration;
                    break;

                case "ordersSearch":
                    MainContent = ordersSearch;
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

        #region Resizing window commands

        bool ResizeInProcess = false;
        private ICommand resize_InitCommand;
        public ICommand Resize_InitCommand
        {
            get
            {
                if (resize_InitCommand == null)
                    resize_InitCommand = new MyCommands(Resize_Init);
                return resize_InitCommand;
            }
                
        }
        private void Resize_Init(object sender)
        {
            if (sender is Rectangle senderRect)
            {
                ResizeInProcess = true;
                senderRect.CaptureMouse();
            }
        }


        private ICommand resize_EndCommand;
        public ICommand Resize_EndCommand
        {
            get
            {
                if (resize_EndCommand == null)
                    resize_EndCommand = new MyCommands(Resize_End);
                return resize_EndCommand;
            }

        }
        private void Resize_End(object sender)
        {
            if (sender is Rectangle senderRect)
            {
                ResizeInProcess = false;
                senderRect.ReleaseMouseCapture();
            }
        }


        private ICommand resize_Form;
        public ICommand Resize_Form
        {
            get
            {
                if (resize_Form == null)
                    resize_Form = new MyCommands(Resizeing_Form);
                return resize_Form;
            }
        }
        private void Resizeing_Form(object sender)
        {

            if (ResizeInProcess)
            {
                MouseDevice e = InputManager.Current.PrimaryMouseDevice;
                Rectangle senderRect = sender as Rectangle;
                Window mainWindow = senderRect.Tag as Window;
                if (senderRect != null)
                {
                    double width = e.GetPosition(mainWindow).X;
                    double height = e.GetPosition(mainWindow).Y;
                    senderRect.CaptureMouse();
                    if (senderRect.Name.ToLower().Contains("right"))
                    {
                        width += 5;
                        if (width >= 0)
                            mainWindow.Width = width;
                    }
                    if (senderRect.Name.ToLower().Contains("left"))
                    {
                        width -= 5;
                        if(mainWindow.Width >= mainWindow.MinWidth)
                            mainWindow.Left += width;
                        
                        width = mainWindow.Width - width;
                        if (width >= 0)
                        {
                            mainWindow.Width = width;
                        }
                    }
                    if (senderRect.Name.ToLower().Contains("bottom"))
                    {
                        height += 5;
                        if (height >= 0)
                            mainWindow.Height = height;
                    }
                    if (senderRect.Name.ToLower().Contains("top"))
                    {
                        height -= 5;

                        if(mainWindow.Width >= mainWindow.MinWidth)
                            mainWindow.Top += height;

                        height = mainWindow.Height - height;
                        if (height >= 0)
                        {
                            mainWindow.Height = height;
                        }
                    }
                }
            }
        }


        #endregion Resizing window commands


        #endregion Commands & Handlers
    }
}
