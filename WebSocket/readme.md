WebSocket sample
================

This sample shows you how to send and receive date using the WebSocket classes in the [**Windows.Networking.Sockets**](http://msdn.microsoft.com/library/windows/apps/br226960) namespace in your Windows Runtime app.The sample covers basic features that include making a WebSocket connection, sending and receiving data, and closing the connection. The sample also shows recommended ways of handling both trusted (hard coded) URI inputs and unvalidated (user-entered) URI inputs.

**Note**  This sample was created using one of the universal app templates available in Visual Studio. It shows how its solution is structured so it can run on Windows 10 Technical Preview. For more info about how to build apps that target Windows and Windows Phone with Visual Studio, see [Build apps that target Windows 10 Technical Preview by using Visual Studio](http://msdn.microsoft.com/library/windows/apps/dn609832).

Windows 10 Technical Preview provides support for the client use of WebSockets in a Windows Runtime. The [**Windows.Networking.Sockets**](http://msdn.microsoft.com/library/windows/apps/br226960) namespace defines two types of WebSocket objects for use by clients in Windows Store apps.

-   [**MessageWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226842) is suitable for typical scenarios where messages are not extremely large. Both UTF-8 and binary messages are supported.
-   [**StreamWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226923) is more suitable for scenarios in which large files (such as photos or movies) are being transferred, allowing sections of a message to be read with each read operation rather than reading the entire message at once. Only binary messages are supported.

Both [**MessageWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226842) and [**StreamWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226923) connections are demonstrated in this sample. This sample shows how to use the following features:

-   Use a [**MessageWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226842) to send UTF-8 text messages. The server will echo the messages back.
-   Use a [**StreamWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226923) to send binary data. The server will echo the binary data back.

**Note**  The Windows version of this sample by default requires network access using the loopback interface.

**Network capabilities**

This sample requires that network capabilities be set in the *Package.appxmanifest* file to allow the app to access the network at runtime. These capabilities can be set in the app manifest using Microsoft Visual Studio.

-   **Private Networks (Client & Server)**: The sample has inbound and outbound network access on a home or work network (a local intranet). Even though this sample by default runs on loopback, it needs either the **Private Networks (Client & Server)** or **Internet (Client)** capability in order to access the network and send and receive data. The **Private Networks (Client & Server)** capability is represented by the **Capability name = "privateNetworkClientServer"** tag in the app manifest.

-   If the sample is modified to connect to the server component running on a different device on the Internet (a more typical app), the **Internet (Client)** capability must be set for the client component. This is represented by the **Capability name = "internetClient"**.

Related topics
--------------

**Other resources**

[Adding support for networking](http://msdn.microsoft.com/library/windows/apps/hh452752)

[Connecting with WebSockets](http://msdn.microsoft.com/library/windows/apps/hh761442)

[How to configure network capabilities](http://msdn.microsoft.com/library/windows/apps/hh770532)

[How to connect with a MessageWebSocket](http://msdn.microsoft.com/library/windows/apps/hh761443)

[How to connect with a StreamWebSocket](http://msdn.microsoft.com/library/windows/apps/hh761445)

[Windows 8 app samples](http://go.microsoft.com/fwlink/p/?LinkID=227694)

**Reference**

[**MessageWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226842)

[**StreamWebSocket**](http://msdn.microsoft.com/library/windows/apps/br226923)

[**Windows.Networking.Sockets**](http://msdn.microsoft.com/library/windows/apps/br226960)

Related technologies
--------------------

[**Windows.Networking.Sockets**](http://msdn.microsoft.com/library/windows/apps/br226960)

Operating system requirements
-----------------------------

Client

Windows 10 Technical Preview

Server

Windows 10 Technical Preview

Phone

Windows 10 Technical Preview

Build the sample
----------------

1.  Start Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2.  Go to the directory to which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio 2015 Solution (.sln) file.
3.  Press Ctrl+Shift+B, or use **Build** \> **Build Solution**

Run the sample
--------------

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

**Deploying the sample**

-   To deploy the sample: Use **Build** \> **Deploy Solution**


**Deploying and running the Windows version of the sample**

-   To deploy and run the sample: Press F5 or use **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or use **Debug** \> **Start Without Debugging**.


For the app to attempt a WebSocket connection, this sample requires that a web server is available that supports WebSockets. The web server must also have a *WebSocketSample* path available to access. The web server must be started before the app is run. The sample includes a PowerShell script that will install and enable IIS on a local computer and enable WebSocket connections. The easiest way to run the sample is to use the provided web server scripts. The PowerShell script that will install IIS on the local computer, create the *WebSocketSample* folder on the server, copy files to this folder, and enable IIS.

Browse to the *Server* folder in your sample folder to setup and start the web server. There are two options possible.

-   Start PowerShell elevated (Run as administrator) and run the following command:

    **.\\SetupServer.ps1**

    Note that you may also need to change script execution policy.

-   Start an elevated Command Prompt (Run as administrator) and run following command:

    **PowerShell.exe -ExecutionPolicy Unrestricted -File SetupServer.ps1**

When the web server is not needed anymore, please browse to the *Server* folder in you sample folder and run one of the following:

-   Start PowerShell elevated (Run as administrator) and run the following command:

    **.\\RemoveServer.ps1**

    Note that you may also need to change script execution policy.

-   Start an elevated Command Prompt (Run as administrator) and run following command:

    **PowerShell.exe -ExecutionPolicy Unrestricted -File RemoveServer.ps1**

The sample can run using any web server, not only the one provided with the sample. If IIS is used on a different computer, then the previous scripts can be used with minor changes.

-   Copy the *Server* folder to the device where IIS will be run.
-   Run the above scripts to install and enable IIS and enable WebSocket connections.

The sample must also be updated when run against a non-localhost web server. To configure the sample for use with IIS on a different device:

-   Additional capabilities may need to be added to the app manifest for the sample. For example, **Internet (Client & Server)** if the web server is located on the Internet not on a local intranet.
-   The hostname of the server to connect to also needs to be updated. This can be handled in two ways. The **ServerAddressField** element in the HTML or XAML files can be edited so that "localhost" is replaced by the hostname or IP address of the web server. Alternately when the app is run, enter the hostname or IP address of the web server instead of the default "localhost" value in the **Server Address** field.

**Note**  IIS is not available on ARM builds nor on Windows Phone. Instead, set up the web server on a separate 64-bit or 32-bit computer and follow the steps for using the sample against non-localhost web server.

However if a server different than IIS is used, then this requires some special configuration of the server.

-   Copy the *Server\\webSite* directory to the *WebSocketSample* folder on the web server.
-   Configure the web server to accept WebSocket connections.

To configure the sample for use with a web server different than IIS not using localhost:

-   Additional capabilities may need to be added to the app manifest for the sample. For example, **Internet (Client & Server)** if the web server is located on the Internet not on a local intranet.
-   The URI of the server to connect to also needs to be updated. This can be handled in two ways. The **ServerAddressField** element in the HTML or XAML files can be edited so that "localhost" is replaced by the hostname or IP address of the web server. Alternately when the app is run, enter the hostname or IP address of the web server instead of the default "localhost" value in the **Server Address** field.

**Deploying and running the Windows Phone version of the sample**

IIS is not available on Windows Phone. For the app to attempt a WebSocket connection to a server that supports WebSockets , there are two options:

-   The easiest way to run the sample is to use the provided web server scripts on a separate 64-bit or 32-bit device that can run IIS. Follow the instructions for deploying and running the Windows version of the sample using IIS on a different device.
-   Use a web server different than IIS on a separate device. Follow the instructions for deploying and running the Windows version of the sample using a non-IIS web server.
