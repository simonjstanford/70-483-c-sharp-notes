# WCF

WCF:
- Uses the Open Data Protocol, OData. This is a web protocol that uses HTTP.
- Returns XML by default, but also JSON. If it's XML then it follows the OData ATOM format.

A Windows Communication Foundation (WCF) service follows the ABC model:
- Address. The endpoint that is listening for service requests.
- Binding. The protocols/transports that can be used, e.g. HTTP, HTTPS.
- Contract. The operations the service exposes. 

A WCF service consists of:
- A .svc file. Contains info on hosting the service in IIS. 
- A code behind file with service logic.

To create a WCF service you first need to define the contract. This is an interface with the `ServiceContract` and `OperationContract` attributes. The example below was created in Visual Studio by adding a new WCF Service website. You can then debug the application and view the WSDL info in a browser and execute the service using the WCF Test Client.

```csharp
[ServiceContract]
public interface IService1
{
    [OperationContract]
    string GetData(string value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);
}
```

You then need a code behind file that implements the contract:

```csharp
public class Service1 : IService1
{
    public string GetData(string value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }
}
```

When working with an existing WCF service you need to create a service reference in Visual Studio. This creates a proxy object in the client project.

```csharp
var client = new ServiceReference1.ServiceClient();
var result = client.GetData("Hello!");
Console.WriteLine(result);
Console.ReadKey();
```
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTU2NjczODk5OV19
-->