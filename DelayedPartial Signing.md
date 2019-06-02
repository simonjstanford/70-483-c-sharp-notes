# Delayed/Partial Signing

It is important to secure the private key when strongly naming an assembly. If
someone has access to the private key then they are able to distribute
assemblies that look legitimate. To avoid this problem you can use
delayed/partial signing. This is where the public key is used to sign an
assembly instead of the private key. The private key is only used for signing
at deployment. This allows the private key to be kept secure. This is done in
the project -> properties tab. I've found that you can't run or debug an
application that is set to delayed sign.


---
### NOTE ATTRIBUTES
>Created Date: 2016-10-31 20:44:56  
>Last Evernote Update Date: 2016-10-31 20:45:30  
>author: simonjstanford@gmail.com  