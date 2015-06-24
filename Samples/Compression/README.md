Compression sample
==================

This sample demonstrates how to read structured data from a file and write compressed data to a new file and how to read compressed data and write decompressed data to a new file.

**Note**  This sample was created using one of the universal app templates available in Visual Studio. It shows how its solution is structured so it can run on both mobile and desktop Windows 10. For more info about how to build a Windows 10 universal app, see [Build a Windows 10 universal app](http://msdn.microsoft.com/library/windows/apps/dn609832).

Many apps need to compress and decompress data. The [**Windows.Storage.Compression**](http://msdn.microsoft.com/library/windows/apps/br207698) namespace simplifies this task by providing a unified interface that exposes the MSZIP, XPRESS, XPRESS\_HUFF, and LZMS compression algorithms. This lets you manage versions, service, and extend the exposed compression algorithms and frees you from responsibility for managing block sizes, compression parameters, and other details that the native [Compression API](http://msdn.microsoft.com/library/windows/apps/hh437596) requires. A subset of [Win32 and COM for apps](http://go.microsoft.com/fwlink/p/?linkid=246262) can be used by apps to support scenarios not already covered by the Windows Runtime, HTML/Cascading Style Sheets (CSS), or other supported languages or standards. For this purpose, you can also use the native Compression API to develop apps.

Specifically, this sample shows the following:

-   Read uncompressed data from an existing file
-   Specify the compression algorithm to use.
-   Compress the data using the selected compression algorithm.
-   Write the compressed data to a new file.
-   Read the compressed data from a file.
-   Decompress the data.

To obtain the Windows 10 developer tools preview, go to [Windows 10 developer tools](https://dev.windows.com/en-us/downloads/windows-10-developer-tools).

Operating system requirements
-----------------------------

Client

Windows 10

Server

Windows Server 2012 R2

Phone

Windows 10 Mobile

Build the sample
----------------

1.  Start Visual Studio 2015 RC and select **File** \> **Open** \> **Project/Solution**.
2.  Go to the directory to which you unzipped the sample. Then go to the subdirectory named for the sample and double-click the Visual Studio 2015 RC Solution (.sln) file.
3.  Follow the steps for the version of the sample you want:
    -   To build the sample:

        1.  Select **Compression** in **Solution Explorer**.
        2.  Press Ctrl+Shift+B, or use **Build** \> **Build Solution**, or use **Build** \> **Build Compression**.

Run the sample
--------------

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

**Deploying the sample**

-   To deploy the built sample:

    1.  Select **Compression** in **Solution Explorer**.
    2.  Use **Build** \> **Deploy Solution** or **Build** \> **Deploy Compression**.

**Deploying and running the sample**

-   To deploy and run the sample:

    1.  Right-click **Compression** in **Solution Explorer** and select **Set as StartUp Project**.
    2.  To debug the sample and then run it, press F5 or use **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or use **Debug** \> **Start Without Debugging**.
-   To deploy and run the Windows Phone version of the sample:

