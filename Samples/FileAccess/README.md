﻿# File access sample

This sample shows how to create, read, write, copy and delete a file, how to retrieve file properties, and how to track a file or folder so that your app can access it again. This sample uses [**Windows.Storage**](http://msdn.microsoft.com/library/windows/apps/br227346) and [**Windows.Storage.AccessCache**](http://msdn.microsoft.com/library/windows/apps/br207498) API.

The sample demonstrates these tasks:

1.  **Create a file in the Pictures library**

    Uses one of the [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230).[**CreateFileAsync**](http://msdn.microsoft.com/library/windows/apps/br227249) methods to create the file.

2.  **Get a file's parent folder**

    Uses the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**GetParentAsync**](http://msdn.microsoft.com/library/windows/apps/dn298477) method to get the parent folder of the file that was created in the Picture folder. The app has the Pictures library capability, so it can access the folder where the file was created.

3.  **Write and read text in a file**

    Uses the [**FileIO**](http://msdn.microsoft.com/library/windows/apps/hh701440).[**WriteTextAsync**](http://msdn.microsoft.com/library/windows/apps/hh701505) and [**FileIO**](http://msdn.microsoft.com/library/windows/apps/hh701440).[**ReadTextAsync**](http://msdn.microsoft.com/library/windows/apps/hh701482) methods to write and read the file. For a walkthrough of this task, see Quickstart: reading and writing a file ([HTML](http://msdn.microsoft.com/library/windows/apps/hh464978) or [XAML](http://msdn.microsoft.com/library/windows/apps/hh758325)).

4.  **Write and read bytes in a file**

    Uses the [**FileIO**](http://msdn.microsoft.com/library/windows/apps/hh701440).[**WriteBufferAsync**](http://msdn.microsoft.com/library/windows/apps/hh701490) and [**FileIO**](http://msdn.microsoft.com/library/windows/apps/hh701440).[**ReadBufferAsync**](http://msdn.microsoft.com/library/windows/apps/hh701468) methods to write and read the file. For a walkthrough of this task, see Quickstart: reading and writing a file ([HTML](http://msdn.microsoft.com/library/windows/apps/hh464978) or [XAML](http://msdn.microsoft.com/library/windows/apps/hh758325)).

5.  **Write and read a file using a stream**

    Uses the following API to write and read the file using a stream.

    -   [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**OpenTransactedWriteAsync**](http://msdn.microsoft.com/library/windows/apps/hh996766) method
    -   [**DataWriter**](http://msdn.microsoft.com/library/windows/apps/br208154) class
    -   [**DataReader**](http://msdn.microsoft.com/library/windows/apps/br208119) class

    For a walkthrough of this task, see Quickstart: reading and writing a file ([HTML](http://msdn.microsoft.com/library/windows/apps/hh464978) or [XAML](http://msdn.microsoft.com/library/windows/apps/hh758325)).

6.  **Display file properties**

    Uses the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**GetBasicPropertiesAsync**](http://msdn.microsoft.com/library/windows/apps/hh701737) method and the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**Properties**](http://msdn.microsoft.com/library/windows/apps/br227225) property to get the properties of the file.

7.  **Track a file or folder so that you can access it later (persisting access)**

    Uses the [**StorageApplicationPermissions**](http://msdn.microsoft.com/library/windows/apps/br207456).[**FutureAccessList**](http://msdn.microsoft.com/library/windows/apps/br207457) and [**StorageApplicationPermissions**](http://msdn.microsoft.com/library/windows/apps/br207456).[**MostRecentlyUsedList**](http://msdn.microsoft.com/library/windows/apps/br207458) properties to remember a file or folder so that it can be accessed later.

    For a walkthrough of this task, see [How to track recently used files and folders](http://msdn.microsoft.com/library/windows/apps/hh972603) (HTML or [XAML](http://msdn.microsoft.com/library/windows/apps/hh972344)).

    Note that the "Add to system MRU" feature crashes on Phone. We apologize for the inconvenience.

8.  **Copy a file**

    Uses one of the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**CopyAsync**](http://msdn.microsoft.com/library/windows/apps/br227190) methods to copy the file.

9.  **Compare two files to see if they're the same**

    Uses the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**IsEqual**](http://msdn.microsoft.com/library/windows/apps/dn298484) method to compare two files.

10. **Delete a file**

    Uses one of the [**StorageFile**](http://msdn.microsoft.com/library/windows/apps/br227171).[**DeleteAsync**](http://msdn.microsoft.com/library/windows/apps/br227199) methods to delete the file.

11. **Try to get a file without getting an error**

    Uses the [**StorageFolder**](http://msdn.microsoft.com/library/windows/apps/br227230).[**TryGetItemAsync**](http://msdn.microsoft.com/library/windows/apps/dn251721) method to get a file without raising an exception.

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

*Note**  If you want to learn about accessing files using a file picker, see Quickstart: Accessing files with file pickers ([HTML](http://msdn.microsoft.com/library/windows/apps/hh465199) or [XAML](http://msdn.microsoft.com/library/windows/apps/hh771180)).

### Samples

[File picker sample](http://go.microsoft.com/fwlink/p/?linkid=231464)

[Folder enumeration sample](http://go.microsoft.com/fwlink/p/?linkid=231512)

[Programmatic file search sample](http://go.microsoft.com/fwlink/p/?linkid=231532)

[File and folder thumbnail sample](http://go.microsoft.com/fwlink/p/?linkid=231522)

## Reference

[**Windows.Storage namespace**](http://msdn.microsoft.com/library/windows/apps/br227346)

[**Windows.Storage.AccessCache namespace**](http://msdn.microsoft.com/library/windows/apps/br207498)

[**Windows.Storage.FileProperties**](http://msdn.microsoft.com/library/windows/apps/br207831)

[**Windows.Storage.Streams namespace**](http://msdn.microsoft.com/library/windows/apps/br241791)

## System requirements

**Client:** Windows 10 Technical Preview

**Server:** Windows 10 Technical Preview

**Phone:** Windows 10 Technical Preview

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

