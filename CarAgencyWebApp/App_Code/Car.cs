using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAgencyWebApp.App_Code
{
    public class Car
    {
       
        
            public int Id { get; set; }
            public string Company { get; set; }
            public string Model { get; set; }
            public int Seats { get; set; }
            public string PlateNumber { get; set; }
            public string Type { get; set; }
            public string Color { get; set; }
        
    }
}