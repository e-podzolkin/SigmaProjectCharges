using SigmaProjectCharges.Filters;

using System.Web;
using System.Web.Mvc;

namespace SigmaProjectCharges
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}