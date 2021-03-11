using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS.Entity
{
    //USER/MEMBER CLASS
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PhoneNumber { get; set; }
        public int BorrowedCount { get; set; }
        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = 0;
            BorrowedCount = 0;
        }
    }
    //REQUESTED RESOURCE CLASS
    public class RequestedResource
    {
        public double ISBN { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
    }
    //BORROWED  RESOURCE CLASS
    public class BorrowedResource
    {
        public double ISBN { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
    }
}

