using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;

namespace AirConditionerShop_TranVanTung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    // class mainwindow kế thừa class wwindow - class có sẵn trong .NET SDK

    // để chuyển đổi từ xaml sang c# thì sử dụng công cụ xamlc.exe
    //dùng phím F7 từ design -> chuyển sang code
    // phím shift+F7 để chuyển từ code sang design
    public partial class MainWindow : Window
    {

        private AirConService _service = new(); 

        public MainWindow()
        {
            InitializeComponent();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            detailWindow d = new();
            //d.Show();
            d.ShowDialog(); //hiển thị cửa sổ detailWindow và chờ người dùng tương tác
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            AirConsDataGrid.ItemsSource = null; //để tránh lỗi khi binding
            AirConsDataGrid.ItemsSource = _service.GetAllAirCons();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //đóng cửa sổ MainWindow
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selectedAirCon = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selectedAirCon != null)
            {
                detailWindow d = new();
                d.EditAirCon = selectedAirCon; //gán đối tượng cần sửa
                d.ShowDialog(); //hiển thị cửa sổ detailWindow và chờ người dùng tương tác
                FillDataGrid(); //cập nhật lại dữ liệu trong DataGrid sau khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một điều hòa để sửa.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selectedAirCon = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selectedAirCon != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa điều hòa này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _service.DeleteAirCon(selectedAirCon.AirConditionerId);
                    FillDataGrid(); //cập nhật lại dữ liệu trong DataGrid sau khi xóa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một điều hòa để xóa.");
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string feature = FeatureFunctionTextBox.Text.Trim();
            string quantityText = QuantityTextBox.Text.Trim();

            if (string.IsNullOrEmpty(feature) && string.IsNullOrEmpty(quantityText))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm.");
                return;
            }

            int quantity = 0;
            if (!string.IsNullOrEmpty(quantityText) && !int.TryParse(quantityText, out quantity))
            {
                MessageBox.Show("Số lượng phải là số nguyên.");
                return;
            }

            var results = _service.SearchAirConsByFeatureQuantity(feature, quantity);
            if (results != null && results.Count > 0)
            {
                AirConsDataGrid.ItemsSource = null;
                AirConsDataGrid.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
            }
        }


    }
}