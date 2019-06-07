# Generating Test x.509 Certificates

- A digital certificate authenticates the identity of the object signed by the certificate. 
- An object is hashed and then the hash is encrypted with a private key. When someone decrypts the hash with a public key they can check if the object has been changed.
- Certificates are part of a Public Key Infrastructure (PKI):
	- Certificates - contains public key and details.
	- Certificate Authority (CA) - Issues certificates, trustworthy.
- .NET implements the X.509 certificate standard.
- All classes for creating/managing certificates are in System.Security.Cryptography.X509Certificates.



## makecert.exe

X.509 certificates for testing purposes can be created using makecert.  

To make a certificate using the following. You need to install the certificate after creation:

```
makecert C:\certs\testCert.cer
```

To generates a certificate and installs it in a custom certificate store name simonsCertStore:

```
makecert -n "CN=WouterDeKort" -sr currentuser -ss simonsCertStore
```

## Self Signed Certificates

To generate a self signed certificate for development purposes you need to:

1) Create a self signed certificate. Note:
- -n is the name of the certificate
- -r makes it self signed
- -sv creates a private key file 
- Simon2.cer is the name of the certificate

```
cd C:\Program Files (x86)\Microsoft SDKs\Windows\v7.1A\Bin
makecert -n "CN=Simon2CA" -r -sv Simon2CA.pvk Simon2CA.cer
```

2) Create a new certificate signed by the root authority certificate and put it straight into a certificate store. When done, you can inspect the certificate in the certificate store and see that it isn't trusted. Note that the name should be the domain you are certifying.
- -sk is the location of the subject key container that holds the new private key. Create if doesn't exist.
- -iv is the issuer's private key file.
- -n is the name of the certificate.
- -ic the issuer's certificate
- -sr the registry location of the certificate store to use - either localmachine or currentuser
- -ss is the name of the subject's certificate store where the generated certificate will be stored.

```
makecert -sk SignedByCA -iv Simon2CA.pvk -n "CN=*.simonjstanford.co.uk" -ic Simon2CA.cer -sr localmachine -ss My
```

3) Import the first certificate into the Trusted Root Certification Authorities store. Any certificates that are signed with the certificate will now be trusted by the computer. 
	1.  Open the certificate snap-in and navigate to Local Computer or Current User.
	2.  Open the Trusted Root Certification Authorities folder.
	3.  Right click the Certificates folder -> all tasks -> import
	4.  Import the certificate.


4) Now you can use the certificate in a WCF service. 

https://msdn.microsoft.com/en-us/library/ms733813(v=vs.110).aspx
https://msdn.microsoft.com/library/windows/desktop/aa386968.aspx

<!--stackedit_data:
eyJoaXN0b3J5IjpbMTI5NTIzNDQwMl19
-->