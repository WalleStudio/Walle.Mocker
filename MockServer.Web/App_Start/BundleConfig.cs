using System.Web;
using System.Web.Optimization;

namespace MockServer.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jq").Include(
                "~/Content/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/Scripts/jquery-migrate.min.js",
                //IMPORTANT!Load jquery - ui.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip
                "~/Content/Plugins/jquery-ui/jquery-ui.min.js",
                "~/Content/Plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/Plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/Content/Plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/Scripts/jquery.blockui.min.js",
                "~/Content/Scripts/jquery.cokie.min.js",
                "~/Content/Plugins/uniform/jquery.uniform.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jin").Include(
                "~/Content/Scripts/metronic.js",
                "~/Content/Scripts/layout.js",
                "~/Content/Scripts/demo.js",
                "~/Scripts/menu.js",
                "~/Scripts/user.js",
				"~/Content/Scripts/MyMessager.js",
                "~/Content/Scripts/init.js"
                ));

        
            bundles.Add(new ScriptBundle("~/bundles/vue", "http://cdn.bootcss.com/vue/2.2.4/vue.min.js").Include(
                "~/Content/Scripts/vue.js"
                ));

            //element ui
            var elememtVueUiScriptCdnPath = @"http://cdn.bootcss.com/element-ui/1.2.5/index.js";
            var elementVueUiStyleCdnPath = @"http://cdn.bootcss.com/element-ui/1.2.5/theme-default/index.css";
            bundles.Add(new ScriptBundle("~/bundles/element", elememtVueUiScriptCdnPath));
            bundles.Add(new StyleBundle("~/Content/element", elementVueUiStyleCdnPath));

            //json editor
            bundles.Add(new ScriptBundle("~/bundles/json").Include(
                "~/Content/Plugins/JsonEditor/jsoneditor.js"
            ));
            bundles.Add(new StyleBundle("~/Content/json").Include(
                "~/Content/Plugins/JsonEditor/jsoneditor.css"
            ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/Plugins/font-awesome/css/font-awesome.min.css",
                 "~/Content/Plugins/simple-line-icons/simple-line-icons.min.css",
                 "~/Content/Plugins/bootstrap/css/bootstrap.min.css",
                 "~/Content/Plugins/uniform/css/uniform.default.css",
                 "~/Content/Themes/components-rounded.css",
                 "~/Content/Themes/plugins.css",
                 "~/Content/Themes/css/layout.css",
                 "~/Content/Themes/loader.css",
                 "~/Content/Themes/css/color/default.css",
                 "~/Content/Themes/css/custom.css"));
        }
    }
}
