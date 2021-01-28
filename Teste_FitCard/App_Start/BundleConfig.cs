using System.Web;
using System.Web.Optimization;

namespace Teste_FitCard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));


            var scriptBundle = new ScriptBundle("~/Scripts/bundle");
            var styleBundle = new StyleBundle("~/Content/bundle");


            // jQuery
            scriptBundle
                .Include("~/Scripts/jquery-3.5.1.js");

            //jQuery Mask
            scriptBundle
                 .Include("~/Scripts/jquery.mask.js");


            //jQuery Mask
            scriptBundle
                 .Include("~/Scripts/Helpers.js");

            //jQuery Validade
            scriptBundle
                 .Include("~/Scripts/jquery.validate.js");

            // Bootstrap
            scriptBundle
                .Include("~/Scripts/bootstrap.js");

            // Bootstrap
            styleBundle
                .Include("~/Content/bootstrap.css");

            // Custom site styles
            styleBundle
                .Include("~/Content/Site.css");

            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);


            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));


            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
