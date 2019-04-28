using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Projects.Models
{
    public class ProjectAddViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
    }
}