using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Input;
using System.Windows.Controls;

namespace IntershipProject.ViewModels
{
    class AppAuthorizationViewManager : DependencyObject
    {

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
            DependencyProperty.Register("Login", typeof(string), typeof(AppAuthorizationViewManager));



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

        private void logInTheAppHandler(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;

            if (Login == "123" & password == "123")
                SuccessAuthorization?.Invoke();
        }

        #endregion Authorization press button handler


    }
}