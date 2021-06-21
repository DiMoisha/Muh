using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;

namespace Muhin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/bootstrap.css"));


            bundles.Add(new StyleBundle("~/content/maincss").Include(
                      "~/Content/site.css"));


            //bundles.Add(new ScriptBundle("~/bundles/main").Include(
            //         "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/content/datepicker").Include(
                        "~/Content/datepicker.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/datepicker.min.js"));

            //bundles.Add(new StyleBundle("~/content/fa").Include(
            //        "~/Content/fontawesome.css",
            //        "~/Content/brands.css",
            //         "~/Content/solid.css"));

            //var nullBulider = new NullBuilder();
            //var nullOrderer = new NullOrderer();

            //BundleResolver.Current = new CustomBundleResolver();
            //var commonStyleBundle = new CustomStyleBundle("~/content/maincss");

            //commonStyleBundle.Include("~/Content/site.scss");
            //commonStyleBundle.Orderer = nullOrderer;
            //bundles.Add(commonStyleBundle);
        }
    }
}
