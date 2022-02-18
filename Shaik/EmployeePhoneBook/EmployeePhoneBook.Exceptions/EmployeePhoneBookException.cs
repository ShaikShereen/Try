using System;

namespace EmployeePhoneBook.Exceptions
{
    public class EmployeePhoneBookException:ApplicationException
    {
        public EmployeePhoneBookException():base()
        {

        }

        public EmployeePhoneBookException(string message):base(message)
        {

        }
        public EmployeePhoneBookException(string message,Exception innerException) : base(message,innerException)
        {

        }

        static void Main()
        {
        }
    }
}
