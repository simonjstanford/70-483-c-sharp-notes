# Custom Collections

You can create custom collections by inheriting from CollectionBase (non-generic) or Collection<T>.

## Collection <T>

Inherit from this base class to have a fully functioning list. To then extend the code when inserting, removing & setting items or clearing the list, you just need to override the base virtual method:

  
```csharp
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
```
  

## CollectionBase

There is no Add or Remove methods in CollectionBase - these are added as you
see fit.

Also see [Indexers](../Types%20&%20Conversion/Indexers.md)

![Table 9-7](../media/Table9-7.png)
![Table 9-8](../media/Table9-8.png)

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTkyMjUwODk3NCw5ODQyOTI1NjUsMTkwOT
Q0OTA1NiwzOTExNjE3MzhdfQ==
-->