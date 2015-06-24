# Magnetic Stripe Reader Sample

This sample shows how to create a magnetic stripe reader, claim it for exclusive use, enable it to receive data, and read data from a bank card or a motor vehicle card. This sample uses [**Windows.Devices.PointOfService**](http://msdn.microsoft.com/library/windows/apps/dn298071) API.

Specifically, this sample shows how to:

1.  **Get the magnetic stripe reader**

    Uses the [**MagneticStripeReader.GetDefaultAsync**](http://msdn.microsoft.com/library/windows/apps/dn297987) method to get the first available magnetic stripe reader.

2.  **Claim the magnetic stripe reader for exclusive use**

    Uses [**ClaimReaderAsync**](http://msdn.microsoft.com/library/windows/apps/dn297979) to claim the device.

3.  **Add event handlers**

    Uses [**BankCardDataReceived**](http://msdn.microsoft.com/library/windows/apps/dn278599), [**AamvaCardDataReceived**](http://msdn.microsoft.com/library/windows/apps/dn278595), and [**ReleaseDeviceRequested**](http://msdn.microsoft.com/library/windows/apps/dn278626) events.

    When an application gets a request from another application to release its exclusive claim to the magnetic stripe reader, it must handle the request by retaining the device; otherwise, it will lose its claim. The event handler for [**ReleaseDeviceRequested**](http://msdn.microsoft.com/library/windows/apps/dn278626) shows how to do this.

4.  **Enable the device to receive data**

    Uses [**EnableAsync**](http://msdn.microsoft.com/library/windows/apps/dn278612).

The app package manifest shows how to specify the device capability name for the Point of Service (POS) devices. All POS apps are required declare [**DeviceCapability**](http://msdn.microsoft.com/library/windows/apps/br211430) in the app package manifest, either by using "PointofService" as shown in this sample or by using device specific GUID, such as "2A9FE532-0CDC-44F9-9827-76192F2CA2FB" for a magnetic stripe reader.

The following list shows the magnetic stripe readers that were used with this code sample:

-   MagTek MagneSafe HID USB reader (VID 0801, PID 0011)
-   MagTek SureSwipe HID USB reader ( VID 0801, PID 0002)
-   MagTek BulleT Bluetooth/USB reader, when connected via USB (VID 0801, PID 0011)
-   ID TECH SecureMag HID USB reader (VID 0ACD, PID 2010)
-   ID TECH MiniMag HID USB reader (VID 0ACD, PID 0500)

**Note** The Windows universal samples require Visual Studio 2015 to build and Windows 10 to execute.
 
To obtain information about Windows 10, go to [Windows 10](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio 2015 and the tools for developing Windows apps, go to [Visual Studio 2015](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Magnetic Stripe Reader sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/MagneticStripeReader)

### Reference

[Windows.Devices.PointOfService](http://msdn.microsoft.com/library/windows/apps/dn298071)

[Windows app samples](http://go.microsoft.com/fwlink/p/?LinkID=227694)

## System requirements

**Client:** Windows 10 Technical Preview

**Server:** Windows 10 Technical Preview

**Phone:**  Windows 10 Technical Preview

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
