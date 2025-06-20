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

    }
}