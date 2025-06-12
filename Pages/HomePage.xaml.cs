﻿using AccountingApp.Data;
using AccountingApp.Data;
using AccountingApp.PresentationData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace AccountingApp.Pages
{
    public sealed partial class HomePage : Page
    {
        private UIElement navObj;

        public HomePage()
        {
            InitializeComponent();

            ListOfItems.Loaded += async (x, y) =>
            {
                await LoadCardsAsync();
            };
        }

        private async Task LoadCardsAsync()
        {
            await GlobalData.InitDataBaseAsync();
            Data.DataBase.InitDataBaseAsync();

            List<AccountingCardElement> cards = new List<AccountingCardElement>();
            foreach (AccountingItemData item in GlobalData.AccountingItemData)
            {
                AccountingCardElement card = new AccountingCardElement();
                card.Accounting = item;

                card.OnCardSelected += ItemClicked;

                cards.Add(card);
            }

            ListOfItems.ItemsSource = cards;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", navObj);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(ListText);
            }
        }

        private void ItemClicked(AccountingCardElement uIElement)
        {
            navObj = uIElement;

            MainPage.Instance.NavigateFrame(nameof(AccountingElementView), uIElement);
        }

        private void LaunchEditPage(object sender, RoutedEventArgs e)
        {
            navObj = sender as UIElement;

            MainPage.Instance.NavigateFrame(nameof(AccountingElementEditPage), null);
        }

        private async void UpdatePage(object sender, RoutedEventArgs e)
        {
            await GlobalData.LoadDBAsync();
            await LoadCardsAsync();
        }
    }
}