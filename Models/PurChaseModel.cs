using System;

namespace ERPsystem.Models
{
    public class PurChaseModel
    {
        public string Purchase_ID { get; set; }
        public int Purchase_Class { get; set; }
        public int Product_Quantity { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? ArriveTime { get; set; }
        public decimal Purchase_Price { get; set; }
        public bool Isdelete { get; set; }
    }
}