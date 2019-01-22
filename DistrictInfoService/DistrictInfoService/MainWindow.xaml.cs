using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
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
using DataLibrary.DataAccess;
using DataLibrary.Logic;
using DistrictInfoService.Controllers;

namespace DistrictInfoService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataHandler.OpenConnection();

            var data = DistrictProcessor.GetAllDistricts();

            List<District> districts = new List<District>();

            foreach (var district in data)
            {
                districts.Add(new District{

                    district_ID = district.District_ID,
                    name = district.Name
                });
            }

            districtListView.ItemsSource = districts;
        }

        private void DistrictListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem is District item)
            {
                storeListView.ItemsSource = DistrictsController.GetStoresForDistrict(item.district_ID);

                List<Salesman>[] secondarySalesmen = DistrictsController.GetSecondarySalesmenForDistrict(item.district_ID);
                secondarySalesmanListView.ItemsSource = secondarySalesmen[0];
                availableSalesmanListView.ItemsSource = secondarySalesmen[1];


                List<Salesman>[] responsibleSalesmen = DistrictsController.GetResponsibleSalesmenForDistrict(item.district_ID);

                responsibleSalesmanListView.ItemsSource = responsibleSalesmen[0];
                ChooseResponsibleSalesmanComboBox.ItemsSource = responsibleSalesmen[1];
            }
        }

        private void SecondarySalesmanListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Salesman item)
            {
                Salesman salesman = new Salesman
                {
                    salesman_ID = item.salesman_ID,
                    name = item.name,
                };

                District selectedDistrict = (District) districtListView.SelectedItem;

                DistrictsController.RemoveSecondarySalesman(selectedDistrict.district_ID, item.salesman_ID);
                List<Salesman>[] salesmen = DistrictsController.GetSecondarySalesmenForDistrict(selectedDistrict.district_ID);

                secondarySalesmanListView.ItemsSource = null;
                availableSalesmanListView.ItemsSource = null;

                secondarySalesmanListView.Items.Clear();
                availableSalesmanListView.Items.Clear();


                secondarySalesmanListView.ItemsSource = salesmen[0];
                availableSalesmanListView.ItemsSource = salesmen[1];
            }
        }

        private void AvailableSalesmanListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Salesman item)
            {
                Salesman salesman = new Salesman
                {
                    salesman_ID = item.salesman_ID,
                    name = item.name,
                };

                District selectedDistrict = (District)districtListView.SelectedItem;

                DistrictsController.AddSecondarySalesman(selectedDistrict.district_ID, item.salesman_ID);

                List<Salesman>[] salesmen = DistrictsController.GetSecondarySalesmenForDistrict(selectedDistrict.district_ID);

                secondarySalesmanListView.ItemsSource = null;
                availableSalesmanListView.ItemsSource = null;

                secondarySalesmanListView.Items.Clear();
                availableSalesmanListView.Items.Clear();


                secondarySalesmanListView.ItemsSource = salesmen[0];
                availableSalesmanListView.ItemsSource = salesmen[1];
            }
        }

        private void ChooseResponsibleSalesmanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((sender as ComboBox).SelectedItem is Salesman item)
            {
                Salesman salesman = new Salesman
                {
                    salesman_ID = item.salesman_ID,
                    name = item.name,
                };

                District selectedDistrict = (District)districtListView.SelectedItem;

                DistrictsController.UpdateResponsibleSalesman(selectedDistrict.district_ID, item.salesman_ID);

                List<Salesman>[] responsibleSalesmen = DistrictsController.GetResponsibleSalesmenForDistrict(selectedDistrict.district_ID);

                responsibleSalesmanListView.ItemsSource = null;
                ChooseResponsibleSalesmanComboBox.ItemsSource = null;

                responsibleSalesmanListView.Items.Clear();
                ChooseResponsibleSalesmanComboBox.Items.Clear();

                responsibleSalesmanListView.ItemsSource = responsibleSalesmen[0];
                ChooseResponsibleSalesmanComboBox.ItemsSource = responsibleSalesmen[1];
            }
        }

    }
}
