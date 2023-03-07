using AccountingApp.Data.BlankData;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel.DataTransfer;

namespace AccountingApp.DataBase
{
    public class DataBaseHandler
    {
        private static DataBaseHandler instance;
        public static DataBaseHandler Instance { get => instance; }

        private List<ProcessorData> processorData = new List<ProcessorData>();
        private List<GraphicsData> graphicsData = new List<GraphicsData>();
        private List<string> ipAdresses = new List<string>();
        private List<string> keys = new List<string>();
        private List<string> osNames = new List<string>();
        private List<string> motherBoards = new List<string>();
        private List<string> hddS = new List<string>();

        public List<ProcessorData> Processors { get => processorData; set => processorData = value; }
        public List<GraphicsData> GraphicCards { get => graphicsData; set => graphicsData = value; }
        public List<string> IpAdresses { get => ipAdresses; set => ipAdresses = value; }
        public List<string> Keys { get => keys; set => keys = value; }
        public List<string> OsNames { get => osNames; set => osNames = value; }
        public List<string> MotherBoards { get => motherBoards; set => motherBoards = value; }
        public List<string> HDDs { get => hddS; set => hddS = value; }

        public static DataBaseHandler InitDataBaseHandler()
        {
            if (Instance == null) instance = new DataBaseHandler();
            instance.SerializeRuntimeDataBase();

            return instance;
        }

        public void SerializeRuntimeDataBase()
        {
            instance = Newtonsoft.Json.JsonConvert.DeserializeObject<DataBaseHandler>(File.ReadAllText(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "DataBase.json")));

            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
            Clipboard.SetContent(dataPackage);
        }
    }
}