# Master/detail sample

This sample shows how to implement a responsive master/detail experience in XAML. In the [master/detail pattern](https://msdn.microsoft.com/en-us/library/windows/apps/dn997765.aspx), a master list is used to select an item that will then appear in a detail view.

When the app view is sufficiently wide, the master list and detail view should appear side by side in the same app page. However, on smaller screen sizes, the two pieces of UI should appear on different pages, allowing the user to navigate between them. This sample shows how to implement these experiences and adaptively switch between them based on the size of the screen.

Specifically, this sample demonstrates:

- **Creating a side-by-side master/detail experience in XAML:** In `MasterDetailPage.xaml`, a master list is used to switch between detail items in a side-by-side view. This page will also responsively update to include just the master list when the view is narrow.
- **Navigating between the master list and a detail view:** At narrow screen sizes, the user can navigate between the master list in `MasterDetailPage.xaml` and detail view in `DetailPage.xaml` to view different items.
- **Changing the navigation model when the app is resized:** This sample contains the code necessary to adaptively switch between the two experiences described above at runtime based on screen size.

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[XAML Responsive Techniques](https://github.com/Microsoft/Windows-universal-samples/tree/master/xaml_responsivetechniques)

[Tailored Multiple Views](https://github.com/Microsoft/Windows-universal-samples/tree/master/xaml_tailoredmultipleviews/)

### Reference

[VisualState](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.visualstate.aspx)

[NavigationThemeTransition](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.media.animation.navigationthemetransition.aspx)


## System requirements

**Client:** Windows 10 Insider Preview

**Server:** Windows 10 Insider Preview

**Phone:**  Windows 10 Insider Preview

## Build the sample

1. Start Microsoft Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2. Go to the directory to which you unzipped the sample. Then go to the subdirectory containing the sample in the language you desire - either C++, C#, or JavaScript. Double-click the Visual Studio 2015 Solution (.sln) file. 
3. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**. 

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select Build > Deploy Solution. 

### Deploying and running the sample

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or selectDebug > Start Without Debugging. 
