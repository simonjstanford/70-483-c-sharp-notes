# Custom Collections

You can create custom collections by inheriting from CollectionBase (non-
generic) or Collection<T>.

  

 **Collection <T>**

Inherit from this base class to have a fully functioning list. To then extend
the code when inserting, removing & setting items or clearing the list, you
just need to override the base virtual method:

  

public class Animal  
{  
  public string Name;  
  public int Popularity;  
  public Zoo Zoo { get; internal set; }  
  
  public Animal(string name, int popularity)  
  {  
    Name = name; Popularity = popularity;  
  }  
}  
  
public class AnimalCollection : Collection <Animal>  
{  
  Zoo zoo;  
  public AnimalCollection (Zoo zoo) { this.zoo = zoo; }  
  
  protected override void InsertItem (int index, Animal item)  
  {  
    base.InsertItem (index, item);  
    item.Zoo = zoo;  
  }  
  protected override void SetItem (int index, Animal item)  
  {  
    base.SetItem (index, item);  
    item.Zoo = zoo;  
  }  
  protected override void RemoveItem (int index)  
  {  
    this [index].Zoo = null;  
    base.RemoveItem (index);  
  }  
  protected override void ClearItems()  
  {  
    foreach (Animal a in this) a.Zoo = null;  
    base.ClearItems();  
  }  
}  
  
public class Zoo  
{  
  public readonly AnimalCollection Animals;  
  public Zoo() { Animals = new AnimalCollection (this); }  
}  
  

  

  

 **CollectionBase**

  

There is no Add or Remove methods in CollectionBase - these are added as you
see fit.

  

Also see
[Indexers](evernote:///view/26944639/s226/9118c81d-84e2-436a-bb66-58c0c8cfaa0d/9118c81d-84e2-436a-bb66-58c0c8cfaa0d/).

  

![noteattachment1][1f726bb72374c817c7a6eedf618b46cc]

  

![noteattachment2][b39bbda2f24eb0f7da0f2b0b69c149bf]


---
### ATTACHMENTS
[1f726bb72374c817c7a6eedf618b46cc]: media/Custom_Collections.png
[Custom_Collections.png](media/Custom_Collections.png)
[b39bbda2f24eb0f7da0f2b0b69c149bf]: media/Custom_Collections-2.png
[Custom_Collections-2.png](media/Custom_Collections-2.png)
---
### NOTE ATTRIBUTES
>Created Date: 2017-01-03 19:51:51  
>Last Evernote Update Date: 2017-01-10 20:21:16  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: file:///C:/Users/simon/AppData/Local/Temp/Temp1_code.zip/ch07.html  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTAxNzI3OTcyNl19
-->