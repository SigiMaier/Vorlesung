
using Employee.Contracts;

namespace GeneralManagement
{
    public class CTO
    {
        private readonly IEmployeeSaver employeeSaver;

        public CTO(IEmployeeSaver employeeSaver)
        {
            this.employeeSaver = employeeSaver;
        }

        public void SaveEmployee()
        {
            this.employeeSaver.Save();
        }

    }
}
