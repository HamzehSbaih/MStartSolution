using MStart.Attributes;
using System.Web;
using System.Web.Mvc;

namespace MStart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleException());
            filters.Add(new LocalizationAttribute());
        }
    }
}
