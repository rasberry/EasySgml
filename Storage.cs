using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EasySgml
{
	public class Text : IWrite
	{
		public Text(string text) : this(text,false) {}
		public Text(string text, bool notEncoded)
		{
			_text = text;
			_noEncode = notEncoded;
		}

		private string _text = null;
		private bool _noEncode = false;

		public virtual void Write(System.IO.TextWriter tw)
		{
			if (_text != null) {
				tw.Write(_noEncode ? _text : HttpUtility.HtmlEncode(_text));
			}
		}
	}

	public class Pile : IFragment
	{
		public Pile()
		{
			_children = new List<IWrite>();
		}

		public Pile(IEnumerable<IWrite> list)
		{
			_children = new List<IWrite>(list);
		}

		public virtual void Write(System.IO.TextWriter tw)
		{
			if (_children != null) {
				foreach(IWrite child  in Children) {
					if (child != null) {
						child.Write(tw); 
					}
				}
			}
		}

		private List<IWrite> _children;
		public IList<IWrite> Children { get { return _children; }}
	}

	public class Tag : Pile, ITag
	{
		public Tag(string tag) : base()
		{
			Name = tag;
			_attr = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);
		}

		public override void Write(System.IO.TextWriter tw)
		{
			tw.Write("<");
			tw.Write(HttpUtility.HtmlEncode(Name??""));
			WriteAttr(tw);
			tw.Write(">");
			base.Write(tw); //children
			tw.Write("</");
			tw.Write(HttpUtility.HtmlEncode(Name??""));
			tw.Write(">");
		}

		private void WriteAttr(System.IO.TextWriter tw)
		{
			if (_attr != null) {
				foreach(var kvp in _attr) {
					if (String.IsNullOrEmpty(kvp.Key)) { continue; }
					tw.Write(' ');
					tw.Write(HttpUtility.HtmlEncode(kvp.Key));
					if (!String.IsNullOrEmpty(kvp.Value)) {
						tw.Write("=\"");
						tw.Write(HttpUtility.HtmlEncode(kvp.Value));
						tw.Write('"');
					}
				}
			}
		}

		public string Name { get; private set; }
		private Dictionary<string,string> _attr;
		public IDictionary<string, string> Attributes { get { return _attr; }}
	}
}
