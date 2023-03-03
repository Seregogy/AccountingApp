using AccountingApp.Data.ConcreteData;

namespace AccountingApp.Data
{
    public class AccountingItemData
    {
        private AccountingCard accountingCard;
        private EmployeeData employeeData;

        public AccountingCard AccountingCard { get => accountingCard; set => accountingCard = value; }
        public EmployeeData EmployeeData { get => employeeData; set => employeeData = value; }
    }
}