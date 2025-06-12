using AccountingApp.Data.BlankData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using static AccountingApp.Data.GlobalConst;

namespace AccountingApp.Data
{
    public class DataBase
    {
        private static DataBase instance = new DataBase();
        public static DataBase Instance { get => instance; }

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

        public static Task InitDataBaseAsync()
        {
            return RestoreDataBaseState();
        }

        public async static Task RestoreDataBaseState()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file;

            try
            {
                file = await folder.GetFileAsync(DATABASE_PATH);
            }
            catch (Exception)
            {
                file = await folder.CreateFileAsync(DATABASE_PATH);

                var localProjectDatabaseFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///DataBase/DataBase.json"));

                await FileIO.WriteTextAsync(file, await FileIO.ReadTextAsync(localProjectDatabaseFile));
            }

            var clipboardPackage = new DataPackage();
            clipboardPackage.SetText(file.Path);
            Clipboard.SetContent(clipboardPackage);

            instance = JsonConvert.DeserializeObject<DataBase>(await FileIO.ReadTextAsync(file));
        }
    }
}