using System.Web;
using System.Web.Mvc;

namespace HTTP5101B_Assignment2_SandraKupfer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
