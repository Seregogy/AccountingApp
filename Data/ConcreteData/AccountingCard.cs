using System;

namespace AccountingApp.Data.ConcreteData
{
    public class AccountingCard
    {
        private string shortName;

        private ulong cardID;
        private ulong subsectionID;
        private ulong pcCID;
        private ulong orgtechID;
        private ulong frameID;
        private ulong floorID;
        private DateTime date;

        public string ShortName { get => shortName; set => shortName = value; }
        public ulong CardID { get => cardID; set => cardID = value; }
        public ulong SubsectionID { get => subsectionID; set => subsectionID = value; }
        public ulong PcCID { get => pcCID; set => pcCID = value; }
        public ulong OrgtechID { get => orgtechID; set => orgtechID = value; }
        public ulong FrameID { get => frameID; set => frameID = value; }
        public ulong FloorID { get => floorID; set => floorID = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}