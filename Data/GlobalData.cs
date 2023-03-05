using AccountingApp.Data.BlankData;
using AccountingApp.Data.ConcreteData;
using AccountingApp.PresentationData;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;

namespace AccountingApp.Data
{
    public static class GlobalData
    {
        private static List<AccountingItemData> accountingItemData;

        public static List<AccountingItemData> AccountingItemData { get => accountingItemData; set => accountingItemData = value; }

        public static void InitDataBase()
        {
            if (AccountingItemData != null) return;
            else
            {
                accountingItemData = new List<AccountingItemData>();
                GenerateDataBase();
            }
        }

        public static List<AccountingItemData> GenerateDataBase()
        {
            PCData pcData = new PCData()
            {
                GraphicsData = new GraphicsData()
                {
                    Frequency = "1900 MHz",
                    GraphicsCardName = "RX 5700 XT",
                    Interfaces = "HDMI/DisplayPort",
                    ProcessorsCount = 2560,
                    VideoMemory = 8
                },
                OtherData = new OtherData()
                {
                    UserName = "RePti-LoiD",
                    ActivationKey = "06O6X-84T2U-YM6B6-5WTOT-60378",
                    OsName = "Windows 11 Pro",
                    ComputerType = ComputerType.Компьютер,
                    IpAdress = "15.198.55.120",
                    IsActivated = true,
                    MotherBoard = "GIGABYTE H510M H",
                    PcID = "43547",
                    RamCount = 2,
                    RamSize = 16,
                    Hdd = "WD Blue 1TB"
                },
                ProcessorData = new ProcessorData()
                {
                    IsGraphicsExists = false,
                    ProcessorName = "AMD Ryzen 5 3600",
                    ProcessorSocket = "AM4"
                }
            };


            ProcessorData processorData = new ProcessorData();
            processorData.IsGraphicsExists = true;
            processorData.ProcessorSocket = "AM4";
            processorData.ProcessorName = "AMD Ryzen 5 3600";

            GraphicsData graphicsData = new GraphicsData()
            {
                GraphicsCardName = "AMD Radeon RX 5700XT",
                Interfaces = "HDMI/DisplayPort",
                Frequency = "1900 Mhz",
                ProcessorsCount = 2500
            };

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
                Accounting = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = 10213,
                        FloorID = 1231241,
                        FrameID = 1544,
                        OrgtechID = 77868,
                        SubsectionID = 44443,
                        PcCID = 4234,
                        ShortName = "AMD Ryzen"
                    },
                    EmployeeData = sergey,
                    PcData = pcData
                }
            });


            cards.Add(new AccountingCardElement()
            {
                Accounting = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = 1468,
                        FloorID = 1231577,
                        FrameID = 78667,
                        OrgtechID = 555,
                        SubsectionID = 7861,
                        PcCID = 7898,
                        ShortName = "Amd Threadreaper"
                    },
                    EmployeeData = valery,
                    PcData = pcData
                }
            });

            cards.Add(new AccountingCardElement()
            {
                Accounting = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = 126787,
                        FloorID = 8796,
                        FrameID = 432134,
                        OrgtechID = 7897,
                        SubsectionID = 13783,
                        PcCID = 78979,
                        ShortName = "AMD Epic"
                    },
                    EmployeeData = sergey,
                    PcData = pcData
                }
            });

            cards.Add(new AccountingCardElement()
            {
                Accounting = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = 789,
                        FloorID = 4564,
                        FrameID = 7341,
                        OrgtechID = 783783,
                        SubsectionID = 11543,
                        PcCID = 786576,
                        ShortName = "AMD Radeon"
                    },
                    EmployeeData = valery,
                    PcData = pcData
                }
            });

            cards.Add(new AccountingCardElement()
            {
                Accounting = new AccountingItemData()
                {
                    AccountingCard = new AccountingCard()
                    {
                        CardID = 8764,
                        FloorID = 767313,
                        FrameID = 4313,
                        OrgtechID = 1312,
                        SubsectionID = 6789,
                        PcCID = 12312,
                        ShortName = "AMD RX"
                    },
                    EmployeeData = valery,
                    PcData = pcData
                }
            });

            foreach (AccountingCardElement item in cards)
                accountingItemData.Add(item.Accounting);

            string strObject = Newtonsoft.Json.JsonConvert.SerializeObject(AccountingItemData, Newtonsoft.Json.Formatting.Indented);

            try
            {
                if (File.Exists(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Bundles.json")))
                {
                    DataPackage dataPackage = new DataPackage();
                    dataPackage.SetText(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
                    Clipboard.SetContent(dataPackage);
                }
                else
                {
                    File.CreateText(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Bundles.json"));
                    DataPackage dataPackage = new DataPackage();
                    dataPackage.SetText(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
                    Clipboard.SetContent(dataPackage);
                }

                File.WriteAllText(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Bundles.json"), strObject);
            }
            catch (Exception ex)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Content = ex.StackTrace;
                contentDialog.Title = ex.Message;
                contentDialog.PrimaryButtonText = "OK";
                contentDialog.ShowAsync();
            }

            return accountingItemData;
        }
    }
}