# The Stack & The Heap

- The stack is cleared after each method execution.
- The heap is managed by the garbage collector:
	- 'Mark and compact' marks all items still referenced by a root item (static field, method parameter, local variable, CPU register) & moves them closer together. The memory is freed for all other objects. Threads are frozen whilst this happens.
	- Mark and compact can have a performance implication so it only happens when there isn't enough memory to construct a new object.
	- Garbage collector focuses on 'Generation 0' objects. Items that survive clean up are promoted to a higher generation. The assumption is made that they will be used later so will only be checked when the garbage collector can't free enough memory through 'Generation 0' items.


<!--stackedit_data:
eyJoaXN0b3J5IjpbMTIxNjM1MTI4NV19
-->