# Overloading

Many operators can be overloaded:

  * \+ (unary), − (unary), !, ˜, ++,−−, +, −, *,  /, %, &, |, ^, <<, >>, ==, !=, >, <, >= , <=.
  * Implicit/explicit operations can be overloaded with the implicit and explicit keywords.
  * true/false
  * Compound operators (e.g. +=, -=) are implicitly overloaded when their component operators are overridden.
  * Conditional operators && and || are overridden when overriding the bitwise operators & and |.

  

Overloading works using the operator function. Rules:

  * The operator function must be static and public. 
  * The parameter of the operator function represents the operands.
  * The return type is the result of the expression.
  * At least one of the operands must be the type in which the operator function is declared.

  

E.g:

  

public struct Note

{

    int value;

  

    public Note (int semitonesFromA)

    {

        value = semitonesFromA;

    }

  

    public static Note operator + (Note x, int semitones)

    {

        return new Note (x.value + semitones);

    }

}

  

  

 **Overloading Equality and Comparison Operators**

Rules:

  * If an operator has a logical opposite then they both must be defined: == and !=, < and >, <= and >=.
  * If you overload == and != then you should override Equals() and GetHashCode().
  * If you overload (<  >) and (<= >=) then you should implement IComparable and IComparable<T>

  

  

 **Custom Implicit/Explicit Conversions**

Used to convert strongly related types. If the two types aren't strongly
related then use a constructor or specific method for the conversion. Remember
that implicit conversions are guaranteed to succeed and don't lose
information. Explicit conversions happen when the cast may not succeed or
information will be lost. Custom conversions are ignored by the 'as' and 'is'
operators.

  

// Convert to hertz

public static implicit operator double (Note x)

{

    return 440 * Math.Pow (2, (double) x.value / 12 );

}

// Convert from hertz (accurate to the nearest semitone)

public static explicit operator Note (double x)

{

    return new Note ((int) (0.5 + 12 * (Math.Log (x/440) / Math.Log(2) ) ));

}

...

  

Note n = (Note)554.37; // explicit conversion

double x = n; // implicit conversion

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-02-02 19:30:51  
>Last Evernote Update Date: 2017-02-02 19:48:27  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  