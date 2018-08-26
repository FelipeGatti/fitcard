using System.Web;
using System.Web.Optimization;

namespace EstabelecimentosCategorias
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lab.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/fitcard.css"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            "~/Scripts/Inputmask/inputmask.js",
            "~/Scripts/Inputmask/jquery.inputmask.js",
            "~/Scripts/Inputmask/inputmask.extensions.js",
            "~/Scripts/Inputmask/inputmask.date.extensions.js",
            "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));

            bundles.Add(new ScriptBundle("~/datatables/js").Include(
            "~/Scripts/DataTables/jquery.dataTables.min.js",
            "~/Scripts/DataTables/datatable-traducao.js"));

            bundles.Add(new StyleBundle("~/datatables/css").Include(
                "~/Content/DataTables/css/jquery.dataTables.min.css",
                "~/Content/DataTables/css/custom.css"
                ));

        }
    }
}
