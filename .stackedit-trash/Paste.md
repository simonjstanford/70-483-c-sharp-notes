#  Paste

Note that binary serialization occurs - this means that private fields are
serialized by default.

  

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

  


---
### NOTE ATTRIBUTES
>Created Date: 2018-05-04 10:28:31  
>Last Evernote Update Date: 2018-05-04 10:29:13  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTMwODg5NjIwXX0=
-->