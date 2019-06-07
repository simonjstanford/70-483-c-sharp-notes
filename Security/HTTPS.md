# HTTPS

One use of digital certificates is to secure an internet connection HTTPS
secures communication between a web server and a client. Digital certificates
are used to make sure that the client is communicating with the correct web
server, not an imposter.

  

HTTPS consists of communication over HTTP within a connection encrypted by
Transport Layer Security (TLS) or Secure Sockets Layer (SSL).  HTTP provides
authentication of the web server, protecting against man in the middle
attacks. Also, by encrypting communication between the client and server, the
user is protected from eavesdropping/tampering.

  

Web browsers know how to trust HTTPS websites using certificate authorities.
Certificate authorities are trusted by web browser creators to provide valid
certificates.

  

HTTPS uses port 443 by default, whereas HTTP uses port 80.

  

  

 **Setting Up HTTPS**

  1. IIS -> Simon-Server -> Server Certificates -> Create Certificate Request. This creates a certificate request file.  

  2. Go to [https://www.startssl.com](https://www.startssl.com/Account?r=L0NvbnRyb2xQYW5lbA%3D%3D) and use the certificates wizard to create a new certificate using the text in the csr file.   

  3. IIS -> Simon-Server -> Server Certificates -> Complete Certificate Request. The certificate has now been imported into IIS.
  4. To use the certificate in a site: IIS -> Sites -> simonjstanford.co.uk -> Bindings -> Add. Type is HTTPS, IP address is All Unassigned, Port is 443 and then select the SSL certificate that's just been imported.
  5. To make sure that all traffic uses HTTPS you can use the Microsoft IIS URL Rewrite Module (<https://www.iis.net/downloads/microsoft/url-rewrite>). You can then use the GUI within the simonjstanford.co.uk site to add a rule, or manually update the web.config file.

  

![noteattachment1][de8706ce2e2613432a7187f81f6983b2]
![noteattachment2][fabc117a1d68111aa855ad442f815932]
![noteattachment3][adae715858fd4f99d9a64a1616b963ef]

  

<https://www.digicert.com/csr-creation-microsoft-iis-7.htm>

<https://www.digicert.com/ssl-certificate-installation-microsoft-iis-7.htm>

<https://www.networking4all.com/en/support/ssl+certificates/manuals/microsoft/all+windows+servers/export+private+key+or+certificate/>


---
### ATTACHMENTS
[de8706ce2e2613432a7187f81f6983b2]: media/simonjstanford.csr
[simonjstanford.csr](media/simonjstanford.csr)
>hash: de8706ce2e2613432a7187f81f6983b2  
>source-url: file://C:\Users\simon\Desktop\simonjstanford.csr  
>file-name: simonjstanford.csr  
>attachment: true  

[fabc117a1d68111aa855ad442f815932]: media/www.simonjstanford.co.uk.zip
[www.simonjstanford.co.uk.zip](media/www.simonjstanford.co.uk.zip)
>hash: fabc117a1d68111aa855ad442f815932  
>source-url: file://C:\Users\simon\Downloads\www.simonjstanford.co.uk.zip  
>file-name: www.simonjstanford.co.uk.zip  
>attachment: true  

[adae715858fd4f99d9a64a1616b963ef]: media/web.config
[web.config](media/web.config)
>hash: adae715858fd4f99d9a64a1616b963ef  
>source-url: file://C:\Users\simon\Desktop\web.config  
>file-name: web.config  
>attachment: true  

---
### NOTE ATTRIBUTES
>Created Date: 2016-10-23 10:04:19  
>Last Evernote Update Date: 2016-10-24 19:28:53  
>author: simonjstanford@gmail.com  
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTY5MjIwMDM2Ml19
-->