using System;
using LibraryMS.Data;
using LibraryMS.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryMS.Validation
{
    public class ResourceCheck
    {
        enum RType
        {
            BOOK,
            MAGAZINE,
            DVD,
            CD
        }
        //RESOURCE VALIDATION
        private bool ResourceValidation(string title, double isbn, string authorArtist, string resourceType, double price)
        {
            bool resourceValid;
            if (title.Length <= 1 || title.Length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Resource Title - shold be between 2-50 characters**");
                Console.ForegroundColor = ConsoleColor.White;

                resourceValid = false;
            }
            else if (authorArtist.Length <= 1 || authorArtist.Length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Author/Artist Name - shold be between 2-50 characters**");
                Console.ForegroundColor = ConsoleColor.White;

                resourceValid = false;
            }
            else if (authorArtist.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Author/Artist Name - shold not contain digits**");
                Console.ForegroundColor = ConsoleColor.White;

                resourceValid = false;
            }
            else if (!(new Regex(@"^(\d{5})?$").IsMatch(isbn.ToString())))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid ISBN - should contain 5 digits**");
                Console.ForegroundColor = ConsoleColor.White;

                resourceValid = false;
            }
            else if (!(resourceType.Equals(RType.BOOK.ToString()) || resourceType.Equals(RType.CD.ToString()) || resourceType.Equals(RType.DVD.ToString()) || resourceType.Equals(RType.MAGAZINE.ToString())))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Resource Type**");
                Console.ForegroundColor = ConsoleColor.White;

                resourceValid = false;
            }
            else
            {
                resourceValid = true;
            }
            return resourceValid;
         }
        ResourceData dataResource = new ResourceData();
        //ADDING RESOURCE INTO RESOURCE TABLE
        public void AddResourceCheck(string title, double isbn, string authorArtist, string resourceType, double price)
        {
            bool isValidated = ResourceValidation(title, isbn, authorArtist, resourceType, price);
            if (isValidated)
            {
                bool isDone = dataResource.AddResourcesData(title, isbn, authorArtist, resourceType, price);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("**Resource Added Successfully**");
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
        //RETURNING RESOURCES FROM RESOURCE TABLE
        public List<Resource> getAllResourcesCheck()
        {
            List<Resource> resources = dataResource.getAllResourcesData();
            return resources;
        }
    }
}
