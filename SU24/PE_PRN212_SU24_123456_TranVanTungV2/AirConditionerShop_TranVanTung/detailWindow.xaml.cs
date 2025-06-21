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

        public AirConditioner EditAirCon { get; set; } = null;

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

            if (EditAirCon == null)
                _service.AddAirCon(x);
            else
                _service.UpdateAirCon(x);

                this.Close(); //đóng cửa sổ detailWindow sau khi lưu thành công
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //đóng cửa sổ detailWindow mà không lưu gì cả
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElements(EditAirCon);
            if (EditAirCon != null)
            {
                DetailWindowModeLble.Content = "Cập nhật thông tin máy lạnh";
            } else
            {
                DetailWindowModeLble.Content = "Thêm mới máy lạnh"; //nếu không có đối tượng nào thì là thêm mới
            }    
            
        }

        //hàm helper, trợ giúp đổ data vào
        private void FillComboBox()
        {
            var suppliers = SupService.GetAllSuppliers();
            SupplierIdComboBox.ItemsSource = suppliers;

            SupplierIdComboBox.DisplayMemberPath = "SupplierName"; //hiển thị tên nhà cung cấp

            SupplierIdComboBox.SelectedValuePath = "SupplierId"; //lấy giá trị id của nhà cung cấp
        }

        //  hàm này đổ vào các ô nhập
        private void FillElements(AirConditioner x)
        {
            if (x == null)
                return;
            AirConditionerIdTextBox.Text = x.AirConditionerId.ToString();
            //disable không cho sửa
            AirConditionerIdTextBox.IsEnabled = false; //không cho sửa id
            AirConditionerNameTextBox.Text = x.AirConditionerName;
            WarrantyTextBox.Text = x.Warranty;
            SoundPressureLevelTextBox.Text = x.SoundPressureLevel;
            FeatureFunctionTextBox.Text = x.FeatureFunction;
            QuantityTextBox.Text = x.Quantity.ToString();
            DollarPriceTextBox.Text = x.DollarPrice.ToString();

            SupplierIdComboBox.SelectedValue = x.SupplierId; //đổ vào id của nhà cung cấp 
        }


    }
}
