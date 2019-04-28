using System.Web.Mvc;

namespace MockServer.Web.Areas.Rules
{
    public class RulesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Rules";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Rules_default",
                "Rules/{controller}/{action}/{id}",
                new { controller = "Pages", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}