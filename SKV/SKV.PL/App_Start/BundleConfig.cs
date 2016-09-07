using System.Web;
using System.Web.Optimization;

namespace SKV.PL
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.UseCdn = true;          

            //bundles.Add(new ScriptBundle("~/script_bundles/jquery", "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.3.min.js")
            //       .Include("~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/script_budles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js"
                ));

            //bundles.Add(new StyleBundle("~/style_bundle/font-awesome", "https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css")
            //       .Include("~/Content/Styles/font-awesome.css"));
            

            bundles.Add(new StyleBundle("~/style_bundles/style-responsive").Include(
                "~/Content/Admin/assets/css/style.css",
                "~/Content/Admin/assets/css/style-responsive.css"));

            bundles.Add(new StyleBundle("~/style_bundles/base_css").Include(
                 "~/Content/Admin/assets/libs/jqueryui/ui-lightness/jquery-ui-1.10.4.custom.min.css",
                 "~/Content/Admin/assets/libs/bootstrap/css/bootstrap.min.css",
                 "~/Content/Admin/assets/libs/font-awesome/css/font-awesome.min.css",
                 "~/Content/Admin/assets/libs/fontello/css/fontello.css",
                 "~/Content/Admin/assets/libs/animate-css/animate.min.css",
                 "~/Content/Admin/assets/libs/nifty-modal/css/component.css",
                 "~/Content/Admin/assets/libs/magnific-popup/magnific-popup.css",
                 "~/Content/Admin/assets/libs/ios7-switch/ios7-switch.css",
                 "~/Content/Admin/assets/libs/pace/pace.css",
                 "~/Content/Admin/assets/libs/sortable/sortable-theme-bootstrap.css",
                 "~/Content/Admin/assets/libs/bootstrap-datepicker/css/datepicker.css",
                 "~/Content/Admin/assets/libs/jquery-icheck/skins/all.css"));
























            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));













            bundles.Add(new StyleBundle("~/Content/ExtraCSSLibraries").Include(
                "~/Content/Admin/assets/libs/rickshaw/rickshaw.min.css",
                "~/Content/Admin/assets/libs/morrischart/morris.css",
                "~/Content/Admin/assets/libs/jquery-jvectormap/css/jquery-jvectormap-1.2.2.css",
                "~/Content/Admin/assets/libs/jquery-clock/clock.css",
                "~/Content/Admin/assets/libs/bootstrap-calendar/css/bic_calendar.css",
                "~/Content/Admin/assets/libs/sortable/sortable-theme-bootstrap.css",
                "~/Content/Admin/assets/libs/jquery-weather/simpleweather.css",
                "~/Content/Admin/assets/libs/bootstrap-xeditable/css/bootstrap-editable.css",
                "~/Content/Admin/assets/css/style.css",
                "~/Content/Admin/assets/css/style-responsive.css"));

            

            bundles.Add(new ScriptBundle("~/Content/JQueryLibs").Include(
                "~/Content/Admin/assets/libs/jquery/jquery-1.11.1.min.js",
                "~/Content/Admin/assets/libs/bootstrap/js/bootstrap.min.js",
                "~/Content/Admin/assets/libs/jqueryui/jquery-ui-1.10.4.custom.min.js",
                "~/Content/Admin/assets/libs/jquery-ui-touch/jquery.ui.touch-punch.min.js",
                "~/Content/Admin/assets/libs/jquery-detectmobile/detect.js",
                "~/Content/Admin/assets/libs/jquery-animate-numbers/jquery.animateNumbers.js",
                "~/Content/Admin/assets/libs/ios7-switch/ios7.switch.js",
                "~/Content/Admin/assets/libs/fastclick/fastclick.js",
                "~/Content/Admin/assets/libs/jquery-blockui/jquery.blockUI.js",
                "~/Content/Admin/assets/libs/bootstrap-bootbox/bootbox.min.js",
                "~/Content/Admin/assets/libs/jquery-slimscroll/jquery.slimscroll.js",
                "~/Content/Admin/assets/libs/jquery-sparkline/jquery-sparkline.js",
                "~/Content/Admin/assets/libs/nifty-modal/js/classie.js",
                "~/Content/Admin/assets/libs/nifty-modal/js/modalEffects.js",
                "~/Content/Admin/assets/libs/sortable/sortable.min.js",
                "~/Content/Admin/assets/libs/bootstrap-fileinput/bootstrap.file-input.js",
                "~/Content/Admin/assets/libs/bootstrap-select/bootstrap-select.min.js",
                "~/Content/Admin/assets/libs/bootstrap-select2/select2.min.js",
                "~/Content/Admin/assets/libs/magnific-popup/jquery.magnific-popup.min.js",
                "~/Content/Admin/assets/libs/pace/pace.min.js",
                "~/Content/Admin/assets/libs/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Content/Admin/assets/libs/jquery-icheck/icheck.min.js"));

            bundles.Add(new ScriptBundle("~/Content/PageSpecificJSLibs").Include(
                "~/Content/Admin/assets/js/init.js",
                "~/Content/Admin/assets/libs/d3/d3.v3.js",
                "~/Content/Admin/assets/libs/rickshaw/rickshaw.min.js",
                "~/Content/Admin/assets/libs/raphael/raphael-min.js",
                "~/Content/Admin/assets/libs/morrischart/morris.min.js",
                "~/Content/Admin/assets/libs/jquery-knob/jquery.knob.js",
                "~/Content/Admin/assets/libs/jquery-jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                "~/Content/Admin/assets/libs/jquery-jvectormap/js/jquery-jvectormap-us-aea-en.js",
                "~/Content/Admin/assets/libs/jquery-clock/clock.js",
                "~/Content/Admin/assets/libs/jquery-easypiechart/jquery.easypiechart.min.js",
                "~/Content/Admin/assets/libs/jquery-weather/jquery.simpleWeather-2.6.min.js",
                "~/Content/Admin/assets/libs/bootstrap-xeditable/js/bootstrap-editable.min.js",
                "~/Content/Admin/assets/libs/bootstrap-calendar/js/bic_calendar.min.js",
                "~/Content/Admin/assets/js/apps/calculator.js",
                "~/Content/Admin/assets/js/apps/todo.js",
                "~/Content/Admin/assets/js/apps/notes.js",
                "~/Content/Admin/assets/js/pages/index.js"));
        }
    }
}
