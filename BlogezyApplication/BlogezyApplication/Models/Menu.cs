using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class Menu : Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
