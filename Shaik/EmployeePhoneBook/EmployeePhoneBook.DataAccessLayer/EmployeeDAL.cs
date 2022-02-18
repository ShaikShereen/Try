using System;
using System.Collections.Generic;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.Exceptions;

namespace EmployeePhoneBook.DataAccessLayer
{
    public class EmployeeDAL
    {
        public static List<Employee> employeeList = new List<Employee>();
        public bool AddEmployeeDAL(Employee newEmployee)
        {
            bool employeeAdded = false;
            try
            {
                
                employeeList.Add(newEmployee);
                    employeeAdded = true;

            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return employeeAdded;
        }

        public List<Employee> GetAllEmployeeDAL()
        {
            
            return employeeList;

        }
        public Employee SearchEmployeeDAL(int searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                searchEmployee = employeeList.Find(employee => employee.EmployeeID == searchEmployeeID);
                
            }

            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return searchEmployee;

        }

        public bool UpdateEmployeeDAL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].EmployeeID == updateEmployee.EmployeeID)
                    {
                        employeeList[i].EmployeeName = updateEmployee.EmployeeName;
                        employeeList[i].EmployeecontactNumber = updateEmployee.EmployeecontactNumber;
                        employeeUpdated = true;
                    }
                }
                

            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return employeeUpdated;
        }

        public bool DeleteEmployeeDAL(int deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                Employee deleteEmployee = employeeList.Find(employee => employee.EmployeeID == deleteEmployeeID);
                if(deleteEmployee!=null)
                {
                    employeeList.Remove(deleteEmployee);
                    employeeDeleted = true;
                }
               

            }
            catch (SystemException ex)
            {
                throw new EmployeePhoneBookException(ex.Message);
            }
            return employeeDeleted;


        }
        static void Main()
        {

        }
    }
}