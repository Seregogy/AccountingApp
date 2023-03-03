using Windows.UI.Xaml.Controls;

namespace AccountingApp.Other
{
    public sealed partial class Tag : UserControl
    {
        private string tagName;
        private string key;

        public string TagName { get => tagName; set => tagName = value; }
        public string Key { get => key; set => key = value; }

        public Tag()
        {
            InitializeComponent();
        }
    }
}