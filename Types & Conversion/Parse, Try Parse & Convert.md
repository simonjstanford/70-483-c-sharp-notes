# Parse, Try Parse & Convert

- You can pass a NumberStyles enum and CultureInfo object into Parse.
	- With NumberStyles you can specify that the value to parse has e.g. a currency symbol, white space, white space, etc.
	- https://msdn.microsoft.com/en-us/library/system.globalization.numberstyles(v=vs.110).aspx
- There are no extra options for TryParse
- DateTime.Parse has several overloads
	- IFormatProvider
	- DateTimeStyles
- Convert() just ends up with the variable being the default value if the conversion fails.
	- An OverflowException is thrown if the value is too big for the new type.


<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE2MDA2Njk3NzksLTIwODg3NDY2MTJdfQ
==
-->