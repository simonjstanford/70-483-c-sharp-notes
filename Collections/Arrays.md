# Arrays

  * Arrays inherit from `System.Array`.
  * The `Rank` property returns the number of dimensions in an array. 
  * You can create up to 2,147,483,647 dimensions.
  * `Clone()` makes a shallow copy of an array (keeps the references to the same objects) and returns a new array.
  * `CopyTo()` also performs a shallow copy, but copies the elements of an array to an existing array.

Multi-dimensional arrays:

```
int[,] mySet = new int[3, 2];
mySet[0, 0] = 1;
mySet[0, 1] = 2;
mySet[1, 0] = 3;
mySet[1, 1] = 4;
mySet[2, 0] = 5;
mySet[2, 1] = 6;
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTU2MDI2MTI0NSw3MzkzMTgyMzFdfQ==
-->