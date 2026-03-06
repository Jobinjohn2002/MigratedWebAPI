using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddModelError<TModel, TProperty>(this ModelStateDictionary modelState, ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression, Exception exception)
        {
            if (modelState == null)
                throw new ArgumentNullException("modelState");

            if (viewData == null)
                throw new ArgumentNullException("viewData");

            modelState.AddModelError(viewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)), exception);
        }

        public static void AddModelError<TModel, TProperty>(this ModelStateDictionary modelState, ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression, string error)
        {
            if (modelState == null)
                throw new ArgumentNullException("modelState");

            if (viewData == null)
                throw new ArgumentNullException("viewData");

            modelState.AddModelError(viewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)), error);
        }
    }
}
