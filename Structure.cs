using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySgml
{
	public interface IWrite
	{
		void Write(TextWriter tw);
	}
	
	public interface IFragment : IWrite
	{
		IList<IWrite> Children { get; }
	}

	public interface ITag : IFragment
	{
		string Name { get; }
		IDictionary<string,string> Attributes { get; }
	}
}
