using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasySgml
{
	public static class Sgml
	{
		public static ITag Tag(string tag, params string[] attr)
		{
			Tag n = new Tag(tag);
			if (attr != null) {
				if (attr.Length %2 != 0) {
					throw new ArgumentException("attributes must be provided in pairs");
				}
				for(int a=0; a<attr.Length; a+=2) {
					n.Attributes.Add(attr[a],attr[a+1]);
				}
			}
			return n;
		}

		public static IFragment Pile()
		{
			return new Pile();
		}

		public static IWrite Text(string text)
		{
			return new Text(text);
		}

		public static IWrite Html(string html)
		{
			return new Text(html,true);
		}
	}
}
