using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPsystem.Models
{
    public class ProductModel
    {
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Class { get; set; }
        public decimal Price { get; set; }
        public string Purcahse_ID { get; set; }
    }
}