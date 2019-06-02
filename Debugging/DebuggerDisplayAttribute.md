# DebuggerDisplayAttribute

In debugging, values of objects are displayed using their ToString() method. DebuggerDisplayAttribute allows you to specify the value displayed for an object when debugging. You could override ToString() instead, but DebuggerDisplayAttribute means that the ToString() override wont be in the release build.

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                FirstName = "Simon",
                LastName = "Stanford"
            };
        }
    
    }
    
    [DebuggerDisplay("Name = {FirstName} {LastName}")]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

<!--stackedit_data:
eyJoaXN0b3J5IjpbMjA1Mjk2MDY1MF19
-->