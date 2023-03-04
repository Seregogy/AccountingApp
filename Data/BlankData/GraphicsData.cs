namespace AccountingApp.Data.BlankData
{
    public class GraphicsData
    {
        private string graphicsCardName;
        private string interfaces;
        private string frequency;
        private int processorsCount;
        private int videoMemory;

        public string GraphicsCardName { get => graphicsCardName; set => graphicsCardName = value; }
        public string Interfaces { get => interfaces; set => interfaces = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public int ProcessorsCount { get => processorsCount; set => processorsCount = value; }
        public int VideoMemory { get => videoMemory; set => videoMemory = value; }
    }
}