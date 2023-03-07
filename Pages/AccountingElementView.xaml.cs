using AccountingApp.Data;
using AccountingApp.PresentationData;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace AccountingApp.Pages
{
    public sealed partial class AccountingElementView : Page
    {
        private AccountingItemData accountingItem;

        public AccountingItemData AccountingItem { get => accountingItem; set => accountingItem = value; }

        public AccountingElementView()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                foreach (string item in accountingItem.HistoryElement)
                    HistoryList.Children.Add(new HistoryElement() { ShortDescription = item, ItemData = accountingItem.EmployeeData });
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
                anim.TryStart(CardDataBlock);
            
            if (e.Parameter != null)
                if (e.Parameter is AccountingCardElement)
                    AccountingItem = (e.Parameter as AccountingCardElement).Accounting;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", CardDataBlock);
        }

        private void ReturnToMain(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainPage.Instance.NavigateFrame("HomePage", null);
        }
    }
}