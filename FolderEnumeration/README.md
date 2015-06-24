﻿# Folder enumeration sample

This sample shows how to enumerate the top-level files and folders inside a location (like a folder, device, or network location), and how to use queries to enumerate all files inside a location by sorting them into file groups.

This sample uses [**Windows.Storage**](http://msdn.microsoft.com/library/windows/apps/br227346) and [**Windows.Storage.Search**](http://msdn.microsoft.com/library/windows/apps/br208106) APIs, including [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230) and [**StorageFolderQueryResult**](http://msdn.microsoft.com/library/windows/apps/br208066).

The sample demonstrates these tasks:

1.  **Enumerate top-level files and subfolders of a folder**

    Uses the [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230).[**GetFilesAsync**](http://msdn.microsoft.com/library/windows/apps/br227273) and **StorageFolder**.[**GetFoldersAsync**](http://msdn.microsoft.com/library/windows/apps/br227279) methods to enumerate only the top-level files and folders (the immediate children) of the location (in this case, the Pictures library). For a walkthrough of this task, see [Quickstart: Accessing files programmatically](http://msdn.microsoft.com/library/windows/apps/jj150596).

2.  **Query all the files in a folder (and its subfolders) and create groups of files to enumerate**

    Uses the [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230).[**CreateFolderQueryWithOptions**](http://msdn.microsoft.com/library/windows/apps/br211592) method to sort all files in the location (in this case, the Pictures library) into groups based on the criteria that you specify and uses a [**StorageFolderQueryResult**](http://msdn.microsoft.com/library/windows/apps/br208066).[**GetFoldersAsync**](http://msdn.microsoft.com/library/windows/apps/br208072) method to retrieve the resulting file groups.

    File groups are virtual folders that are represented by [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230) objects. The files in a file group have the criteria that you specify in common. For example, as the sample shows, the files in a group might have the same rating.

    For a walkthrough of this task, see [Quickstart: Accessing files programmatically](http://msdn.microsoft.com/library/windows/apps/jj150596).

3.  **Query all the files in a folder (and its subfolders) and retrieve file properties as a part of getting results for the query**

    Uses [**QueryOptions**](http://msdn.microsoft.com/library/windows/apps/br207995).[**SetPropertyPrefetch**](http://msdn.microsoft.com/library/windows/apps/hh973319) to specify properties to retrieve when the query is created. [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230).[**CreateFolderQueryWithOptions**](http://msdn.microsoft.com/library/windows/apps/br211592) and [**GetFilesAsync**](http://msdn.microsoft.com/library/windows/apps/br227273) are used to create the query and enumerate results. Similarly, you can use [**SetThumbnailPrefetch**](http://msdn.microsoft.com/library/windows/apps/hh973320) to retrieve thumbnails as a part of creating the query.

    Using [**SetPropertyPrefetch**](http://msdn.microsoft.com/library/windows/apps/hh973319) and [**SetThumbnailPrefetch**](http://msdn.microsoft.com/library/windows/apps/hh973320) might make the query take longer to execute, but will make accessing large amounts of file information more efficient.

4.  **Query all the files in a folder and show file provider and availability**

    Uses the [**Provider**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.provider.aspx) and [**IsAvailable*]() properties to obtain the provider and whether the file is available offline.

Additional important APIs in this sample include:

-   [**CommonFolderQuery**](http://msdn.microsoft.com/library/windows/apps/br207957) enumeration
-   [**CommonFileQuery**](http://msdn.microsoft.com/library/windows/apps/br207956) enumeration
-   [**PropertyPrefetchOptions**](http://msdn.microsoft.com/library/windows/apps/hh973317) enumeration

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Programmatic file search sample](http://go.microsoft.com/fwlink/p/?linkid=231532)

[File access sample](%20http://go.microsoft.com/fwlink/p/?linkid=231445)

[File and folder thumbnail sample](http://go.microsoft.com/fwlink/p/?linkid=231522)

### Reference

[**Windows.Storage namespace**](http://msdn.microsoft.com/library/windows/apps/br227346), [**Windows.Storage.Search namespace**](http://msdn.microsoft.com/library/windows/apps/br208106)

## System requirements

**Client:** Windows 10 Technical Preview

**Server:** Windows 10 Technical Preview

**Phone:** Not supported

## Build the sample

1. Start Microsoft Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2. Go to the directory to which you unzipped the sample. Then go to the subdirectory containing the sample in the language you desire - either C++, C#, or JavaScript. Double-click the Visual Studio 2015 Solution (.sln) file. 
3. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**. 

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select Build > Deploy Solution. 

### Deploying and running the sample

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or select Debug > Start Without Debugging. 
