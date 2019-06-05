# Query Syntax

## Query Syntax: 

```csharp
var result = from d in data
             where d + 2 == 2
             select d
```

You can use multiple where clauses to add extra checks. This is the same as a where + &&.

Where clauses can appear anywhere in the statement as long as it's not the first line.

`Orderby` can have multiple items to order by, separated with a comma. Use 'descending' to invert.

You can combine data from multiple sources:

```csharp
int[] data1 = { 1, 2, 5 };
int[] data2 = { 2, 4, 6};

var result = from d1 in data1
             from d2 in data2
             select d1 * d2;

Console.WriteLine(string.Join(", ", result)); // Displays 2, 4, 6, 4, 8, 12, 10, 20, 30
```

## Projection

Projection with grouping. If there's only one Property in the projection then you don't need the parentheses.

```csharp
var result = from o in orders
             from l in o.OrderLines
             group l by l.Product into p
             select new
             {
                  Product = p.Key,
                  Amount = p.Sum(x => x.Amount)
             };
```

## Join
`Join` is used to join together two sources. Note the use of the `equals` keyword instead of `==`. You can't use `>` or `<`.

```csharp
string[] popularProductNames = { "A", "B" };
var popularProducts = from p in products
                      join n in popularProductNames on p.Description equals n
                      select p;
```

Or:

```csharp
var employeeByState = from e in employees
                      join s in states
                      on   e.StateId equals s.StateId
                      select new { e.LastName, s.StateName };
```

## Left Join
You can simulate a `LEFT JOIN` using a group join and `DefaultIfEmpty()`. Here, you create a group out of the join and then use `DefaultIfEmpty()` to create a default value for each item in the join that didn't have a match.

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

var employeeByState = from e in employees
                      join s in states
                      on e.StateId equals s.StateId into employeeGroup
                      from item in employeeGroup.DefaultIfEmpty(new State { StateId = 0, StateName = "" })
                      select new { e.LastName, item.StateName };

foreach (var employee in employeeByState)
{
    Debug.WriteLine(employee.LastName + ", " + employee.StateName);
}
```

## Composite Keys
This can be done by creating and comparing two anonymous types from the two collections that are being joined.

```csharp
List<Employee> employees = new List<Employee>()
{
    new Employee()
    {
        FirstName = "John",
        LastName = "Smith",
        City = "Havertown",
        State = "PA"
    },
    new Employee()
    {
        FirstName = "Jane",
        LastName = "Doe",
        City = "Ewing",
        State = "NJ"
    },
    new Employee()
    {
        FirstName = "Jack",
        LastName = "Jones",
        City = "Fort Washington",
        State = "PA"
    }
};

List<Hometown> hometowns = new List<Hometown>()
{
    new Hometown()
    {
        City = "Havertown",
        State = "PA",
        CityCode = "1234"
    },
    new Hometown()
    {
        City = "Ewing",
        State = "NJ",
        CityCode = "5678"
    },
    new Hometown()
    {
        City = "Fort Washington",
        State = "PA",
        CityCode = "9012"
    }
};

var employeeByState = from e in employees
                        join h in hometowns
                        on new { City = e.City, State = e.State } equals new { City = h.City, State = h.State }
                        select new { e.LastName, h.CityCode };

foreach (var employee in employeeByState)
{
    Debug.WriteLine(employee.LastName + ", " + employee.CityCode);
}
```

## Group

```csharp
List<Employee> employees = new List<Employee>()
{
    new Employee()
    {
        FirstName = "John",
        LastName = "Smith",
        City = "Havertown",
        State = "PA"
    },
    new Employee()
    {
        FirstName = "Jane",
        LastName = "Doe",
        City = "Ewing",
        State = "NJ"
    },
    new Employee()
    {
        FirstName = "Jack",
        LastName = "Jones",
        City = "Fort Washington",
        State = "PA"
    }
};

var employeesByState = from e in employees
                        group e by e.State;

foreach (var employeeGroup in employeesByState)
{
    Debug.WriteLine(employeeGroup.Key + ": " + employeeGroup.Count());

    foreach (var employee in employeeGroup)
    {
        Debug.WriteLine(employee.LastName + ", " + employee.State);
    }
}
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTkyNDAyMDU2N119
-->