using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS.Entity
{
    //VOLUNTEER CLASS
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerPass { get; set; }
        public Volunteer()
        {
            VolunteerID = 0;
            VolunteerName = string.Empty;
            VolunteerEmail = string.Empty;
            VolunteerPass = string.Empty;
        }
    }
}
