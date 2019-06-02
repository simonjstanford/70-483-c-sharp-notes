# Indexers

Use indexer properties to allow a class to be accessed like an array:

  

public Card this[int index]

{

     get { return Cards.ElementAt(index); }

     set {Cards[index] = value; }

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-04 11:14:28  
>Last Evernote Update Date: 2016-12-14 20:17:39  
>author: simonjstanford@gmail.com  