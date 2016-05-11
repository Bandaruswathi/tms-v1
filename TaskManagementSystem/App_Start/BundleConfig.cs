using System.Web;
using System.Web.Optimization;

namespace TaskManagementSystem
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

            bundles.Add(new ScriptBundle("~/bundles/software-js").Include(
                       "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/wijmo/controls/wijmo.min.js",
                        "~/wijmo/controls/wijmo.input.min.js",
                        "~/wijmo/controls/wijmo.grid.min.js",
                        "~/wijmo/controls/wijmo.chart.min.js",
                        "~/Scripts/toastr.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/jquery.stellar.js",
                      "~/Scripts/jquery.appear.js",
                      "~/Scripts/jquery.nicescroll.min.js",
                      "~/Scripts/jquery.countTo.js",
                      "~/Scripts/jquery.shuffle.modernizr.js",
                      "~/Scripts/jquery.shuffle.js",
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/jquery.ajaxchimp.min.js",
                      "~/Scripts/script.js",
                     "~/Scripts/toastr.min.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/font-awesome-4.6.1/css/font-awesome.min.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.css",
                      "~/Content/owl.transitions.css",
                      "~/wijmo/styles/wijmo.min.css",
                      "~/Content/toastr.min.css"));

        }
    }
}
