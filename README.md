# EasySgml
A way to write html in code without using a template language

## Examples

Create a simple page
```csharp
public class SimpleView : IView
{
	public void Render(TextWriter writer)
	{
		writer.Write("<!DOCTYPE html>");
		var html =
		Sgml.Tag("html").Add(
			Sgml.Tag("head").Add(
				Sgml.Tag("title").AddText("Test Page")
			),
			Sgml.Tag("body").Add(
				Sgml.Tag("div").AddText("Hello World!!")
			)
		);
		html.Write(writer);
	}
}
```

Create a tag with attributes
```csharp
var tag = Sgml.Tag("tag","attr1","value1","attr2","value2");
```
Create a fragment
```csharp
var pil = Sgml.Pile().Add(...);
```
Create some html encoded text
```csharp
var txt = Sgml.Text("Some Text");
```
Create some raw html text
```csharp
var htm = Sgml.Html("<span>Some Html</span>");
```
