using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroAPI.EF.Tables
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }

    }
}