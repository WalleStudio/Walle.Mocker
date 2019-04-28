using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Rules.Models
{
    public class RuleDetailViewModel : RuleCreateViewModel
    {
        public RuleDetailViewModel()
        {

        }

        public long Id { get; set; }

        public bool IsActive { get; set; } = true;
    }
}