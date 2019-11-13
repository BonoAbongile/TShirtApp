using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace T_ShirtApp
{
   public class TShirtItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public int DateOfOrder { get; set; }
        public string ShippingAddress { get; set; }
    }
}
