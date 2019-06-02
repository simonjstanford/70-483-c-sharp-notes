# TCP

TCP in .NET is handled through the TcpClient, TcpListener and Socket class.
TcpClient is easier to use, Socket is feature rich. TcpClient exposes an
underlying Socket object through the TcpClient.Client property.

  

TCP differentiates between a client and a server - the client initiates
requests.  Connect() blocks until connection is established, but there is an
asynchronous version. NetworkStream provides a method for two-way
communication as both client and server can transmit and receive data.

  

This is the basic structure of a client request:

  

using (TcpClient client = new TcpClient())

{

    client.Connect ("address", port);

  

    using (NetworkStream n = client.GetStream())

    {

        // Read and write to the network stream...

    }

}

  

This is the basic structure of a server listener. Note that you can use
IPAddress.Any to tell the listener to listen on all local IP addresses.
AcceptTcpClient() blocks until a connection is received and there is an
asynchronous version.

  

TcpListener listener = new TcpListener (<ip address>, port);

listener.Start();

  

while (keepProcessingRequests)

{

    using (TcpClient c = listener.AcceptTcpClient())

    using (NetworkStream n = c.GetStream())

    {

        // Read and write to the network stream...

    }

}

  

listener.Stop();

  

A full example. Note that BinaryReader/Writer is used instead of
StreamReader/Writer. This is because BinaryReader/Writer prefix strings with a
length so the reader knows how many bytes to read. This doesn't happen with
StreamReader and calling StreamReader.ReadToEnd() might block indefinitely - a
NetworkStream doesn't have an end. This plus the read ahead optimisations in
StreamReader causing problems means that you shouldn't use it at all.

  

static void Main()

{

    new Thread(Server).Start(); // Run server method concurrently.

    Thread.Sleep(500); // Give server time to start.

    Client();

  

    Console.Read();

}

static void Client()

{

    using (TcpClient client = new TcpClient("localhost", 51111))

    using (NetworkStream n = client.GetStream())

    {

        BinaryWriter w = new BinaryWriter(n);

        w.Write("Hello");

        w.Flush();

        Console.WriteLine(new BinaryReader(n).ReadString());

    }

}

static void Server() // Handles a single client request, then exits.

{

    TcpListener listener = new TcpListener(IPAddress.Any, 51111);

    listener.Start();

    using (TcpClient c = listener.AcceptTcpClient())

    using (NetworkStream n = c.GetStream())

    {

        string msg = new BinaryReader(n).ReadString();

        BinaryWriter w = new BinaryWriter(n);

        w.Write(msg + " right back!");

        w.Flush(); // Must call Flush because we're not

    } // disposing the writer.

    listener.Stop();

}

  


---
### NOTE ATTRIBUTES
>Created Date: 2017-02-03 19:17:23  
>Last Evernote Update Date: 2017-02-03 19:34:15  
>author: simonjstanford@gmail.com  
>source: desktop.win  
>source-application: evernote.win32  