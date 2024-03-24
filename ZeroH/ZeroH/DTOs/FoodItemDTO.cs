using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroH.EF;

namespace ZeroH.DTOs
{
    public class FoodItemDTO
    {
        public int FoodItem_ID { get; set; }
        public int LogRequest_ID { get; set; }
        public int R_ID { get; set; }
        public string FoodName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Status { get; set; }

        public virtual LoginLog LoginLog { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}