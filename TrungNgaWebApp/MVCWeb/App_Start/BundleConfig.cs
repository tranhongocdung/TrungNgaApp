using System.Web.Optimization;

namespace MVCWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bookindex-js").Include(
                "~/Content/datepicker/js/bootstrap-datepicker.js",
                "~/Content/datepicker/js/bootstrap-datepicker.vi.js",
                "~/Content/typeahead/typeahead.bundle.js",
                "~/Scripts/views/book-index.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/bookindex-css").Include(
                      "~/Content/datepicker/css/bootstrap-datepicker.min.css",
                      "~/Content/typeahead/typeahead-bootstrap.css"
                      ));
            BundleTable.EnableOptimizations = true;
            
        }
    }
}
