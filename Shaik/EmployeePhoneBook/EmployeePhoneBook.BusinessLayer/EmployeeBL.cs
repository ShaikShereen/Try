using System;
using System.Collections.Generic;
using System.Text;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.Exceptions;
using EmployeePhoneBook.DataAccessLayer;


namespace EmployeePhoneBook.BusinessLayer
{
    public class EmployeeBL
    {
        private static bool ValidateEmployee(Employee employee)
        {
            StringBuilder sb = new StringBuilder();
            bool validEmployee = true;
            if (employee.EmployeeID <= 0)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Invalid Employee ID");
            }

            if (employee.EmployeeName == string.Empty)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Name Required");
            }
            if (employee.EmployeecontactNumber.Length < 10)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Required 10 digits Phone Number");
            }

            if (validEmployee == false)

                throw new EmployeePhoneBookException(sb.ToString());
            return validEmployee;

        }
        public static bool AddEmployeeBL(Employee newEmployee)
        {
            bool employeeAdded = false;
            try
            {
                if (ValidateEmployee(newEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeAdded = employeeDAL.AddEmployeeDAL(newEmployee);
                }
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeAdded;
        }
        public static List<Employee> GetAllEmployeeBL()
        {
            List<Employee> employeeList = null;
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                employeeList = employeeDAL.GetAllEmployeeDAL();
            }
            catch (EmployeePhoneBookException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeList;
        }
        public static Employee SearchEmployeeBL(int searchEmployeeID)
        {
            Employee SearchEmployee = null;
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                SearchEmployee = employeeDAL.SearchEmployeeDAL(searchEmployeeID);
            }
            catch (EmployeePhoneBookException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SearchEmployee;
        }

        public static bool UpdateEmployeeBL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                if (ValidateEmployee(updateEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeUpdated = employeeDAL.UpdateEmployeeDAL(updateEmployee);
                }
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeUpdated;
        }

        public static bool DeleteEmployeeBL(int deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                if (deleteEmployeeID > 0)
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeDeleted = employeeDAL.DeleteEmployeeDAL(deleteEmployeeID);
                }

               
            }
            catch (EmployeePhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeDeleted;
        }
        static void Main()
        {
        }

    }
}
