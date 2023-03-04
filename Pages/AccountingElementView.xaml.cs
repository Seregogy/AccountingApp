using AccountingApp.Data;
using AccountingApp.PresentationData;
using System.Collections.Generic;
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
                List<HistoryElement> historyElements = new List<HistoryElement>();

                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест (поступление техники) от ASPack", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест перенаправление техники в (хз)", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест ещё тестик", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест перевод на нового ответсвенного", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест перевод на нового ответсвенного", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест ()", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест () от ASPack", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест () от ASPack", ItemData = accountingItem });
                HistoryList.Children.Add(new HistoryElement() { ShortDescription = "Тест () от ASPack", ItemData = accountingItem });
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