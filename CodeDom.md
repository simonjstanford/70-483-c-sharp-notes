# CodeDom

  * Generates code at runtime in C#, VB.NET or JScript.
  * Creates an object graph that can be converted to a source file or binary assembly.
  * E.g. generates code for ASP.NET, Web Services.
  * You can create the logical structure of a piece of code independent of the language syntax - you can create both C# and VB.NET source files.

  

There is a class for every time of statement that you can make:

  

![noteattachment1][2469ef5e741dee53185b2bf97f01dbcf]

Notes:

  * A BinaryOperatorExpression is used as an operation executed against two variables, e.g. add, subtract, greater than, less than. See <https://msdn.microsoft.com/en-us/library/system.codedom.codebinaryoperatorexpression(v=vs.110).aspx> and <https://msdn.microsoft.com/en-us/library/system.codedom.codebinaryoperatortype(v=vs.110).aspx>.

  

![noteattachment2][ff83b0d8bdb6ba25b76f840ecc67be69]

![noteattachment3][f7329e25f454bf0e26353701870b3921]

  

 **CodeCompileUnit**

This is the top-level class that is the container for all other objects in the
class you want to generate.

  

CodeCompileUnit compileUnit = new CodeCompileUnit();  

  

  

 **CodeNamespace and CodeNamespaceImport**

You then need to add the namespace and any required using statements

  

CodeNamespace myNamespace = new CodeNamespace("MyNamespace");

myNamespace.Imports.Add(new CodeNamespaceImport("System"));

compileUnit.Namespaces.Add(myNamespace);  

  

  

 **CodeTypeDeclaration**

This is used to declare the class. Note that the different type attributes
(private, public and static) can be combined with the bitwise operator.

  

CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");

myClass.IsClass = true;

myClass.TypeAttributes = TypeAttributes.Public;

myNamespace.Types.Add(myClass);  

  

  

 **CodeMemberField**

Used to add fields to the class.

  

CodeMemberField xField = new CodeMemberField();

xField.Name = "x";

xField.Type = new CodeTypeReference(typeof(double));

myClass.Members.Add(xField);

  

  

 **CodeMemberProperty**

Used to add properties to the class

  

CodeMemberProperty xProperty = new CodeMemberProperty();

xProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;

xProperty.Name = "X";

xProperty.HasGet = true;

xProperty.HasSet = true; //set to false to make read-only

xProperty.Type = new CodeTypeReference(typeof(System.Double));

xProperty.GetStatements.Add(new CodeMethodReturnStatement(new
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x")));

xProperty.SetStatements.Add(new CodeAssignStatement(new
CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x"), new
CodePropertySetValueReferenceExpression()));

myClass.Members.Add(xProperty);

  

  

 **CodeMemberMethod**

Used to create methods. The following defines the method:

  

CodeMemberMethod divideMethod = new CodeMemberMethod();

divideMethod.Name = "Divide";

divideMethod.ReturnType = new CodeTypeReference(typeof(double));

divideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

myClass.Members.Add(divideMethod);  

  

And now to add logic to the method defined above. The following checks if
property 'y' is 0 - if not it is divided by 'x'

  

CodeConditionStatement ifLogic = new CodeConditionStatement();

  

ifLogic.Condition = new CodeBinaryOperatorExpression(new
CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
yProperty.Name), CodeBinaryOperatorType.ValueEquality, new
CodePrimitiveExpression(0));

  

ifLogic.TrueStatements.Add(new CodeMethodReturnStatement(new
CodePrimitiveExpression(0)));

  

ifLogic.FalseStatements.Add(new CodeMethodReturnStatement(

     new CodeBinaryOperatorExpression(

        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), xProperty.Name),

        CodeBinaryOperatorType.Divide,

        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), yProperty.Name))));

  

divideMethod.Statements.Add(ifLogic);

  

  

 **CodeParameterDeclarationExpression & CodeMethodInvokeExpression**

The method defined below takes a parameter called 'power' and executes a
method using the parameter's value.

  

CodeMemberMethod exponentMethod = new CodeMemberMethod();

exponentMethod.Name = "Exponent";

exponentMethod.ReturnType = new CodeTypeReference(typeof(double));

exponentMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

  

CodeParameterDeclarationExpression powerParameter = new
CodeParameterDeclarationExpression(typeof(double), "power");

exponentMethod.Parameters.Add(powerParameter);

  

CodeMethodInvokeExpression callToMath = new CodeMethodInvokeExpression(

    new CodeTypeReferenceExpression("System.Math"),

    "Pow", new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), xProperty.Name), new CodeArgumentReferenceExpression("power"));

  

exponentMethod.Statements.Add(new CodeMethodReturnStatement(callToMath));

  

targetClass.Members.Add(exponentMethod);

  

  

 **CodeDOMProvider**

This is used to generate the class file. The following creates a C# file with
single line spacing and the { } characters on new lines.

  

CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

CodeGeneratorOptions options = new CodeGeneratorOptions();

options.BlankLinesBetweenMembers = false;

options.BracingStyle = "C";

  

using (StreamWriter sourceWriter = new StreamWriter(@"c:\CodeDom\Calculator."
\+ provider.FileExtension))

{

    provider.GenerateCodeFromCompileUnit(codeCompileUnit, sourceWriter, options);

}

  

  

Here's another simple example that also ind

  

// create the object graph

CodeCompileUnit compileUnit = new CodeCompileUnit();

CodeNamespace myNamespace = new CodeNamespace("MyNamespace");

myNamespace.Imports.Add(new CodeNamespaceImport("System"));

CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");

CodeEntryPointMethod start = new CodeEntryPointMethod();

CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(new
CodeTypeReferenceExpression("Console"), "WriteLine", new
CodePrimitiveExpression("Hello World!"));

  

compileUnit.Namespaces.Add(myNamespace);

myNamespace.Types.Add(myClass);

myClass.Members.Add(start);

start.Statements.Add(cs1);

  

  

//create the source code file

CSharpCodeProvider provider = new CSharpCodeProvider();

  

using (StreamWriter sw = new StreamWriter(@"HelloWorld.cs", false))

{

    IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

    provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());

    tw.Close();

}

  


---
### ATTACHMENTS
[2469ef5e741dee53185b2bf97f01dbcf]: media/CodeDom.png
[CodeDom.png](media/CodeDom.png)
[ff83b0d8bdb6ba25b76f840ecc67be69]: media/CodeDom-2.png
[CodeDom-2.png](media/CodeDom-2.png)
[f7329e25f454bf0e26353701870b3921]: media/CodeDom-3.png
[CodeDom-3.png](media/CodeDom-3.png)
---
### NOTE ATTRIBUTES
>Created Date: 2016-10-03 21:10:41  
>Last Evernote Update Date: 2017-01-18 19:25:44  
>author: simonjstanford@gmail.com  