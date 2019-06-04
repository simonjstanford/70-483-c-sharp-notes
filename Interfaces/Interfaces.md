# Interfaces
Explicit interface implementation is achieved through using a method signature that includes the interface name: public void InterfaceA.DoStuf(). This means that the object must be cast to the interface before the method can be called. It is used to hide class members or when a class implements two interfaces where one or more methods have the same name.

Members defined in an interface are always public. If an interface defines a property with just a getter it is possible to implement that property with a getter and setter - the setter will be visible though a reference to the implementation. Interfaces can inherit from other interfaces.

Generics can be used.
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEyNzE0OTAyNjVdfQ==
-->