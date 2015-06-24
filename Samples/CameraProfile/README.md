CameraProfile Sample
--------------------

This sample demonstrates a new extension to Windows.Media.Capture.MediaCaptureInitializationSettings API. This new API allows for application
developer to query a device for a collection of media types that can work together on a given device called a Video Profile. These new Video Profiles 
expose the capabilities of the capture device which the developer can use to set MediaCaptureInitializationSettings to the desired capabilities. In 
addition the developer can query the driver to see if it supports additional features available through custom profiles.

This sample covers:

Scenario 1: Locate a Record Specific Profile: You can use profiles to verify if a camera supports a specific resolution or 
custom setting via querying for video profile. We demonstrate two methods:
     1)  When you choose "Find 640x480 30 FPS Recording Profile" button, we determine if the back video capture device supports
     a camera profile with a 640x480(WVGA) 30 FPS resolution. We first check if the back video capture device supports a Video 
     Profile. We iterate through all the profiles the device supports to demonstrate available Video Profiles on the device. Then
     we search for the 640x480(WVGA) 30 FPS profile. If located, we initialize Media Capture Settings with this profile. 
     2) When you choose the "Find Custom Recording Profile" button, we are looking to see if a device supports a specific Custom 
     Profile. The custom profile would allow the camera driver to optimize for additional features. For this demonstration we use
     a static profile for 640x480 30 FPS that is avaliable in the phone emulators. 

Scenario 2: Query Profile for Concurrency: This scenarios demonstrates using profiles to determine if a device is capable of streaming
from both the front and rear video capture devices at the same time. 
    1) When you choose "Query for Concurrent Profile button, the app queries for a front and back device that supports a video profile. If a profile
     is supported on both devices we then check the devices for profiles that support concurrency. From the available profiles we look for a concurrent profile match on both 
     devices. If a concurrent profile match is found, we initialize both front and back Media Capture settings of the devices to the concurrency profile.
     
Scenario 3: Query Profile for Hdr Support: This scenarios demonstrates using Camera Profile to determine if a device is capable of supporting 
Hdr Video.
    1) When you choose "Query Profile for HDR Support" button, the app will query the if the back video capture device supports a Video Profile. Then we query the available profiles
    to see if Hdr Video is supported calling the IsHdrVideoSupported() method. If so, we set Media Capture settings to the Hdr supported video profile and set Hdr Video mode to auto.

Related topics
--------------
[Windows.Media.Capture.MediaCapture namespace] (https://msdn.microsoft.com/en-us/library/windows/apps/windows.media.devices.aspx)
[Windows.Devices.Enumeration namespace] (https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.aspx)

**Reference**

[Windows.Media.Capture.MediaCaptureInitializationSettings] (https://msdn.microsoft.com/en-us/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.mediacaptureinitializationsettings.aspx) 
[Windows.Media.Capture.MediaCaptureInitilizationSettings.VideoDeviceId](https://msdn.microsoft.com/en-us/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.videodeviceid.aspx)
[Windows.Devices.Enumeration.DeviceInformation class](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.enumeration.deviceinformation.aspx)


System requirements
-----------------------------
Camera that supports Video Profiles
Client
Windows 10
Windows Phone 10

Build the sample
----------------

1.  Start Visual Studio 2015 and select **File** \> **Open** \> **Project/Solution**.
2.  Go to the directory to which you unzipped the sample. Then go to the subdirectory containing the sample in the language you desire - either C++, C\#, or JavaScript. Double-click the Visual Studio 2015 Solution (.sln) file.
3.  Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

Run the sample
--------------

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

**Deploying the sample**
1.  Select **Build** \> **Deploy Solution**.

**Deploying and running the sample**
1.  To debug the sample and then run it, press F5 or select **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or select **Debug** \> **Start Without Debugging**.


