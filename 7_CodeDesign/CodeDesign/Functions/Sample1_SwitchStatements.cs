using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Sample1_SwitchStatements
    {
        // Switch statements should only be buried in a low-level class and never be repeated.
        // This can be done with Polymorphism.

        public Money CalculatePay(Employee employee)
        {
            switch (employee.Type)
            {
                case Employee.EmployeeType.COMISSIONED:
                    return this.CalculateComissionedPay(employee);
                case Employee.EmployeeType.HOURLY:
                    return this.CalculateHourlyPay(employee);
                case Employee.EmployeeType.SALARIED:
                    return this.CalculateSalariedPay(employee);
                default:
                    throw new Exception();
            }
        }

        private Money CalculateSalariedPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        private Money CalculateHourlyPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        private Money CalculateComissionedPay(Employee employee)
        {
            throw new NotImplementedException();
        }

        // There are several problems with this function.
        // It´s large and will grow when new EmployeeTypes are added.
        // It does more than one thing, violates the SRP (has more than one reason to change).
        // Violates the OCP because it must change when new types are added.
        // There could be a unlimited number of other functions with the same structure.



        // The solution to this problem is to bury the switch statement in an ABSTRACT FACTORY.
        // The factory uses the switch statement to create appropriate instances of derivatives of Employee
        // and the various functions.
        // Switch statements should only appears once, and only if they are used to create polymorphic objects, and are hidden
        // behind an inheritance relationship so that the rest of the system can´t see them.

        // -------------------------------------------------------------- //
        // -------------------------------------------------------------- //
        // -------------------------------------------------------------- //
        public abstract class EmployeeBase
        {
            public abstract bool IsPayDay();
            public abstract Money CalculatePay();
            public abstract void DeliverPay(Money pay);
        }

        // -------------------------------------------------------------- //

        public class ComissionedEmployee : EmployeeBase
        {
            public override Money CalculatePay()
            {
                throw new NotImplementedException();
            }

            public override void DeliverPay(Money pay)
            {
                throw new NotImplementedException();
            }

            public override bool IsPayDay()
            {
                throw new NotImplementedException();
            }
        }

        public class HourlyEmployee : EmployeeBase
        {
            public override Money CalculatePay()
            {
                throw new NotImplementedException();
            }

            public override void DeliverPay(Money pay)
            {
                throw new NotImplementedException();
            }

            public override bool IsPayDay()
            {
                throw new NotImplementedException();
            }
        }

        public class SalariedEmployee : EmployeeBase
        {
            public override Money CalculatePay()
            {
                throw new NotImplementedException();
            }

            public override void DeliverPay(Money pay)
            {
                throw new NotImplementedException();
            }

            public override bool IsPayDay()
            {
                throw new NotImplementedException();
            }
        }

        // -------------------------------------------------------------- //

        public class EmployeeRecord
        {
            public enum EmployeeType
            {
                COMISSIONED,
                HOURLY,
                SALARIED
            }

            public EmployeeType Type { get; set; }
        }

        // -------------------------------------------------------------- //

        public interface IEmployeeFactory
        {
            EmployeeBase CreateEmployee(EmployeeRecord employeeRecord);
        }

        // -------------------------------------------------------------- //

        public class EmployeeFactory : IEmployeeFactory
        {
            public EmployeeBase CreateEmployee(EmployeeRecord employeeRecord)
            {
                switch (employeeRecord.Type)
                {
                    case EmployeeRecord.EmployeeType.COMISSIONED:
                        return new ComissionedEmployee();
                    case EmployeeRecord.EmployeeType.HOURLY:
                        return new HourlyEmployee();
                    case EmployeeRecord.EmployeeType.SALARIED:
                        return new SalariedEmployee();
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        // ---------------------------------------------------------------- //

        public class sss
        {
            IEmployeeFactory employeeFactory = new EmployeeFactory();

            public void CalculatePay()
            {
                EmployeeRecord record = new EmployeeRecord()
                {
                    Type = EmployeeRecord.EmployeeType.HOURLY
                };

                EmployeeBase employee = employeeFactory.CreateEmployee(record);

                employee.CalculatePay();
            }
        }
    }
}
