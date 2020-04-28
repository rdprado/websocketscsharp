using System.Windows;
using UIClient;

namespace UIWPF
{
    public partial class MainWindow : Window
    {
        private readonly Proxy proxy = new Proxy("ExampleSendReceiveHub");

        public MainWindow()
        {
            InitializeComponent();

            proxy.SendDataResponseAction = (string response) =>
            {
                textBlockConsole.Text = $"{textBlockConsole.Text}\n{response}";
            };

            btnAddData.Click += async (s, e) =>
            {
                await proxy.SendData(textBoxInputData.Text);
            };
        }

        public async void WindowLoaded(object sender, RoutedEventArgs handler)
        {
            await proxy.StartConnection();
        }
    }
}
