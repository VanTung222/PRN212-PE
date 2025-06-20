using System;
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
using System.Windows.Shapes;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;

namespace AirConditionerShop_TranVanTung
{
    /// <summary>
    /// Interaction logic for detailWindow.xaml
    /// </summary>
    public partial class detailWindow : Window
    {
        private AirConService _service = new();
        private SupplierService SupService = new();

        public detailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //AirConditioner x = new AirConditioner();
            AirConditioner x = new();
            x.AirConditionerId = int.Parse(AirConditionerIdTextBox.Text);
            x.AirConditionerName = AirConditionerNameTextBox.Text;
            x.Warranty = WarrantyTextBox.Text;
            x.SoundPressureLevel = SoundPressureLevelTextBox.Text;
            x.FeatureFunction = FeatureFunctionTextBox.Text;
            x.Quantity = int.Parse(QuantityTextBox.Text);
            x.DollarPrice = double.Parse(DollarPriceTextBox.Text);
            //x.SupplierId = "SC0006";
            x.SupplierId = SupplierIdComboBox.SelectedValue.ToString();
            _service.AddAirCon(x);

            this.Close(); //đóng cửa sổ detailWindow sau khi lưu thành công
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //đóng cửa sổ detailWindow mà không lưu gì cả
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             FillComboBox(); 
        }

        //hàm helper, trợ giúp đổ data vào
        private void FillComboBox()
        {
            var suppliers = SupService.GetAllSuppliers();
            SupplierIdComboBox.ItemsSource = suppliers;

            SupplierIdComboBox.DisplayMemberPath = "SupplierName"; //hiển thị tên nhà cung cấp

            SupplierIdComboBox.SelectedValuePath = "SupplierId"; //lấy giá trị id của nhà cung cấp
        }




    }
}
