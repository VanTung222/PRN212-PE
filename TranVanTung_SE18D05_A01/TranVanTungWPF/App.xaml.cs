using System.Windows;

namespace TranVanTungWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginWindow = new Views.LoginWindow();
            loginWindow.Show();
        }
    }
}
