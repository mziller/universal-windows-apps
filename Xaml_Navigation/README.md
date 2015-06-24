# XAML Navigation Menu sample

This sample demonstrates how to provide a top-level navigation menu to users (a.k.a. a hamburger menu).

Specifically, this sample shows how to:

- **Utilize a SplitView control:** The SplitView is a control with two content areas: the Pane and the Content.  The Pane can be opened or closed.  Using the DisplayMode property the app can switch the Pane to Overlay the Content or appear Inline.  When the available space is constrained the Pane can be put into a CompactOverlay or CompactInline mode where it provides a visual hint to the user. 
- **Customize a ListView to present menu items with a single-selection experience:** This uses a ListView to present the default visuals for the menu items and customizes the keyboarding behavior to provide a single selection model where up/down/tab/shift+tab moves through each item and 'Enter' and 'Space' select the item. 

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Master Detail](https://github.com/Microsoft/Windows-universal-samples/tree/master/xaml_masterdetail)

### Reference

<!-- Add links to related API -->

[SplitView API](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx)

[ListView API](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)

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
