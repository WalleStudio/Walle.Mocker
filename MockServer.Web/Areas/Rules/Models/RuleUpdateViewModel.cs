using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Rules.Models
{
    public class RuleUpdateViewModel:RuleCreateViewModel
    {
        public RuleUpdateViewModel() { 
        
        }
        public long Id { get; set; }
    }
}