using AccountingApp.Data;
using AccountingApp.Data.BlankData;
using AccountingApp.Data.ConcreteData;
using AccountingApp.DataBase;
using AccountingApp.Other;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace AccountingApp.Pages
{
    public sealed partial class AccountingElementEditPage : Page
    {
        private AccountingItemData accountingItem;
        public AccountingItemData AccountingItem { get => accountingItem; set => accountingItem = value; }

        #region const
        private const int maxSizeID = 9999999;

        #endregion

        public AccountingElementEditPage()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                Random random = new Random();

                AccountingItem = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = (ulong)random.Next(0, maxSizeID),
                        SubsectionID = (ulong)random.Next(0, maxSizeID),
                        PcCID = (ulong)random.Next(0, maxSizeID),
                        OrgtechID = (ulong)random.Next(0, maxSizeID),

                        Date = DateTime.Now
                    },
                    EmployeeData = new EmployeeData()
                    {
                        TabNumber = random.Next(0, maxSizeID).ToString(),
                    },
                    PcData = new PCData()
                    {
                        GraphicsData = new GraphicsData(),
                        ProcessorData = new ProcessorData(),
                        OtherData = new OtherData()
                        {
                            PcID = random.Next(0, maxSizeID).ToString()
                        }
                    },
                    HistoryElement = new List<string>()
                };

                CardID.Text = accountingItem.AccountingCard.SubsectionID.ToString();
                Sect.Key = accountingItem.AccountingCard.SubsectionID.ToString();
                pcId.Key = accountingItem.AccountingCard.PcCID.ToString();
                frame.Key = accountingItem.AccountingCard.FrameID.ToString();
                floor.Key = accountingItem.AccountingCard.FloorID.ToString();
                date.Key = accountingItem.AccountingCard.Date.ToString();
                EmpID.Key = accountingItem.EmployeeData.TabNumber.ToString();

                List<string> graphicsCardNames = new List<string>();
                foreach (var item in DataBaseHandler.Instance.GraphicCards)
                    graphicsCardNames.Add(item.GraphicsCardName);

                GraphicsSelect.ItemsSource = graphicsCardNames;

                List<string> procNames = new List<string>();
                foreach (ProcessorData item in DataBaseHandler.Instance.Processors)
                    procNames.Add(item.ProcessorName);

                ProcessorSelect.ItemsSource = procNames;

                List<string> hddNames = new List<string>();
                foreach (string item in DataBaseHandler.Instance.HDDs)
                    hddNames.Add(item);

                HddSelect.ItemsSource = hddNames;

                List<string> motherNames = new List<string>();
                foreach (string item in DataBaseHandler.Instance.MotherBoards)
                    motherNames.Add(item);

                MotherBoardSelect.ItemsSource = motherNames;

                List<string> osNames = new List<string>();
                foreach (string item in DataBaseHandler.Instance.OsNames)
                    osNames.Add(item);

                OSSelect.ItemsSource = osNames;

                List<string> keyNames = new List<string>();
                foreach (string item in DataBaseHandler.Instance.Keys)
                    keyNames.Add(item);

                KeyActivate.ItemsSource = keyNames;
            };
        }

        private void ReturnToMain(object sender, Windows.UI.Xaml.RoutedEventArgs e) => MainPage.Instance.NavigateFrame("HomePage", null);


        private void GraphicsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (GraphicsData item in DataBaseHandler.Instance.GraphicCards)
            {
                if (item.GraphicsCardName == (sender as ComboBox).SelectedValue.ToString())
                {
                    accountingItem.PcData.GraphicsData = item;
                    Ports.Key = item.Interfaces;
                    FreqCard.Key = item.Frequency;
                    ProcCount.Key = item.ProcessorsCount.ToString();
                    VideoMemory.Key = item.VideoMemory.ToString();
                    return;
                }
            } 
        }

        private void ProcessorSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ProcessorData item in DataBaseHandler.Instance.Processors)
            {
                if (item.ProcessorName == (sender as ComboBox).SelectedValue.ToString())
                {
                    accountingItem.PcData.ProcessorData = item;

                    Socket.Key = item.ProcessorSocket;
                    VideoCore.Key = item.IsGraphicsExists.ToString();
                    return;
                }
            }
        }

        private void RAMOnKeyChanged(Tag tag) => AccountingItem.PcData.OtherData.RamSize = Convert.ToInt32(tag.Key);

        private void RAMCountOnKeyChanged(Tag tag) => AccountingItem.PcData.OtherData.RamCount = Convert.ToInt32(tag.Key);

        private void HddSelect_SelectionChanged(object sender, SelectionChangedEventArgs e) => AccountingItem.PcData.OtherData.Hdd = HddSelect.SelectedItem.ToString();

        private void CardNameLostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e) => AccountingItem.AccountingCard.ShortName = (sender as TextBox).Text;

        private void NameChange(object sender, Windows.UI.Xaml.RoutedEventArgs e) => AccountingItem.EmployeeData.SecoundName = (sender as TextBox).Text;

        private void FNameChange(object sender, Windows.UI.Xaml.RoutedEventArgs e) => AccountingItem.EmployeeData.FirstName = (sender as TextBox).Text;

        private void LNameChange(object sender, Windows.UI.Xaml.RoutedEventArgs e) => AccountingItem.EmployeeData.LastName = (sender as TextBox).Text;

        private void PostChaned(Tag tag) => AccountingItem.EmployeeData.Post = tag.Key;

        private void StatusChange(Tag tag) => AccountingItem.EmployeeData.Status = tag.Key;

        private void FloorChange(Tag tag) => AccountingItem.EmployeeData.Floor = Convert.ToInt32(tag.Key);

        private void FrameNumChange(Tag tag) => AccountingItem.EmployeeData.CampusName = tag.Key;

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GlobalData.AccountingItemData.Add(AccountingItem);
            GlobalData.SaveDB();
            ReturnToMain(null, null);
        }
    }
}