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
    /// Interaction logic for AddVehiclePage.xaml
    /// </summary>
    public partial class AddVehiclePage : PageFunction<String>
    {
        private VehicleModel model = new VehicleModel();
        private VehicleController vehContr = new VehicleController();

        public AddVehiclePage()
        {
            InitializeComponent();
            this.DataContext = model;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string error;
            if (vehContr.Validate(model, out error) 
                && vehContr.OnAddVehicle(model, out error))
            {
                MessageBox.Show("Operation finished successfully", "Notification",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                this.OnReturn(null);
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnReturn(null);
        }
    }
}