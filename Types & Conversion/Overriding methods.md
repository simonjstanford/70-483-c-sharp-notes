# Overriding methods

Mark a method as virtual in the base class then override in the derived class. Use `base.MyMethod()` to call the base class method.  

If the base class does not use the virtual keyword then you can use `new` in the derived class to hide the base class implementation. The difference between using `new` instead of `override` is that a method in a derived class that overrides a virtual method in a base class will always be called, even if the reference to the derived class is a base type reference. On the other hand, a method in a derived class that hides a method in a base class with `new` will only get executed if the reference to the object is of the derived type.

For example, in the example below class `Derived` is a subclass of `Base`. The `Base.Execute()` method gets called both times - `Derived.Execute()` is not called at all because the reference is of type Base:

```csharp
Base b = new Base();
b.Execute();
b = new Derived()
b.Execute();
```

Disable inheritance on a class/method with the sealed keyword - this stops a class being inherited or a method being overridden.

https://msdn.microsoft.com/en-us/library/ms173153.aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTY2MjgyNjE1NCwtMTUxODcyMzc0Ml19
-->