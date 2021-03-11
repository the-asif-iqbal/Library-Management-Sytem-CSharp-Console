using System;
using System.Collections.Generic;
using LibraryMS.Entity;
using System.Text;

namespace LibraryMS.Data
{
    public class VolunteerData
    {
        //LIST USED TO STORE VOLUNTEER DETAILS
        private static List<Volunteer> volunteers = new List<Volunteer>()
        {
            new Volunteer()
            {
                VolunteerID=1,VolunteerName="Harpreet Kaur",VolunteerEmail="harpreet@tinytown.ca",VolunteerPass="Word@123"
            },
            new Volunteer()
            {
                VolunteerID=2,VolunteerName="Asif Iqbal",VolunteerEmail="asif@tinytown.ca",VolunteerPass="Word@123"
            },
        };
        //RETURNING VOLUNTEER FROM VOLUNTEER TABLE
        public List<Volunteer> getAllVolunteersData()
        {
            return volunteers;
        }
    }
}
