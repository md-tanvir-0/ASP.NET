using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabPerfom.DTO
{
    public class ProjectDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string deadline { get; set; }
        public string status { get; set; }
        public int PCId { get; set; }
        public int AId { get; set; }

    }
}