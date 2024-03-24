using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroH.EF;

namespace ZeroH.DTOs
{
    public class RestaurantDTO
    {
        public int Restaurant_ID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ResturantLog_ID { get; set; }
        public virtual LoginLog LoginLog { get; set; }
    }
}