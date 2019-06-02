# ProtectedData

This is a mechanism to encrypt/decrypt small bits of data. You can then
specify who can encrypt/decrypt data. It works by deriving a key from the
logged-in user's password.

  

static byte[] ProtectString(string data)

{

    byte[] userData = Encoding.Default.GetBytes(data);

    byte[] encryptedData = ProtectedData.Protect(userData, null, DataProtectionScope.LocalMachine);

    return encryptedData;

}

  

static string UnprotectString(byte[] encryptedData)

{

    byte[] userData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.LocalMachine);

    string data = Encoding.Default.GetString(userData);

    return data;

}

  

public static void Run()

{

    string input = "Data to be Protected!";

  

    var encrypted = ProtectString(input);

    var unprotected = UnprotectString(encrypted);

  

    Console.WriteLine("Using ProtectedData");

    Console.WriteLine("Input:{0}", input);

    Console.WriteLine("Protected: {0}", encrypted);

    Console.WriteLine("Unprotected: {0}", unprotected);

    Console.WriteLine();

}

  

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-01-09 21:06:38  
>Last Evernote Update Date: 2017-01-19 19:13:20  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  