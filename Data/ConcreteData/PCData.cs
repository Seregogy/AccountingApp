using AccountingApp.Data.BlankData;

namespace AccountingApp.Data.ConcreteData
{
    public class PCData
    {
        private ProcessorData processorData;
        private GraphicsData graphicsData;
        private OtherData otherData;

        public ProcessorData ProcessorData { get => processorData; set => processorData = value; }
        public GraphicsData GraphicsData { get => graphicsData; set => graphicsData = value; }
        public OtherData OtherData { get => otherData; set => otherData = value; }
    }
}