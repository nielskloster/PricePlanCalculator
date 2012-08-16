using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PricePlanCalculator.Helpers
{
	public static class HtmlHelpers
	{
		public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>
			(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
		{
			var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
			var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

			var items =
				values.Select(value => new SelectListItem
				{
					Text = value.ToString(),
					Value = value.ToString(),
					Selected = value.Equals(metadata.Model)
				});

			return htmlHelper.DropDownListFor(
				expression,
				items
				);
		}

		public static string ToReadableString(this TimeSpan span)
		{
			var formatted = String.Format("{0}{1}{2}{3}",
			                              span.Days > 0 ? String.Format("{0:0} days, ", span.Days) : String.Empty,
			                              span.Hours > 0 ? String.Format("{0:0} hours, ", span.Hours) : String.Empty,
			                              span.Minutes > 0 ? String.Format("{0:0} minute(s), ", span.Minutes) : String.Empty,
			                              span.Seconds > 0 ? String.Format("{0:0} second(s)", span.Seconds) : String.Empty);

			if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

			return formatted;
		}
	}
}