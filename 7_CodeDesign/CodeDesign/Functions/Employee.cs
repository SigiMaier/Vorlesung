namespace Functions
{
    public class Employee
    {
        public enum EmployeeType
        {
            COMISSIONED,
            HOURLY,
            SALARIED
        }

        public EmployeeType Type { get; set; }
    }
}