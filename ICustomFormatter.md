#  ICustomFormatter

Definition:

  

public interface IFormatProvider

{

    Object GetFormat(Type formatType);

}

  

Returns an object to provide custom formatting and parsing when converting
to/from a string, i.e. ToString(), String.Format(), Parse() and TryParse().
The format/parsing method that is given the IFormatProvider object calls
GetFormat(). It passes the Type object that it expects will provide the
formatting information and GetFormat() returns an initialised object of that
type. IFormatProvider is often used implicitly (e.g. in
DateTime.ToString(string)) and explicitly where there is an overload for it,
e.g. Int32.Parse(String, IFormatProvider).

  

There are three predefined implementations of IFormatProvider that are used
for culture specific formatting:

  * NumberFormatInfo. Formats currency, thousands separator and decimal separator.
  * DateTimeFormatInfo. Formats dates and times.
  * CultureInfo. Represents a particular culture. Its GetFormat method returns a culture-specific NumberFormatInfo or DateTimeFormatInfo object. 

  

  

 **Custom Formatting**

To create your own custom formatting class you need to implement
IFormatProvider and ICustomFormatter. An instance of the class is then sent to
a formatting method that accepts a IFormatProvider.

  

Definition of ICustomFormatter:

  

public interface ICustomFormatter

{

    // Interface does not need to be marked with the serializable attribute

    String Format (String format, Object arg, IFormatProvider formatProvider);

}

  

Usage:

  

public class TelephoneFormatter : IFormatProvider, ICustomFormatter  
{  
  public object GetFormat(Type formatType)  
  {  
      if (formatType == typeof(ICustomFormatter))  
        return this;  
      else  
        return null;  
  }  
  
  public string Format(string format, object arg, IFormatProvider
formatProvider)  
  {  
      // Check whether this is an appropriate callback             
      if (! this.Equals(formatProvider))  
        return null;  
  
      // Set default format specifier             
      if (string.IsNullOrEmpty(format))  
        format = "N";  
  
      string numericString = arg.ToString();  
  
      if (format == "N")  
      {  
        if (numericString.Length <= 4)  
            return numericString;  
        else if (numericString.Length == 7)  
            return numericString.Substring(0, 3) + "-" \+ numericString.Substring(3, 4);  
        else if (numericString.Length == 10)  
              return "(" \+ numericString.Substring(0, 3) + ") " +  
                      numericString.Substring(3, 3) + "-" \+ numericString.Substring(6);   
        else  
            throw new FormatException(  
                      string.Format("'{0}' cannot be used to format {1}.",  
                                    format, arg.ToString()));  
      }  
      else if (format == "I")  
      {  
        if (numericString.Length < 10)  
            throw new FormatException(string.Format("{0} does not have 10 digits.", arg.ToString()));  
        else  
            numericString = "+1 " \+ numericString.Substring(0, 3) + " " \+ numericString.Substring(3, 3) + " " \+ numericString.Substring(6);  
      }  
      else  
      {  
        throw new FormatException(string.Format("The {0} format specifier is invalid.", format));  
      }  
      return numericString;   
  }  
}  
  
public class TestTelephoneFormatter  
{  
  public static void Main()  
  {  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 0));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 911));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 8490216));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 4257884748));  
  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 0));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 911));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 8490216));  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 4257884748));  
  
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:I}", 4257884748));  
  }  
}  
  

  

![noteattachment1][0d917d9e139fd0438c58d01933eee8b0]  

  

<https://msdn.microsoft.com/en-us/library/bb762932(v=vs.110).aspx>


---
### ATTACHMENTS
[0d917d9e139fd0438c58d01933eee8b0]: media/MyCustomDateProvider.cs
[MyCustomDateProvider.cs](media/MyCustomDateProvider.cs)
>hash: 0d917d9e139fd0438c58d01933eee8b0  
>source-url: file://C:\TFS\DEV\Tersus\Website\Website\entities\helpers\MyCustomDateProvider.cs  
>file-name: MyCustomDateProvider.cs  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2017-01-25 12:27:28  
>Last Evernote Update Date: 2017-01-25 13:20:15  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-url: https://referencesource.microsoft.com/mscorlib/system/iformatprovider.cs.html#0dbf315d83aad6ca  
>source-application: evernote.win32  