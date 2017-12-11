using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Configuration;
using IntershipProject.Models;
using Unity;

namespace IntershipProject.ViewModels
{
    public class AppAuthorizationViewModel : DependencyObject
    {
        #region Contructor

        public AppAuthorizationViewModel()
        {
        }

        #endregion Constructor

        #region UnityContainer

        protected IUnityContainer unityContainer;
         
        #endregion

        #region App authorization props and handlers

        public delegate void AppEnterEventHandler();
        public static event AppEnterEventHandler SuccessAuthorization;
        public void SuccessAuthorizationHandler()
        {
            SuccessAuthorization?.Invoke();
        }


        #endregion App authorization props and handlers

        #region Dependency properties

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Login.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(AppAuthorizationViewModel));


        
        public string errorString
        {
            get { return (string)GetValue(errorStringProperty); }
            set { SetValue(errorStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for errorString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty errorStringProperty =
            DependencyProperty.Register("errorString", typeof(string), typeof(AppAuthorizationViewModel), new PropertyMetadata(null));



        public Visibility ConnectionErrorStringVisibility
        {
            get { return (Visibility)GetValue(ConnectionErrorStringVisibilityProperty); }
            set { SetValue(ConnectionErrorStringVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConnectionErrorStringVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectionErrorStringVisibilityProperty =
            DependencyProperty.Register("ConnectionErrorStringVisibility", typeof(Visibility), typeof(AppAuthorizationViewModel), new PropertyMetadata(Visibility.Collapsed));



        public bool IsConnectionChecking
        {
            get { return (bool)GetValue(IsConnectionCheckingProperty); }
            set { SetValue(IsConnectionCheckingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConnectionChecking.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsConnectionCheckingProperty =
            DependencyProperty.Register("IsConnectionChecking", typeof(bool), typeof(AppAuthorizationViewModel), new PropertyMetadata(false));




        public string ConnectionErrorStringContent
        {
            get { return (string)GetValue(ConnectionErrorStringContentProperty); }
            set { SetValue(ConnectionErrorStringContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConnectionErrorStringContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectionErrorStringContentProperty =
            DependencyProperty.Register("ConnectionErrorStringContent", typeof(string), typeof(AppAuthorizationViewModel), new PropertyMetadata(null));






        #endregion Dependency propertries

        #region Authorization press button handler

        private ICommand logInTheApp;

        public ICommand LogInTheApp
        {
            get
            {
                if (logInTheApp == null)
                    logInTheApp = new MyCommands(logInTheAppHandler);
                return logInTheApp;
            }
        }

        private async void logInTheAppHandler(object parameter)
        {
            IsConnectionChecking = true;
            ConnectionErrorStringVisibility = Visibility.Collapsed;          
            

            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
           
            ConnectionErrorStringContent = await AppLoggingChecker.IsUserExist(Login, password);

            if (ConnectionErrorStringContent == null)
            {

                SuccessAuthorization?.Invoke();
           
            }
            else
                ConnectionErrorStringVisibility = Visibility.Visible;


            IsConnectionChecking = false;
        }

        #endregion Authorization press button handler

    }
}