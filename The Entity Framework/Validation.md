# Validation

You can use `Validator.TryValidateObject()` to validate an entity:

```csharp
public static class GenericValidator<T>
{
    public static IList<ValidationResult> Validate(T entity)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(entity, null, null);
        Validator.TryValidateObject(entity, context, results);
        return results;
    }
}
```

http://odetocode.com/blogs/scott/archive/2011/06/29/manual-validation-with-data-annotations.aspx
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTU4MzcxNTk3OF19
-->