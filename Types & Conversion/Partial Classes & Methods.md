# Partial Classes & Methods

## Partial Classes

- All partial-type definitions meant to be parts of the same type must be modified with partial.
- The partial modifier can only appear immediately before the keywords class, struct, or interface.
- Nested partial types are allowed in partial-type definitions.
- All partial-type definitions meant to be parts of the same type must be defined in the same assembly and the same module (.exe or .dll file). Partial definitions cannot span multiple modules.
- The class name and generic-type parameters must match on all partial-type definitions. Generic types can be partial. Each partial declaration must use the same parameter names in the same order.
- The following keywords on a partial-type definition are optional, but if present on one partial-type definition, cannot conflict with the keywords specified on another partial definition for the same type: public, private, protected, internal, abstract, sealed, base class, new modifier (nested parts), generic constraints

## Partial Methods

- Partial method declarations must begin with the contextual keyword partial and the method must return void.
- Partial methods can have ref but not out parameters.
- Partial methods are implicitly private, and therefore they cannot be virtual.
- Partial methods cannot be extern, because the presence of the body determines whether they are defining or implementing.
- Partial methods can have static and unsafe modifiers.
- Partial methods can be generic. Constraints are put on the defining partial method declaration, and may optionally be repeated on the implementing one. Parameter and type parameter names do not have to be the same in the implementing declaration as in the defining one.
- You can make a delegate to a partial method that has been defined and implemented, but not to a partial method that has only been defined.

https://msdn.microsoft.com/en-us/library/wa80x488.aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTg3ODYwNjIzOCw0OTc4MTg4MTBdfQ==
-->