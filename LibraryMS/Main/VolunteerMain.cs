using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Validation;
using System.Threading.Tasks;
using LibraryMS.Exception;

namespace LibraryMS.Main
{
    public class VolunteerMain
    {
        public void VolunteerLogin()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n-----Login-----");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Email ID: ");
                string VolunteerEmail = Console.ReadLine();
                Console.Write("Password: ");
                string VolunteerPass = Console.ReadLine();
                VolunteerCheck volunteerCheck = new VolunteerCheck();
                bool isDone = volunteerCheck.VolunteerLogin(VolunteerEmail, VolunteerPass);
                if (isDone)
                {
                    MainMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            catch (LibraryMSException)
            {
                throw new LibraryMSException("**Some unknown exception is occured**");
            }
        }
        private void getMainMenu()
        {
            Console.Write("\n1: Add Resource\n" +
                                        "2: Lend Resource\n" +
                                        "3: Return Resource\n" +
                                        "4: Show All Resources\n" +
                                        "5: Resource On Loan\n" +
                                        "6: Add Member\n" +
                                        "7: Show All Members\n" +
                                        "8: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("LOGOUT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nEnter your Menu Option: ");
        }
        private void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-----Main Menu-----");
            Console.ForegroundColor = ConsoleColor.White;
            bool menuLoop = true;
            while (menuLoop)
            {
                try
                {
                    getMainMenu();
                    int menuCase = int.Parse(Console.ReadLine());
                    switch (menuCase)
                    {
                        case 1:
                            ResourceMain resourceMain = new ResourceMain();
                            resourceMain.AddResource();
                            break;
                        case 2:
                            LendResource();
                            break;
                        case 3:
                            ReturnBorrowed();
                            break;
                        case 4:
                            ResourceMain resourceMain2 = new ResourceMain();
                            resourceMain2.getAllResources();
                            break;
                        case 5:
                            UserMain userMain = new UserMain();
                            userMain.getBorrowedResources();
                            break;
                        case 6:
                            UserMain userMain1 = new UserMain();
                            userMain1.AddUser();
                            break;
                        case 7:
                            UserMain userMain2 = new UserMain();
                            userMain2.getAllUsers();
                            break;
                        case 8:
                            menuLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("**ERROR - Enter Valid Menu Option**");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    menuLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Please try again**");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("**Some unknown exception is occured**");
                }
            }
        }
        //LEND RESOURCE
        public void LendResource()
        {
            try
            {
                Console.Write("User Name: ");
                string firstName = Console.ReadLine();
                Console.Write("ISBN: ");
                double isbn = double.Parse(Console.ReadLine());
                UserCheck userCheck = new UserCheck();
                userCheck.LendResourceCheck(firstName, isbn);
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
        //RETURN RESOURCE
        public void ReturnBorrowed()
        {
            try
            {
                Console.Write("User Name: ");
                string firstName = Console.ReadLine();
                Console.Write("ISBN: ");
                double isbn = double.Parse(Console.ReadLine());
                UserCheck userCheck = new UserCheck();
                userCheck.ReturnBorrowedCheck(firstName, isbn);
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
       
    }
}
