using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using static AccountingApp.Data.GlobalConst;

namespace AccountingApp.Data
{
    public static class GlobalData
    {
        public static List<AccountingItemData> AccountingItemData { get; set; } = new List<AccountingItemData>();

        public static async Task InitDataBaseAsync()
        {
            if (AccountingItemData != null)
                return;

            await GenerateDataBaseAsync();
        }

        public static async Task<List<AccountingItemData>> GenerateDataBaseAsync()
        {
            await DataBase.InitDataBaseAsync();

            await LoadDBAsync();

            return AccountingItemData;
        }

        public static async Task LoadDBAsync()
        {
            var folder = ApplicationData.Current.LocalFolder;

            var file = await folder.GetFileAsync(BUNDLES_DATA_PATH) ?? await folder.CreateFileAsync(BUNDLES_DATA_PATH);

            AccountingItemData = JsonConvert.DeserializeObject<List<AccountingItemData>>(await FileIO.ReadTextAsync(file));
        }

        public static async Task SaveDBAsync()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.GetFileAsync(BUNDLES_DATA_PATH);
            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(AccountingItemData, Formatting.Indented));
        }
    }
}