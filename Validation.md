# Validation

You can use Validator.TryValidateObject() to validate an entity:

  

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

  

<http://odetocode.com/blogs/scott/archive/2011/06/29/manual-validation-with-
data-annotations.aspx>


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-09 18:40:55  
>Last Evernote Update Date: 2016-11-07 22:18:06  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  