using AccountingApp.Data;
using Windows.UI.Xaml.Controls;

namespace AccountingApp.PresentationData
{
    public sealed partial class HistoryElement : UserControl
    {
        private AccountingItemData itemData;
        private string shortDescription;

        public HistoryElement()
        {
            InitializeComponent();
        }

        public HistoryElement(AccountingItemData itemData)
        {
            ItemData = itemData;

            InitializeComponent();
        }

        public AccountingItemData ItemData { get => itemData; set => itemData = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
    }
}