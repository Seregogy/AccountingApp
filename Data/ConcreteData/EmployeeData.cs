namespace AccountingApp.Data.ConcreteData
{
    public class EmployeeData
    {
        private string firstName;
        private string secoundName;
        private string lastName;
        private string tabNumber;
        private string post;
        private string status;
        private string campusName;
        private int roomNumber;
        private int floor;

        private int lastPointNumber;
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecoundName { get => secoundName; set => secoundName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string TabNumber { get => tabNumber; set => tabNumber = value; }
        public string Post { get => post; set => post = value; }
        public string Status { get => status; set => status = value; }
        public string CampusName { get => campusName; set => campusName = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }
        public int Floor { get => floor; set => floor = value; }
        public int LastPointNumber { get => lastPointNumber; set => lastPointNumber = value; }

        public string FullCampusName { get => $"Офис {CampusName}, этаж {Floor}"; }
    }
}