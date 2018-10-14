using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class Item
    {
        public string ActionName { get; set; }

        public string ControllerName { get; set; }
        
        public bool Visibility { get; set; }
    }
}
