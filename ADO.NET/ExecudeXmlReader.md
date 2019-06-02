# ExecudeXmlReader

This returns an XMLReader, which represents data returned from a database
SELECT statement in XML. Notice the inclusion of 'FOR XML AUTO, XMLDATA' in
the SQL statement. Note that the XML schema is also returned.

      
    
    SqlConnection cn = new SqlConnection();
    //cn.ConnectionString = "Server=myServerAddress;Database=myDataBase;User
    Id=myUsername;Password=myPassword;";
    cn.ConnectionString = "Server = (local); Database = Reflection;
    Trusted_Connection = True;";
    cn.Open();
    
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = cn;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "SELECT * FROM Person FOR XML AUTO, XMLDATA";
    System.Xml.XmlReader xml = cmd.ExecuteXmlReader();
    
    cn.Close();

  

Output:
 
    <Schema name="Schema1" xmlns="urn:schemas-microsoft-com:xml-data"
    xmlns:dt="urn:schemas-microsoft-com:datatypes">
    <ElementType name="Person" content="empty" model="closed">
    <AttributeType name="PersonId" dt:type="i4"/>
    <AttributeType name="FirstName" dt:type="string"/>
    <AttributeType name="LastName" dt:type="string"/>  
    <AttributeType name="Address" dt:type="string"/>
    <AttributeType name="City" dt:type="string"/>
    <AttributeType name="State" dt:type="string"/>
    <AttributeType name="ZipCode" dt:type="string"/>
    <attribute type="PersonId"/>
    <attribute type="FirstName"/>
    <attribute type="LastName"/>    
    <attribute type="Address"/>
    <attribute type="City"/>
    <attribute type="State"/>
    <attribute type="ZipCode"/>
    </ElementType>
    </Schema>
    <Person xmlns="x-schema:#Schema1" PersonId="1" FirstName="John"
    LastName="Smith"
    Address="123 First Street" City="Philadelphia" State="PA" ZipCode="19111"/>
    

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTEwOTg5NzUxNTgsLTExOTQ4MjExMDFdfQ
==
-->