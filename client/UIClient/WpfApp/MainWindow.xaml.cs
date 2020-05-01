using System.Windows;
using UIClient;
using System.Diagnostics;

namespace UIWPF
{
    public partial class MainWindow : Window
    {
        private readonly Proxy proxy = new Proxy("ExampleSendReceiveHub");
        private readonly SpeedTestSpeedTestProxy speedTestproxy = new SpeedTestSpeedTestProxy("MessageSpeedTestHub");
        Stopwatch sw = new Stopwatch();

        private int messagesReceivedCount = 0;
        private int messageCountInputForTest = 0;
        public MainWindow()
        {
            InitializeComponent();

            proxy.SendDataResponseAction = (string response) =>
            {
                textBlockConsole.Text = $"{textBlockConsole.Text}\n{response}";
            };

            speedTestproxy.SpeedTestMessageReceived = (string response) =>
            {
                Dispatcher.Invoke(() =>
                {
                    messagesReceivedCount += 1;
                    textBlockSpeedTestConsole.Text = $"{messagesReceivedCount}";
                    if (messagesReceivedCount == messageCountInputForTest)
                    {
                        textBlockSpeedTestConsole.Text = $"{messagesReceivedCount} messages in {sw.Elapsed.TotalMilliseconds}ms";
                        sw.Stop();
                    }
                    else
                    {
                        textBlockSpeedTestConsole.Text = $"{messagesReceivedCount}";
                    }
                });
                
            };

            btnSpeedTest.Click += async (s, e) =>
            {
                textBlockSpeedTestConsole.Text = "0";
                messagesReceivedCount = 0;
                messageCountInputForTest = int.Parse(textBoxSpeedResultData.Text);
                sw.Start();
                speedTestproxy.StartTest(messageCountInputForTest);
            };

            btnAddData.Click += async (s, e) =>
            {
                await proxy.SendData(textBoxInputData.Text);
            };
        }

        public async void WindowLoaded(object sender, RoutedEventArgs handler)
        {
            await proxy.StartConnection();
            await speedTestproxy.StartConnection();
        }
    }
}
