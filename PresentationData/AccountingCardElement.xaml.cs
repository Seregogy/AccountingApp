using AccountingApp.Data;
using Windows.UI.Xaml.Controls;

namespace AccountingApp.PresentationData
{
    public sealed partial class AccountingCardElement : UserControl
    {
        private AccountingItemData accounting;
        public AccountingItemData Accounting { get => accounting; set => accounting = value; }


        private string shortName;
        public string ShortName { get => shortName; set => shortName = value; }

        public delegate void CardSelected(AccountingCardElement uIElement);
        private event CardSelected onCardSelected;

        public event CardSelected OnCardSelected
        {
            add => onCardSelected += value;
            remove => onCardSelected -= value;
        }

        public AccountingCardElement()
        {
            InitializeComponent();
        }

        public AccountingCardElement(AccountingItemData accountingCard)
        {
            Accounting = accountingCard;
            InitializeComponent();
        }

        private void Grid_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) => onCardSelected?.Invoke(this);
    }
}