# Indexers

Use indexer properties to allow a class to be accessed like an array:

```csharp
public Card this[int index]
{
     get { return Cards.ElementAt(index); }
     set {Cards[index] = value; }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTEyNzk5MTIwOCw4MjE4NzE2ODldfQ==
-->