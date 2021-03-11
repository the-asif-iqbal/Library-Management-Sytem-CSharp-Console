using System;
using System.Collections.Generic;
using LibraryMS.Data;
using LibraryMS.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryMS.Validation
{
    public class UserCheck
    {
        //USER VALIDATION
        private bool UserValidation(User user)
        {
            bool userValid;

            if (user.FirstName.Length <= 1 || user.FirstName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid First Name - should be between 2-30 characters**");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.FirstName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid First Name - should not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.LastName.Length <= 1 || user.LastName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Last Name - should be between 2-30 characters**");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.LastName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Last Name - should not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (!(new Regex(@"^(\d{10})?$").IsMatch(user.PhoneNumber.ToString())))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Phone Number**");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else
            {
                userValid = true;
            }
            return userValid;
         }
         UserData userData = new UserData();

        //RETURNING USERS FROM USER TABLE
        public List<User> getAllUsersCheck()
        {
            List<User> users = userData.getAllUsersData();
            return users;
        }
        //ADDING USER INTO USER TABLE
        public void AddUsersCheck(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                bool isDone = userData.AddUsersData(user);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("**User Added Successfully**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please try again**");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //LEND RESOURCE 
        public void LendResourceCheck(string firstName, double isbn)
        {
            User user = UserData.users.Find(f => f.FirstName == firstName);
            Resource resource = ResourceData.resources.Find(i => i.ISBN == isbn);
            if (user.BorrowedCount < 1)
            {
                if (resource.ResourceCount < 1)
                {
                    bool isDone = userData.LendResourceData(firstName, isbn);
                    if (isDone)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("**Resource Borrowed Successfully**");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Please try again**");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Resource already borrowed by other user**");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**User cannot borrow more than one resource**");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //RETRIEVE BORROWED RESOURCES FROM BORROWED TABLE
        public List<BorrowedResource> getBorrowedResourceCheck()
        {
            return userData.getBorrowedResourceData();
        }
        //RETURN RESOURCE
        public void ReturnBorrowedCheck(string firstName, double isbn)
        {
            bool isDone = userData.ReturnResourceData(firstName, isbn);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("**Resource Returned Successfully**");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Please try again**");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
