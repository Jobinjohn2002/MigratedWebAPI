using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IControllerExtensions
    {
        public static MvcHtmlString RenderViewToString<TModel>(this Controller controller, string viewName, TModel model)
        {
            return controller.RenderViewToString(viewName, false, model);
        }

        public static MvcHtmlString RenderPartialViewToString<TModel>(this Controller controller, string viewName, TModel model)
        {
            return controller.RenderViewToString(viewName, true, model);
        }

        public static MvcHtmlString RenderViewToString<TModel>(this Controller controller, string viewName, bool isPartial, TModel model)
        {
            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                var viewResult = isPartial ? ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName) : ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);

                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);

                viewResult.View.Render(viewContext, writer);

                return new MvcHtmlString(writer.GetStringBuilder().ToString());
            }
        }
    }
}
