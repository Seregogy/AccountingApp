using AccountingApp.Data.ConcreteData;
using System.Collections.Generic;

namespace AccountingApp.Data
{
    public class AccountingItemData
    {
        private AccountingCard accountingCard;
        private EmployeeData employeeData;
        private PCData pcData;
        private List<string> historyElement = new List<string>();

        public AccountingCard AccountingCard { get => accountingCard; set => accountingCard = value; }
        public EmployeeData EmployeeData { get => employeeData; set => employeeData = value; }
        public PCData PcData { get => pcData; set => pcData = value; }
        public List<string> HistoryElement { get => historyElement; set => historyElement = value; }
    }
}