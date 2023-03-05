using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace AccountingApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += (x, y) => Instance = this;
        }

        private static MainPage mainPage;

        public static MainPage Instance { get => mainPage; private set => mainPage = value; }

        private void Main_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem item = args.SelectedItem as Microsoft.UI.Xaml.Controls.NavigationViewItem;

            if (!args.IsSettingsSelected && item.Tag != null)
                NavigateFrame(item.Tag.ToString(), null);
        }

        private void MainFrame_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NavigateFrame("HomePage", null);
        }

        public void NavigateFrame(string name, object data)
        {
            string type = $"{nameof(AccountingApp)}.{nameof(Pages)}.{name}";

            MainFrame.Navigate(Type.GetType(type), data, new DrillInNavigationTransitionInfo());
        }
    }
}