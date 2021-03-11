using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMS.Validation;
using LibraryMS.Entity;
using LibraryMS.Exception;
using System.Threading.Tasks;

namespace LibraryMS.Main
{
    public class ResourceMain
    {
        private Resource resource = new Resource();
        //ADD RESOURCE INTO RESOURCE TABLE
        public void AddResource()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n-----Add Resource-----");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Title: ");
                resource.Title = Console.ReadLine();
                Console.Write("ISBN: ");
                resource.ISBN = double.Parse(Console.ReadLine());
                Console.Write("Author/Artist: ");
                resource.AuthorArtist = Console.ReadLine();
                Console.Write("Resource Type: ");
                resource.ResourceType = Console.ReadLine();
                resource.ResourceType = resource.ResourceType.ToUpper();
                Console.Write("Price: ");
                resource.Price = double.Parse(Console.ReadLine());
                ResourceCheck addResource = new ResourceCheck();
                addResource.AddResourceCheck(resource.Title, resource.ISBN, resource.AuthorArtist, resource.ResourceType, resource.Price);
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
        //RETRIEVE RESOURCE FROM RESOURCE TABLE
        public void getAllResources()
        {
            List<Resource> resources = new List<Resource>();
            ResourceCheck resourceTemp = new ResourceCheck();
            resources = resourceTemp.getAllResourcesCheck();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------Resource List---------------------------");

            Console.WriteLine("Title" + "\t\t\tISBN"+ "\t\t\tAuthor/Artist" + "\t\tType" + "\t\tPrice");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Resource resource in resources)
            {
                Console.WriteLine(resource.Title + "\t\t\t" + resource.ISBN + "\t\t\t" + resource.AuthorArtist + "\t\t\t" + resource.ResourceType + "\t\t " + resource.Price);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
