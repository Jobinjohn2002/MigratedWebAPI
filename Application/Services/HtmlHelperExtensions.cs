using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// RenderGettingStarted operation
        /// </summary>
        public static void RenderGettingStarted(this HtmlHelper helper, GettingStartedModel model)
        {
            helper.RenderPartial("_GettingStarted", model);
        }

        /// <summary>
        /// RenderGettingStartedFTL operation
        /// </summary>
        public static void RenderGettingStartedFTL(this HtmlHelper helper, GettingStartedModel model)
        {
            helper.RenderPartial("_GettingStartedFTL", model);
        }

        /// <summary>
        /// RenderGettingStartedLK operation
        /// </summary>
        public static void RenderGettingStartedLK(this HtmlHelper helper, GettingStartedModel model)
        {
            helper.RenderPartial("_GettingStartedLK", model);
        }

        /// <summary>
        /// RenderFloatingBanner operation
        /// </summary>
        public static void RenderFloatingBanner(this HtmlHelper helper, string text)
        {
            helper.RenderPartial("_FloatingBanner", text);
        }

        /// <summary>
        /// RenderGettingStarted operation
        /// </summary>
        public static void RenderGettingStarted(this HtmlHelper helper, string templateName, GettingStartedModel model)
        {
            helper.RenderPartial(templateName, model);
        }

        /// <summary>
        /// CustomValidationSummary operation
        /// </summary>
        public static void CustomValidationSummary(this HtmlHelper helper, string partialView = null)
        {
            if (partialView == null)
                partialView = "_ValidationSummary";

            helper.RenderPartial(partialView, helper.ViewDataContainer.ViewData.ModelState);
        }

        /// <summary>
        /// BeginWizard operation
        /// </summary>
        public static MvcWizard BeginWizard(this HtmlHelper htmlHelper, object htmlAttributes = null, bool enabled = true)
        {
            return new MvcWizard(htmlHelper, enabled, htmlAttributes);
        }

        public static MvcHtmlString HiddenDate<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return RenderHiddenDateTime<TModel, TProperty>(helper, expression, false, htmlAttributes);
        }

        public static MvcHtmlString HiddenDateTime<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return RenderHiddenDateTime<TModel, TProperty>(helper, expression, true, htmlAttributes);
        }

        private static MvcHtmlString RenderHiddenDateTime<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, bool includeTime, object htmlAttributes = null)
        {
            var tag = new TagBuilder("input");

            var model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;

            if (model != null && !(model is DateTime) && !(model is DateTime?))
                throw new InvalidCastException("Cannot convert ({0}) to (DateTime?)".FormatWith(model.GetType().Name));

            DateTime? dateTime = (model == null ? null : (DateTime?)model);

            var id = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
            var name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            var value = includeTime ? dateTime.ToLocalShortDateTime() : dateTime.ToLocalShortDate();

            tag.MergeAttribute("type", "hidden");
            tag.MergeAttribute("value", value);
            tag.MergeAttribute("id", id);
            tag.MergeAttribute("name", name);

            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString RenderHtmlAttributes<TModel>(this HtmlHelper<TModel> htmlHelper, object htmlAttributes)
        {
            var attrbituesDictionary = new System.Web.Routing.RouteValueDictionary(htmlAttributes);

            return MvcHtmlString.Create(String.Join(" ", attrbituesDictionary.Select(item => String.Format("{0}=\"{1}\"", item.Key.Replace('_', '-'), htmlHelper.Encode(item.Value)))));
        }

        /// <summary>
        /// HmacGenerator operation
        /// </summary>
        public static string HmacGenerator(string[] parameters, TimeSpan validity)
        {
            string stringToEncrypt = String.Join("_", parameters.Where(x => !String.IsNullOrEmpty(x)));
            return HmacWrapper.Encode(stringToEncrypt, validity);
        }
    }
}