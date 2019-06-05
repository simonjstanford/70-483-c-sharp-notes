# Method Syntax


## Method Syntax:

```csharp
var result = data.Where(d => d + 2 == 2);
```

You can use multiple 'Where' clauses:

```csharp
var eventNumber = myArray.Where(i => i % 2 == 0).Where(i => i > 5);
```

## Ordering

Use OrderBy, OrderByDescending and ThenBy.


## Projection
Use Select:

```csharp
var lastNames = people.Select(p => p.LastName);
```

You can project to anonymous types in method syntax too:

```csharp
var names = people.Select(p => new { p.FirstName, p.LastName });
```

## SelectMany
Flattens two sequences into one.

See https://msdn.microsoft.com/en-us/library/bb534336(v=vs.110).aspx


## Joining
Joins two sequences together. Here, the Join method takes four parameters:
- The collection to join to
- The key of the outer collection
- The key of the inner collection
- A lambda expression that creates an anonymous type with the result

```csharp
List<Employee> employees = new List<Employee>()
{
    new Employee()
    {
        FirstName = "John",
        LastName = "Smith",
        StateId = 1
    },
    new Employee()
    {
        FirstName = "Jane",
        LastName = "Doe",
        StateId = 2
    },
    new Employee()
    {
        FirstName = "John",
        LastName = "Smith",
        StateId = 1
    }
};

List<State> states = new List<State>()
{
    new State()
    {
        StateId = 1,
        StateName = "PA"
    },
    new State()
    {
        StateId = 2,
        StateName = "NJ"
    }
};

var employeeByState = employees.Join(states,
                                        e => e.StateId,
                                        s => s.StateId,
                                        (e, s) => new { e.LastName, s.StateName });

foreach (var employee in employeeByState)
{
    Debug.WriteLine(employee.LastName + ", " + employee.StateName);
}
```

## Outer Join
This is done using GroupJoin().  This accepts four arguments:
- The collection to join to.
- The key of the outer collection
- The key of the inner collection
- A lambda expression that iterates through the join and creates a new anonymous type.
- DefaultIfEmpty() is used to set a default value for items in the collection that had no match.

Note that SelectMany() is used at the end to return the sequence:


List<Employee> employees = new List<Employee>()
{
    new Employee()
    {
        FirstName = "John",
        LastName = "Smith",
        StateId = 1
    },
    new Employee()
    {
        FirstName = "Jane",
        LastName = "Doe",
        StateId = 2
    },
    new Employee()
    {
        FirstName = "Jack",
        LastName = "Jones",
        StateId = 1
    },
    new Employee()
    {
        FirstName = "Sue",
        LastName = "Smith",
        StateId = 3
    }
};

List<State> states = new List<State>()
{
    new State()
    {
        StateId = 1,
        StateName = "PA"
    },
    new State()
    {
        StateId = 2,
        StateName = "NJ"
    }
};

var employeeByState = employees.GroupJoin(states,
                                            e => e.StateId,
                                            s => s.StateId,
                                            (e, employeeGroup) => employeeGroup
                                            .Select(s => new
                                            {
                                                LastName = e.LastName,
                                                StateName = s.StateName
                                            })
                                            .DefaultIfEmpty(new
                                            {
                                                LastName = e.LastName,
                                                StateName = ""
                                            }))
                                            .SelectMany(e => e);

foreach (var employee in employeeByState)
{
    Debug.WriteLine(employee.LastName + ", " + employee.StateName);
}


Composite Keys
You can join on composite keys by specifying anonymous types as the inner/outer keys in a Join:


var employeeByState = employees.Join(hometowns,
                                        e => new { City = e.City, State = e.State },
                                        h => new { City = h.City, State = h.State },
                                        (e, h) => new { e.LastName, h.CityCode });


Concatenation
Similar to the SQL UNION statement.


var combinedEmployees = employees.Concat(employees2);

You can combine two collections of different types by using anonymous types:


var combinedEmployees = employees.Select(e => new { Name = e.LastName })
                                 .Concat(people.Select(p => new { Name = p.LastName }));



GroupBy


var employeesByState = employees.GroupBy(e => e.State);

Or use an anonymous type to group by more than one property:


var employeesByState = employees.GroupBy(e => new { e.City, e.State });


Skip
Skip moves past the first N elements in a result and returns the remainder. Take returns the first N elements in a result and discards the remainder:


IEnumerable<int> values = Enumerable.Range(0, 10000);

var pagedValues = values.Take(100);

foreach (var item in pagedValues)
{
    Console.WriteLine(item);
}

pagedValues = values.Skip(5000);

foreach (var item in pagedValues)
{
    Console.WriteLine(item);
}

Console.Read();

Casting
Use OfType<T>() to return only objects that can be cast to T. Use Cast<T>() when you want an exception to be thrown when one of the objects can't be cast.

Others:
	* 
Take()
	* 
Distinct()



<!--stackedit_data:
eyJoaXN0b3J5IjpbNTMzNjEyMDY1XX0=
-->