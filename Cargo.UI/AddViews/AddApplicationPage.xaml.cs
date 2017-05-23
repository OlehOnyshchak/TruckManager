﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cargo.Controller.Models;
using Cargo.Controller;

namespace Cargo.UI.AddViews
{
    /// <summary>
    /// Interaction logic for AddApplicationPage.xaml
    /// </summary>
    public partial class AddApplicationPage : PageFunction<String>
    {
        private ApplicationController controller = new ApplicationController();
        private AddApplicationModel model = new AddApplicationModel();

        public AddApplicationPage()
        {
            InitializeComponent();
            this.DataContext = model;
            this.KeepAlive = true;
            this.Title = "Add Application - Step 1";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Title = CommonProperties.ProgramName;
            this.OnReturn(null);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            if (controller.Validate(model, out error))
            {
                var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
                if (frame.CanGoForward)
                {
                    frame.GoForward();
                }
                else
                {
                    var nextPage = new AddAddressPage(model, true);
                    nextPage.Return += ReturnHandle;

                    frame.Navigate(nextPage);
                }
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReturnHandle(object sender, ReturnEventArgs<String> e)
        {
            string error;
            if (controller.OnApplicationAdd(model, out error))
            {
                MessageBox.Show("Operation finished successfully", "Notification",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Title = CommonProperties.ProgramName;
            this.OnReturn(null);
        }
    }
}
