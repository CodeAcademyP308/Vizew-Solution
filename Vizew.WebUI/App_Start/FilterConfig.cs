using NLog;
using System.Web;
using System.Web.Mvc;

namespace Vizew.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new VizewExceptionFilterAttribute(LogManager.GetCurrentClassLogger()));
        }
    }
}
