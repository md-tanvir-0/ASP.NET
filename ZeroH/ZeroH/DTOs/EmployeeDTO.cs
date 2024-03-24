using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroH.EF;

namespace ZeroH.DTOs
{
    public class EmployeeDTO
    {
        public int Employee_ID { get; set; }
        public int EmployeeLog_ID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string User_Type { get; set; }
        public string Status { get; set; }

        public virtual LoginLog LoginLog { get; set; }
    }
}