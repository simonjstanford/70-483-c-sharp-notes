# HTTPS

One use of digital certificates is to secure an internet connection HTTPS secures communication between a web server and a client. Digital certificates are used to make sure that the client is communicating with the correct web server, not an imposter.

HTTPS consists of communication over HTTP within a connection encrypted by Transport Layer Security (TLS) or Secure Sockets Layer (SSL).  HTTP provides authentication of the web server, protecting against man in the middle attacks. Also, by encrypting communication between the client and server, the user is protected from eavesdropping/tampering. 

Web browsers know how to trust HTTPS websites using certificate authorities. Certificate authorities are trusted by web browser creators to provide valid certificates. 

HTTPS uses port 443 by default, whereas HTTP uses port 80.

Setting Up HTTPS

1.  IIS -> Simon-Server -> Server Certificates -> Create Certificate Request. This creates a certificate request file.
2.  Go to https://www.startssl.com and use the certificates wizard to create a new certificate using the text in the csr file. 
3.  IIS -> Simon-Server -> Server Certificates -> Complete Certificate Request. The certificate has now been imported into IIS.
4.  To use the certificate in a site: IIS -> Sites -> simonjstanford.co.uk -> Bindings -> Add. Type is HTTPS, IP address is All Unassigned, Port is 443 and then select the SSL certificate that's just been imported.
5.  To make sure that all traffic uses HTTPS you can use the Microsoft IIS URL Rewrite Module (https://www.iis.net/downloads/microsoft/url-rewrite). You can then use the GUI within the simonjstanford.co.uk site to add a rule, or manually update the web.config file.


https://www.digicert.com/csr-creation-microsoft-iis-7.htm
https://www.digicert.com/ssl-certificate-installation-microsoft-iis-7.htm
https://www.networking4all.com/en/support/ssl+certificates/manuals/microsoft/all+windows+servers/export+private+key+or+certificate/

[web.config](../media/web.config)

<!--stackedit_data:
eyJoaXN0b3J5IjpbLTYxOTMwMzgxMCwtNjkyMjAwMzYyXX0=
-->