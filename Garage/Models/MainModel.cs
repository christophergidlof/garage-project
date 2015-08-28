using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Garage.Models;



namespace Garage.Models
{
    public class MainModel
    {
        public List<Garage.Models.FordonModel> Fordon { get; set; }
        public List<Garage.Models.NyhetModel> Nyhet { get; set; }

    }
}