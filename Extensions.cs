using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasySgml
{
	public static class Extensions
	{
		public static IFragment Add(this IFragment self, params IWrite[] list)
		{
			foreach(IWrite item in list) {
				self.Children.Add(item);
			}
			return self;
		}

		public static IFragment AddText(this IFragment self, string text)
		{
			self.Add(new Text(text));
			return self;
		}

		public static IFragment AddHtml(this IFragment self, string html)
		{
			self.Add(new Text(html,true));
			return self;
		}
	}
}
