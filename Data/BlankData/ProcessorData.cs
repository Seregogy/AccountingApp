namespace AccountingApp.Data.BlankData
{
    public class ProcessorData
    {
        private string processorName;
        private string processorSocket;
        private bool isGraphicsExists;

        public string ProcessorName { get => processorName; set => processorName = value; }
        public string ProcessorSocket { get => processorSocket; set => processorSocket = value; }
        public bool IsGraphicsExists { get => isGraphicsExists; set => isGraphicsExists = value; }
    }
}