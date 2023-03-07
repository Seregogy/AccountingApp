using AccountingApp.Data;
using AccountingApp.Data.ConcreteData;
using Windows.UI.Xaml.Controls;

namespace AccountingApp.PresentationData
{
    public sealed partial class HistoryElement : UserControl
    {
        private EmployeeData itemData;
        private string shortDescription;
        private int historyID;

        public HistoryElement()
        {
            InitializeComponent();
        }

        public HistoryElement(EmployeeData itemData)
        {
            ItemData = itemData;

            InitializeComponent();
        }

        public EmployeeData ItemData { get => itemData; set => itemData = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public int HistoryID { get => historyID; set => historyID = value; }
    }
}