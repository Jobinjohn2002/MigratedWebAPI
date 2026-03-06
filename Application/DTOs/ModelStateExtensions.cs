using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class ModelStateExentions
    {
        /// <summary>
        /// HasModelError operation
        /// </summary>
        public static bool HasModelError(this ModelStateDictionary modelState, string modelStateKey)
        {
            if (modelState == null)
                throw new ArgumentNullException("modelState");

            return modelState.ContainsKey(modelStateKey) && modelState[modelStateKey].Errors.Count > 0;
        }

        public static bool HasModelError<TModel, TProperty>(this ModelStateDictionary modelState, ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression)
        {
            if (viewData == null)
                throw new ArgumentNullException("viewData");

            return HasModelError(modelState, viewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)));
        }

        /// <summary>
        /// RemoveModelErrors operation
        /// </summary>
        public static void RemoveModelErrors(this ModelStateDictionary modelState, string modelStateKey)
        {
            if (modelState == null)
                return;

            if (modelState.ContainsKey(modelStateKey))
                modelState.Remove(modelStateKey);
        }

        public static void RemoveModelErrors<TModel, TProperty>(this ModelStateDictionary modelState, ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression)
        {
            if (viewData == null)
                return;

            RemoveModelErrors(modelState, viewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)));
        }
    }
}
