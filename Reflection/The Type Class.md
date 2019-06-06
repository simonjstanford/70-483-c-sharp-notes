# The Type Class

This represents a class, interface, array, value type, enumeration, parameter,
generic type definition and open or closed constructed generic types. Open
constructed generic types seem to be 'T' in a type definition, closed
constructed types are actual type names -[
http://stackoverflow.com/questions/1735035/generics-open-and-closed-
constructed-types](http://stackoverflow.com/questions/1735035/generics-open-
and-closed-constructed-types). You can use typeof() or GetType() to get a Type
object.

  

![noteattachment1][e971a3aecf24e700786a7e0311b47dd1]

  

Example of usage:

  

int myInt = 0;

Type type = myInt.GetType();

  

Console.WriteLine(type.AssemblyQualifiedName);

Console.WriteLine(type.FullName);

Console.WriteLine(type.IsValueType);

Console.WriteLine(type.Name);

Console.WriteLine(type.Namespace);

Console.Read();

  

  

![noteattachment2][156c9eed061f23d5fd223bbee78e928c]

![noteattachment3][2bf4c6693037f6d0afab7c960b2a576c]

  

 **GetConstructors**

 **  
**

DataTable myDataTable = new DataTable();

Type myDataTableType = myDataTable.GetType();

ConstructorInfo[] myDataTableConstructors = myDataTableType.GetConstructors();

  

for(int i = 0; i <= myDataTableConstructors.Length - 1; i++)

{

    ConstructorInfo constructorInfo = myDataTableConstructors[i];

    Debug.Print(string.Format("\nConstructor #{0}", i + 1));

  

    ParameterInfo[] parameters = constructorInfo.GetParameters();

    Debug.Print(string.Format("Number Of Parameters: {0}", parameters.Length));

  

    foreach (ParameterInfo parameter in parameters)

    {

        Debug.Print(string.Format("Parameter Name: {0}", parameter.Name));

        Debug.Print(string.Format("Parameter Type: {0}", parameter.ParameterType.Name));

    }

}

 **  
**

 **  
**

 **GetEnumName, GetEnumNames, GetEnumValue**

 **  
**

Note that GetEnumValue returns the enum name, not the underlying enum number.

  

Type myCustomEnumType = typeof(MyCustomEnum);

  

string[] enumNames = myCustomEnumType.GetEnumNames();

  

foreach (string enumName in enumNames)

{

    Debug.Print(string.Format("Name: {0}", enumName));

}

  

Array enumValues = myCustomEnumType.GetEnumValues();

foreach (object enumValue in enumValues)

{

    Debug.Print(string.Format("Enum Value: {0}", enumValue.ToString()));

}

  

for (int i = 1; i <= 3; i++)

{

    string enumName = myCustomEnumType.GetEnumName(i);

    Debug.Print(string.Format("{0}: {1}", enumName, i));

}

  

  

 **GetField, GetFields, GetProperty & GetProperties**

  

  

class Program

    {

        static void Main(string[] args)

        {

            var plugin = new MyPlugin();

  

            FieldInfo[] fields = plugin.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

  

            foreach (var field in fields)

            {

                Console.WriteLine(field.GetValue(plugin));

            }

  

            PropertyInfo[] properties = plugin.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)

            {

                Console.WriteLine(property.GetValue(plugin));

            }

  

            Console.ReadKey();

        }

    }

  

    public class MyPlugin

    {

        private string test = "test";

  

        public string Name

        {

            get { return "MyPlugin"; }

        }

  

        public string Description

        {

            get { return "My Sample Plugin"; }

        }

  

        public bool Load()

        {

            Console.WriteLine("MyPlugin Loaded");

            return true;

        }

    }

  

Note that you can also set the value of a field of property:

  

ReflectionExample reflectionExample = new ReflectionExample();

Type reflectionExampleType = typeof(ReflectionExample);

  

reflectionExampleType.GetField("_privateField", BindingFlags.NonPublic |
BindingFlags.Instance).SetValue(reflectionExample, "My New Value");

  

Debug.Print(string.Format("Private Field Value: {0}",
reflectionExample.PrivateField));

  


---
### ATTACHMENTS
[e971a3aecf24e700786a7e0311b47dd1]: media/The_Type_Class.png
[The_Type_Class.png](media/The_Type_Class.png)
[156c9eed061f23d5fd223bbee78e928c]: media/The_Type_Class-2.png
[The_Type_Class-2.png](media/The_Type_Class-2.png)
[2bf4c6693037f6d0afab7c960b2a576c]: media/The_Type_Class-3.png
[The_Type_Class-3.png](media/The_Type_Class-3.png)
---
### NOTE ATTRIBUTES
>Created Date: 2016-12-31 16:46:45  
>Last Evernote Update Date: 2017-01-02 20:37:07  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTQ3MDU1MDYzOV19
-->