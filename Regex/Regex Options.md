# Regex Options

Regex options can be specified in three ways:
- Pass an options parameter to a Regex object's pattern matching methods. These options are defined in the RegexOptions enumeration.
- Use the syntax (?options) to include inline options in a regular expression. The options are shown below. If the list begins with - then the following options are turned off. The options stay in effect until a new set of inline options reset the values.
- Use the syntax (?options:subexpression) in a regular expression. This encapsulates the expression to which the options should apply.

![enter image description here](../media/Regex_Options.png)
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE2NDczMzk3NzAsMzg4ODkyMjIwXX0=
-->