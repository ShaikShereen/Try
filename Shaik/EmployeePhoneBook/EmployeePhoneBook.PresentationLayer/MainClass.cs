using System;
using System.Collections.Generic;
using System.Text;
using EmployeePhoneBook.Entities;
using EmployeePhoneBook.BusinessLayer;
using EmployeePhoneBook.Exceptions;

namespace EmployeePhoneBook.PresentationLayer
{
    class MainClass
    {
        static void Main()
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ListAllEmployees();
                        break;
                    case 3:
                        SearchEmployeeByID();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteEmployee()
        {
            try
            {
                int deleteEmployeeID;
                Console.Write("Enter EmployeeID to Delete: ");
                deleteEmployeeID = Convert.ToInt32(Console.ReadLine());
                Employee deleteEmployee = EmployeeBL.SearchEmployeeBL(deleteEmployeeID);
                if (deleteEmployee != null)
                {
                    bool employeedeleted = EmployeeBL.DeleteEmployeeBL(deleteEmployeeID);
                    if (employeedeleted)
                        Console.WriteLine("Employee deleted");
                    else

                        Console.WriteLine("Employee not deleted");
                }
                else
                {
                    Console.WriteLine("No employee details available ");

                }
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private static void UpdateEmployee()
        {
            try
            {
                int updateEmployeeID;
                Console.Write("Enter EmployeeID to update details : ");
                updateEmployeeID = Convert.ToInt32(Console.ReadLine());
                Employee updatedEmployee = EmployeeBL.SearchEmployeeBL(updateEmployeeID);
                if (updatedEmployee != null)
                {
                    Console.WriteLine("Update Employee Name:");
                    updatedEmployee.EmployeeName = Console.ReadLine();
                    Console.WriteLine("Update Phone Number:");
                    updatedEmployee.EmployeecontactNumber = Console.ReadLine();

                    bool employeeUpdated= EmployeeBL.UpdateEmployeeBL(updatedEmployee);
                    if (employeeUpdated)
                        Console.WriteLine("Employee details updated");
                    else

                        Console.WriteLine("Employee details not updated");
                }
                else
                {
                    Console.WriteLine("No employee details available ");

                }
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

        private static void SearchEmployeeByID()
        {
            try
            {
                int searchEmployeeID;
                Console.Write("Enter EmployeeID to search : ");
                searchEmployeeID = Convert.ToInt32(Console.ReadLine());
                Employee searchEmployee = EmployeeBL.SearchEmployeeBL(searchEmployeeID);
                if (searchEmployee != null)
                {
                    Console.WriteLine("********");
                    Console.WriteLine("EmployeeID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("********");
                    Console.WriteLine("[0]\t\t[1]\t\t[2]", searchEmployee.EmployeeID,searchEmployee.EmployeeName, searchEmployee.EmployeecontactNumber);
                    Console.WriteLine("********");
                }
                else
                {
                    Console.WriteLine("No employee details available ");

                }
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);

            }

        }


        private static void ListAllEmployees()
        {
            try
            {
                List<Employee> employeeList = EmployeeBL.GetAllEmployeeBL();
                if (employeeList != null)
                {
                    Console.WriteLine("********");
                    Console.WriteLine("EmployeeID\t\tName\t\tPhonenumber");
                    Console.WriteLine("********");
                    foreach(Employee employee in employeeList)
                    {
                        Console.WriteLine("[0]\t\t[1]\t\t[2]", employee.EmployeeID, employee.EmployeeName, employee.EmployeecontactNumber);
                    }
                   
                    Console.WriteLine("********");
                }
                else
                {
                    Console.WriteLine("No employee details available ");

                }
            }
            catch (EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);

            }

        }



        private static void AddEmployee()
        {
            try
            {
                Employee newEmployee = new Employee();
                Console.WriteLine("Enter EmployeeID: ");
                newEmployee.EmployeeID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name:");
                newEmployee.EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter Employee Phone number:");
               
               newEmployee.EmployeecontactNumber = Console.ReadLine();
                bool employeeAdded = EmployeeBL.AddEmployeeBL(newEmployee);
                if (employeeAdded)
                    Console.WriteLine("Employee added");
                else
                    Console.WriteLine("Employee not added");

            }catch(EmployeePhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("******Employee Phone Book Menu*****");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List all Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.WriteLine("***************");

        }

       

    }
}

