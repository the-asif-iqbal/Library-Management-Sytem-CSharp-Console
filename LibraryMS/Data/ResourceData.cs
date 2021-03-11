using System;
using System.Collections.Generic;
using System.Text;
using LibraryMS.Entity;
using LibraryMS.Exception;

namespace LibraryMS.Data
{
    public class ResourceData
    {
        //LIST USED TO STORE RESOURCE DETAILS
        public static List<Resource> resources = new List<Resource>();

        //RETURNING RESOURCES FROM RESOURCE TABLE
        public List<Resource> getAllResourcesData()
        {
            return resources;
        }
        //ADDING RESOURCES INTO RESOURCE TABLE
        public bool AddResourcesData(string title, double isbn, string authorArtist, string resourceType, double price)
        {
            bool isDone = false;
            try
            {
                Resource addResource = new Resource() { Title = title, ISBN = isbn, AuthorArtist = authorArtist, ResourceType = resourceType, Price = price };
                resources.Add(addResource);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
            }
            return isDone;
        }
    }
}
