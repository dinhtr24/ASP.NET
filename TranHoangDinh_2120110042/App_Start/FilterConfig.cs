using System.Web;
using System.Web.Mvc;

namespace TranHoangDinh_2120110042
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
