using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Rules.Models
{
    public class RuleListViewModel
    {
        public RuleListViewModel()
        {

        }
        public List<RuleDetailViewModel> RuleList { get; set; } = new List<RuleDetailViewModel>();

        public long Index { get; set; } = 0;

        public long Total { get; set; } = 0;

        public long Size { get; set; } = 0;
        public long ProjectId { get; set; }
    }
}