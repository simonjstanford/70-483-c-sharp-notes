# Trace Switches

Trace switches are used to control what type of information is outputted when debugging an live application.

There are two predefined classes that are used to create switches that are in the System.Diagnostics namespace.

  

## BooleanSwitch

Used to turn tracing on or off. Set the switch value to 0 for off and any non-zero value for on. From .NET 2.0 you are able to use text for the value - true/false  

A BooleanSwitch is created in the app.config like this:  

    <configuration>  
      <system.diagnostics>  
        <switches>  
          <add name="mySwitch" value="1"/>  
        </switches>  
      </system.diagnostics>
    </configuration>

And then you can retrieve it in code and use it like this:

    private static BooleanSwitch boolSwitch = new BooleanSwitch("mySwitch", "Switch in config file");
    
    public static void Main( )
    {
        //...
        Console.WriteLine("Boolean switch {0} configured as {1}", boolSwitch.DisplayName, boolSwitch.Enabled.ToString());
    
        if (boolSwitch.Enabled)
        {
            //...
       
        }
    }

## TraceSwitch

Used to set the level of tracing. You can define custom trace messages for different levels.
 
The level of information can be set using the TraceLevel enumeration which is used in the TraceSwitch.Level property. This property is readonly - it is set in config or instantiation. Default level is TraceLevel.Off. From .NET 2.0 you are able to use the text value for the value - Off, Error, Warning, etc.


| Enumerated value | Integer value | Type of message displayed (or written to a specified output target)            |
|------------------|---------------|--------------------------------------------------------------------------------|
| Off              | 0             | None                                                                           |
| Error            | 1             | Only error messages                                                            |
| Warning          | 2             | Warning messages and error messages                                            |
| Info             | 3             | Informational messages, warning messages, and error messages                   |
| Verbose          | 4             | Verbose messages, informational messages, warning messages, and error messages |
  


A TraceSwitch is created in the app.config like this:
      
    <configuration>  
       <system.diagnostics>
        <switches>
          <add name="mySwitch" value="1"/>
        </switches>
      </system.diagnostics>
    </configuration>
      
And then you can retrieve it in code and use it like this:

    private static TraceSwitch traceSwitch = new TraceSwitch("mySwitch", "Switch in config file");
    
    public static void Main( )
    {
        //...
        Console.WriteLine("Trace switch {0} configured as {1}", traceSwitch.DisplayName, traceSwitch.Level.ToString());
        
        switch (traceSwitch.Level)
        {
             case TraceLevel.Error:
             ... 
        }
    }
      

<https://msdn.microsoft.com/en-us/library/3at424ac(v=vs.110).aspx>
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTkyODg0MTkzNV19
-->