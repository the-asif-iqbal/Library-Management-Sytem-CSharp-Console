using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS.Entity
{
    //RESOURCE CLASS
    public class Resource
    {
        public double ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorArtist { get; set; }
        public string ResourceType { get; set; }
        public double Price { get; set; }
        public int ResourceCount { get; set; }
        public void Resources()
        {
            Title = string.Empty;
            ISBN = 0;
            AuthorArtist = string.Empty;
            ResourceType = string.Empty.ToUpper();
            Price = 0;
            ResourceCount = 0;
        }
    }

}
