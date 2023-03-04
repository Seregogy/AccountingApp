using AccountingApp.Data.ConcreteData;

namespace AccountingApp.Data
{
    public class AccountingItemData
    {
        private AccountingCard accountingCard;
        private EmployeeData employeeData;
        private PCData pcData;

        public AccountingCard AccountingCard { get => accountingCard; set => accountingCard = value; }
        public EmployeeData EmployeeData { get => employeeData; set => employeeData = value; }
        public PCData PcData { get => pcData; set => pcData = value; }
    }
}