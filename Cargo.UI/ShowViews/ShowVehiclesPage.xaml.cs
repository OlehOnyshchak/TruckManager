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
using Cargo.Controller;
using Cargo.Controller.Models;

namespace Cargo.UI.ShowViews
{
    /// <summary>
    /// Interaction logic for ShowVehiclesPage.xaml
    /// </summary>
    public partial class ShowVehiclesPage : PageFunction<String>
    {
        private VehicleController vehContr = new VehicleController();
        private AddApplicationModel appModel = null;

        public ShowVehiclesPage()
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();
            m_buttonSelect.Visibility = Visibility.Hidden;
        }

        public ShowVehiclesPage(AddApplicationModel appMod)
        {
            InitializeComponent();
            m_listView.ItemsSource = vehContr.GetVehicles();
            appModel = appMod;

            m_buttonSelect.Visibility = Visibility.Visible;
            this.Title = "Choose Vehicle - Step 5";
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_listView.SelectedIndex != -1)
            {
                appModel.Vehicle = m_listView.SelectedItem as VehicleModel;
                this.OnReturn(null);
            }
            else
            {
                MessageBox.Show("You must select the Vehicle", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = Application.Current.MainWindow.FindName("_mainFrame") as Frame;
            frame.GoBack();
        }
    }
}
