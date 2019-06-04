# Custom Exceptions

* Custom exceptions are derived from `Exception`.
* Custom exceptions require a parameterless constructor. It's best practice to also add one with a string, another with a string & exception, and one for serialisation (e.g. for a web service).
* Never inherit from `System.ApplicationException`.
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTcyNjAxODU2N119
-->