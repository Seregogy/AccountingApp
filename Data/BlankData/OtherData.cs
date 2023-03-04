namespace AccountingApp.Data.BlankData
{
    public class OtherData
    {
        private string pcID;

        private ComputerType computerType;

        private string userName;
        private string ipAdress;

        private string motherBoard;
        private string osName;
        private bool isActivated;
        private string activationKey;

        public string PcID { get => $"ID компьютера: {pcID}"; set => pcID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string IpAdress { get => ipAdress; set => ipAdress = value; }
        public string MotherBoard { get => motherBoard; set => motherBoard = value; }
        public string OsName { get => osName; set => osName = value; }
        public bool IsActivated { get => isActivated; set => isActivated = value; }
        public string ActivationKey { get => activationKey; set => activationKey = value; }
        public ComputerType ComputerType { get => computerType; set => computerType = value; }
    }
}