using System;
using System.Collections.Generic;
using LibraryMS.Exception;
using LibraryMS.Entity;
using System.Text;

namespace LibraryMS.Data
{
    
    public class UserData
    {
        //LIST TO STORE USER/MEMBER DETAILS
        public static List<User> users = new List<User>();

        //RETURNING USERS FROM USER TABLE
        public List<User> getAllUsersData()
        {
            return users;
        }
        //ADDING USER INTO USER TABLE
        public bool AddUsersData(User user)
        {
            bool isDone = false;
            try
            {
                User addUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                };
                users.Add(addUser);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);

            }
            return isDone;
        }
        public static List<RequestedResource> requestedResources = new List<RequestedResource>();
        //LIST USED TO STORE BORROWED RESOURCE DETAILS
        public static List<BorrowedResource> borrowedResources = new List<BorrowedResource>();
        //RETRIEVE BORROWED RESOURCES FROM BORROWED TABLE
        public List<BorrowedResource> getBorrowedResourceData()
        {
            return borrowedResources;
        }
        //LEND RESOURCE DATA
        public bool LendResourceData(string firstName, double isbn)
        {
            bool isDone = false;
            try
            {
                User user = users.Find(u => u.FirstName == firstName);
                Resource resource = ResourceData.resources.Find(r => r.ISBN == isbn);
                user.BorrowedCount = user.BorrowedCount + 1;
                resource.ResourceCount = resource.ResourceCount + 1;
                BorrowedResource borrowedResource = new BorrowedResource()
                {
                    ISBN = resource.ISBN,
                    Title = resource.Title,
                    FirstName = user.FirstName
                };
                borrowedResources.Add(borrowedResource);

                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);

            }
            return isDone;
        }
        //RETURN RESOURCE DATA
        public bool ReturnResourceData(string firstName, double isbn)
        {
            bool isDone = false;
            try
            {
                User user = users.Find(u => u.FirstName == firstName);
                Resource resource = ResourceData.resources.Find(r => r.ISBN == isbn);
                BorrowedResource returnBorrowedResource = borrowedResources.Find(d => d.FirstName == firstName && d.ISBN == isbn);
                borrowedResources.Remove(returnBorrowedResource);
                user.BorrowedCount = user.BorrowedCount - 1;
                resource.ResourceCount = resource.ResourceCount - 1;
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
