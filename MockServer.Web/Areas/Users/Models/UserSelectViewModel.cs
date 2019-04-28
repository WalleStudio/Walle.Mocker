using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Users.Models
{
    public class UserSelectViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string WorkId { get; set; } = string.Empty;
    }
}