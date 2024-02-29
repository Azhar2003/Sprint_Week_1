using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint_Week_1.Models
{
    public class Inventory
    {
        [Key]
        public string Name { get; set; }
        public string Descripiton { get; set; }
        public string price { get; set; }
    }
}
