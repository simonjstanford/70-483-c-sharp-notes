# Copy & Paste

Note that binary serialization occurs - this means that private fields are serialized by default.

```csharp
public partial class MainWindow : Window
{
   public MainWindow()
   {
      InitializeComponent();
      var list = new List<Test> {new Test {Name = "1"}, new Test {Name = "2"}};
      var data = new DataObject();
      data.SetData("Test", list);
      Clipboard.SetDataObject(data, false); //do not persist after application exits
      var clipBoardObject = Clipboard.GetData("Test") as List<Test>;
   }
}

[Serializable]
public class Test
{
   public string Name { get; set; }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTYyNTc5NDgwNF19
-->