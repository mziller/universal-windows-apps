Using requestAnimationFrame for power efficient animations sample
=================================================================

This sample demonstrates how to use the [requestAnimationFrame](http://msdn.microsoft.com/library/windows/apps/hh920765) method in an HTML5 Canvas to build smooth and power efficient animations in your Windows Store app using JavaScript.

The [requestAnimationFrame](http://msdn.microsoft.com/library/windows/apps/hh920765) API is the best way to do non-declarative animations in a power efficient and smooth way. This API is similar to the [**setTimeout**](http://msdn.microsoft.com/library/windows/apps/hh453490) and [**setInterval**](http://msdn.microsoft.com/library/windows/apps/hh453487) APIs that developers use today, except that it notifies the application when it needs to update the screen, and only when it needs to update the screen. It keeps Windows Store applications using JavaScript perfectly aligned with the painting of the window, and uses only the necessary amount of graphics resources (which is ideal for low power settings and Connected Standby devices). This API will take page visibility and the display refresh rate into account to determine how many frames per second to allocate to the animations.

Until now, HTML and JavaScript did not provide an efficient means for web developers to schedule graphics timers for animations. Animations are commonly overdrawing – causing choppier animations and increased power consumption. Further efficiency is lost as animations are drawn without knowledge of whether the page is visible to the user. For example, most animations use a timer period of less than 16.7ms to draw animations, even though most monitors can only display at 60Hz frequency or 16.7ms periods.

For example, using [**setTimeout**](http://msdn.microsoft.com/library/windows/apps/hh453490) with a 10ms period results in every third callback not being painted, as another callback occurs prior to the display refresh. This overdrawing results in not only choppy animations, as every third frame being lost, but an overall increased resource consumption.

In this example, the clock is animated using HTML5 Canvas and the [requestAnimationFrame](http://msdn.microsoft.com/library/windows/apps/hh920765) API.

Related topics
--------------

[requestAnimationFrame](http://msdn.microsoft.com/library/windows/apps/hh920765)

Operating system requirements
-----------------------------

Client

Windows 10

Build the sample
----------------

1.  Start Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2.  Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio 2015 Solution (.sln) file.
3.  Press F7 or use **Build** \> **Build Solution** to build the sample.

Run the sample
--------------

To debug the app and then run it, press F5 or use **Debug** \> **Start Debugging**. To run the app without debugging, press Ctrl+F5 or use **Debug** \> **Start Without Debugging**.

