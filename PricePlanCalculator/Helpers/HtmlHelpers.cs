using System;
using System.Collections.Generic;
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

		public static string ToPrettyCamelcase(this string value)
		{
			return new string(CharToPrettyCamelcase(value).ToArray());
		}

		private static IEnumerable<char> CharToPrettyCamelcase(IEnumerable<char> value)
		{
			if (!value.Any())
				yield break;
			char last = ' ';
			foreach (var character in value)
			{
				if (char.IsUpper(character) && last != ' ' && !char.IsUpper(last))
				{
					yield return ' ';
				}
				yield return character;
				last = character;
			}
		}

	}
}