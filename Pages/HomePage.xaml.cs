using AccountingApp.Data.ConcreteData;
using AccountingApp.PresentationData;
using System.Collections.Generic;
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

            ListOfItems.Loaded += (x, y) =>
            {
                navObj = ListText;

                EmployeeData sergey = new EmployeeData()
                {
                    FirstName = "Сергей",
                    SecoundName = "Бельчиков",
                    LastName = "Романович",
                    Post = "Программист (верстает до 2 ночи)",
                    Status = "Работает",
                    TabNumber = "231231",
                    CampusName = "Западный офис",
                    Floor = 2,
                    LastPointNumber = 1184,
                    RoomNumber = 25
                };

                EmployeeData valery = new EmployeeData()
                {
                    FirstName = "Антон",
                    SecoundName = "Шпак",
                    LastName = "Павлович",
                    Post = "Сис. админ",
                    Status = "Работает",
                    TabNumber = "23123231",
                    CampusName = "Южный офис",
                    Floor = 3,
                    LastPointNumber = 5569,
                    RoomNumber = 56
                };

                List<AccountingCardElement> cards = new List<AccountingCardElement>();
                cards.Add(new AccountingCardElement()
                {
                    Accounting = new Data.AccountingItemData()
                    {
                        AccountingCard = new Data.ConcreteData.AccountingCard()
                        {
                            CardID = 10213,
                            FloorID = 1231241,
                            FrameID = 1544,
                            OrgtechID = 77868,
                            SubsectionID = 44443,
                            PcCID = 4234,
                            ShortName = "AMD Ryzen"
                        },
                        EmployeeData = sergey
                    }
                });


                cards.Add(new AccountingCardElement()
                {
                    Accounting = new Data.AccountingItemData()
                    {
                        AccountingCard = new Data.ConcreteData.AccountingCard()
                        {
                            CardID = 1468,
                            FloorID = 1231577,
                            FrameID = 78667,
                            OrgtechID = 555,
                            SubsectionID = 7861,
                            PcCID = 7898,
                            ShortName = "Amd Threadreaper"
                        },
                        EmployeeData = valery
                    }
                });

                cards.Add(new AccountingCardElement()
                {
                    Accounting = new Data.AccountingItemData()
                    {
                        AccountingCard = new Data.ConcreteData.AccountingCard()
                        {
                            CardID = 126787,
                            FloorID = 8796,
                            FrameID = 432134,
                            OrgtechID = 7897,
                            SubsectionID = 13783,
                            PcCID = 78979,
                            ShortName = "AMD Epic"
                        },
                        EmployeeData = sergey
                    }
                });

                cards.Add(new AccountingCardElement()
                {
                    Accounting = new Data.AccountingItemData()
                    {
                        AccountingCard = new Data.ConcreteData.AccountingCard()
                        {
                            CardID = 789,
                            FloorID = 4564,
                            FrameID = 7341,
                            OrgtechID = 783783,
                            SubsectionID = 11543,
                            PcCID = 786576,
                            ShortName = "AMD Radeon"
                        },
                        EmployeeData = valery
                    }
                });

                cards.Add(new AccountingCardElement()
                {
                    Accounting = new Data.AccountingItemData()
                    {
                        AccountingCard = new Data.ConcreteData.AccountingCard()
                        {
                            CardID = 8764,
                            FloorID = 767313,
                            FrameID = 4313,
                            OrgtechID = 1312,
                            SubsectionID = 6789,
                            PcCID = 12312,
                            ShortName = "AMD RX"
                        },
                        EmployeeData = valery
                    }
                });

                foreach (AccountingCardElement item in cards)
                    item.OnCardSelected += ItemClicked;

                ListOfItems.ItemsSource = cards;
            };
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
    }
}