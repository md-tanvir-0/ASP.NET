using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroH.EF;

namespace ZeroH.DTOs
{
    public class CollectRequestDTO
    {
        public int Request_ID { get; set; }
        public Nullable<System.DateTime> CollectionTime { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Assignee_ID { get; set; }
        public int Restaurant_ID { get; set; }
        public int Food_ID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual FoodItem FoodItem { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}