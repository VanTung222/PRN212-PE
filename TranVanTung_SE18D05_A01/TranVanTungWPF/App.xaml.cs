using System.Windows;

namespace TranVanTungWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Chỉ tạo 1 LoginWindow duy nhất
            var loginWindow = new Views.LoginWindow();
            MainWindow = loginWindow;
            loginWindow.Show();
        }
    }
}
