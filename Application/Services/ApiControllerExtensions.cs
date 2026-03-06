using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ApiControllerExtensions
    {
        public static MvcHtmlString RenderPartialViewToString<TModel>(this ApiController controller, string viewName, TModel model)
        {
            using (var writer = new StringWriter())
            {
                var context = controller.Request.Properties["MS_HttpContext"] as HttpContextWrapper;
                var routeData = new RouteData();
                routeData.Values.Add("controller", "empty");
                var tempControllerContext = new ControllerContext(context, routeData, new EmptyController());

                var viewResult = ViewEngines.Engines.FindPartialView(tempControllerContext, viewName);
                var viewContext = new ViewContext(tempControllerContext, viewResult.View, new ViewDataDictionary(model), new TempDataDictionary(), writer);
                viewResult.View.Render(viewContext, writer);

                return new MvcHtmlString(writer.GetStringBuilder().ToString());
            }
        }
    }

    /// <summary>
    /// EmptyController
    /// </summary>
    public class EmptyController : Controller // required to render views
    {

    }
}