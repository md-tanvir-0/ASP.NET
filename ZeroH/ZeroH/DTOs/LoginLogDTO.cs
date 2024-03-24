using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroH.DTOs
{
    public class LoginLogDTO
    {
        public int Log_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }
    }
}