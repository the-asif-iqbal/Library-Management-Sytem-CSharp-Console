using System;
using System.Collections.Generic;
using LibraryMS.Data;
using LibraryMS.Entity;
using System.Text;

namespace LibraryMS.Validation
{
    public class VolunteerCheck
    {
        //CHECKING VOLUNTEER LOGIN CREDENTIALS
        public bool VolunteerLogin(string volunteerEmail, string volunteerPass)
        {
            VolunteerData volunteerData = new VolunteerData();
            List<Volunteer> volunteers = volunteerData.getAllVolunteersData();
            bool isDone = volunteers.Exists(v => v.VolunteerEmail == volunteerEmail && v.VolunteerPass == volunteerPass);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("**Logged In Successfully**");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**Invalid Email ID or Password**");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}
