using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Exception;
using System.Threading.Tasks;

namespace LibraryMS.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Welcome to TinyTown's Library Inventory Management System - Version 1.0");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("**Created by Asif Iqbal & Harpreet Kaur**");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n1: LogIn\n" +
                                                        "2: QUIT");
                    Console.Write("Enter your Menu Option: ");

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            VolunteerMain volunteerMain = new VolunteerMain();
                            volunteerMain.VolunteerLogin();
                            break;
                        case 2:
                            logLoop = false;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Thank you for using Tiny Town's Library Inventory Management. Have a good day ahead!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("**Enter a valid input**");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
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
    }
}
