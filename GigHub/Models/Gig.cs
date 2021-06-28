using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        //who
        //when
        //where
        //genre

        //Properties
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        public String Venue { get; set; }
        public Genre Genre { get; set; }
    }
}