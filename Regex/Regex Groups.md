# Regex Groups

You can refer to a regex group from within the expression. This expression matches any single word character and then refers back to the group number (1). This means that it will match the same word character repeater twice, i.e. aa, bb, cc, etc. 

```csharp
(\w)\1
```

The same can be done with named groups:

```csharp
(?<twice>\w)\k<twice>
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTExODQwNDc5MzZdfQ==
-->