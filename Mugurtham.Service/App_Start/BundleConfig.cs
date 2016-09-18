using System.Web;
using System.Web.Optimization;

namespace Mugurtham.Service
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*===============================================================================================*/
            /*MUGURTHAM SCRIPT BUNDLE STARTS*/
            /*===============================================================================================*/
            bundles.Add(new ScriptBundle("~/bundles/MugurthamJQuery").Include(
                      "~/Scripts/Mugurtham.JS/JQuery/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamBootstrap").Include(
                      "~/Scripts/Mugurtham.JS/bootstrap/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamToastr").Include(
                     "~/Scripts/Mugurtham.JS/toastr/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamAngularJS").Include(
                     "~/Scripts/Mugurtham.JS/AngularJS/angular.min.js",
                     "~/Scripts/Mugurtham.JS/AngularJS/angular-route.min.js",
                     "~/Scripts/Mugurtham.JS/AngularJS/angular-translate.min.js"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamJqplot").Include(
                     "~/Scripts/Mugurtham.JS/Jqplot/jquery.jqplot.min.js",
                     "~/Scripts/Mugurtham.JS/Jqplot/jqplot.pieRenderer.min.js",
                      "~/Scripts/Mugurtham.JS/Jqplot/jqplot.barRenderer.JS",
                      "~/Scripts/Mugurtham.JS/Jqplot/jqplot.categoryAxisRenderer.js",
                      "~/Scripts/Mugurtham.JS/Jqplot/jqplot.pointLabels.js"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamFlexSlider").Include(
                       "~/Scripts/Mugurtham.JS/FlexSlider/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamLightbox").Include(
                       "~/Scripts/Mugurtham.JS/Lightbox/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamPaging").Include(
                       "~/Scripts/Mugurtham.JS/Paging/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamSlider").Include(
                 "~/Scripts/Mugurtham.JS/Slider/jssor.slider.mini.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamApp").Include(
                    "~/Scripts/Mugurtham.JS/Mugurtham/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerBase").Include(
                   "~/Scripts/Mugurtham.js/Mugurtham/Controllers/ControllerMugurtham.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamDashboard").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/Dashboard/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerProfile").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/Profile/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerSearch").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/Search/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerUserChamber").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/UserChamber/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerFullView").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/View/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamControllerMugurthamAdmin").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Controllers/MugurthamAdmin/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/MugurthamValidation").Include(
                   "~/Scripts/Mugurtham.JS/Mugurtham/Utility/*.js"));


            /*===============================================================================================*/
            /*MUGURTHAM STYLE BUNDLE STARTS*/
            /*===============================================================================================*/
            bundles.Add(new StyleBundle("~/Content/MugurthamBootstrap").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Bootstrap/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/MugurthamJQueryUI").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Jquery/jquery-ui.css"));
            bundles.Add(new StyleBundle("~/Content/MugurthamToastr").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Toastr/toastr.min.css"));
            bundles.Add(new StyleBundle("~/Content/MugurthamBase").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/mugurtham.css"));
            bundles.Add(new StyleBundle("~/Content/MugurthamMask").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Mask/jquery.loadmask.css"));
            bundles.Add(new StyleBundle("~/Content/MugurthamJqplot").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Jqplot/jquery.jqplot.min.css"));
            bundles.Add(new StyleBundle("~/Content/Flexslider").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Flexslider/Flexslider.css"));
            bundles.Add(new StyleBundle("~/Content/Lightbox").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/Lightbox/*.css"));
            //bundles.Add(new StyleBundle("~/Content/font-awesome").Include("~/App_Themes/MugurthamTheme/css/Mugurtham/font-awesome/*.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}