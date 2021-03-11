using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Entity;
using LibraryMS.Validation;
using System.Threading.Tasks;
using LibraryMS.Exception;

namespace LibraryMS.Main
{
     public class UserMain
    {
        private User user = new User();
        //ADD USER INTO USER TABLE
        public void AddUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n-----Add User/Member-----");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("First Name: ");
                user.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                user.LastName = Console.ReadLine();
                Console.Write("Phone Number: ");
                user.PhoneNumber = double.Parse(Console.ReadLine());
                UserCheck userCheck = new UserCheck();
                userCheck.AddUsersCheck(user);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please Enter Valid Input**");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("**Some unknown exception is occured**");
            }
        }
        //SHOW BORROWED RESOURCES FROM BORROWED TABLE
        public void getBorrowedResources()
        {
            UserCheck userCheck = new UserCheck();
            List<BorrowedResource> borrowedResources = userCheck.getBorrowedResourceCheck();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------Resources On Loan---------------------------");

            Console.WriteLine("ISBN" + "\t\t\tTitle" + "\t\t\tFirst Name");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (BorrowedResource borrowed in borrowedResources)
            {
                Console.WriteLine(borrowed.ISBN + "\t\t\t" + borrowed.Title + "\t\t\t" + borrowed.FirstName);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //SHOW ALL USERS FROM USER TABLE
        public void getAllUsers()
        {
            List<User> users = new List<User>();
            UserCheck userCheck = new UserCheck();
            users = userCheck.getAllUsersCheck();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------User/Member List---------------------------");

            Console.WriteLine("First Name" + "\t\tLast Name" + "\t\tPhone Numer");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (User user in users)
            {
                Console.WriteLine(user.FirstName + "\t\t\t" + user.LastName + "\t\t\t" + user.PhoneNumber);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
