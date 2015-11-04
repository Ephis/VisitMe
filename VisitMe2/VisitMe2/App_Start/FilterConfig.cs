using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace VisitMe2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}