# Enums

You can change the type and starting number that an `enum` uses:

```csharp
public enum Days : byte
{
     Sat = 1,
     Sun,
     Mon,
     Tue,
     Wed,
     Thu,
     Fri
}
```

An enum can be changed to use `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`.

## FlagAttribute 

Use `FlagAttribute` to set an object to multiple enum items:

```csharp
[Flags]
public enum MyColors
{
    None = 0,
    Yellow = 1,
    Green = 2,
    Red = 4,
    Blue = 8
}

var str = MyColors.Yellow | MyColors.Green
```

What is happening is that the numbers for each enum item above are powers of 2 and a bitwise `AND` is used to join them together, so:

Yellow: 00000001
Green:  00000010
Red:    00000100
Blue:   00001000

Means that str is '00000011' and so the selected enum items can be inferred. Note than 'None' should always be of value '0' and not used in the bitwise ANDing.

All the [Flags] attribute does is provide an overridden ToString() method - the output of the above without the attribute is '5'.
<!--stackedit_data:
eyJoaXN0b3J5IjpbNDg5MzI0NjE2LC0xMDI0NzE5MDNdfQ==
-->