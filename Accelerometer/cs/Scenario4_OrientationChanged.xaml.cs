﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SDKTemplate;
using System;
using Windows.Devices.Sensors;
using Windows.Foundation;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.Graphics.Display;

namespace AccelerometerCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Scenario4_OrientationChanged : Page
    {
        // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
        // as NotifyUser()
        MainPage rootPage = MainPage.Current;

        Accelerometer accelerometerOriginal;
        Accelerometer accelerometerReadingTransform;
        DisplayInformation displayInformation;

        public Scenario4_OrientationChanged()
        {
            this.InitializeComponent();

            // Get two instances of the accelerometer:
            // One that returns the raw accelerometer data
            accelerometerOriginal = Accelerometer.GetDefault();
            // Other on which the 'ReadingTransform' is updated so that data returned aligns with the request transformation.
            accelerometerReadingTransform = Accelerometer.GetDefault();

            if(accelerometerOriginal == null || accelerometerReadingTransform == null)
            {
                rootPage.NotifyUser("No accelerometer found", NotifyType.ErrorMessage);
            }
            displayInformation = DisplayInformation.GetForCurrentView();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (accelerometerOriginal == null || accelerometerReadingTransform == null)
            {
                ScenarioEnableButton.IsEnabled = false;
            }
            else
            {
                ScenarioEnableButton.IsEnabled = true;
            }
            ScenarioDisableButton.IsEnabled = false;

            // Register for orientation change
            displayInformation.OrientationChanged += displayInformation_OrientationChanged;
        }

        /// <summary>
        /// Invoked immediately before the Page is unloaded and is no longer the current source of a parent Frame.
        /// </summary>
        /// <param name="e">
        /// Event data that can be examined by overriding code. The event data is representative
        /// of the navigation that will unload the current Page unless canceled. The
        /// navigation can potentially be canceled by setting Cancel.
        /// </param>
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (ScenarioDisableButton.IsEnabled)
            {
                Window.Current.VisibilityChanged -= Current_VisibilityChanged;
                accelerometerOriginal.ReadingChanged -= _accelerometerOriginal_ReadingChanged;
                accelerometerReadingTransform.ReadingChanged -= _accelerometerReadingTransform_ReadingChanged;

                // Restore the default report interval to release resources while the sensor is not in use
                accelerometerOriginal.ReportInterval = 0;
                accelerometerReadingTransform.ReportInterval = 0;
            }

            displayInformation.OrientationChanged -= displayInformation_OrientationChanged;

            base.OnNavigatingFrom(e);
        }


        /// <summary>
        /// Invoked when there is a change in the display orientation.
        /// </summary>
        /// <param name="sender">
        /// DisplayInformation object from which the new Orientation can be determined
        /// </param>
        /// <param name="e"></param>
        void displayInformation_OrientationChanged(DisplayInformation sender, object args)
        {
            if (null != accelerometerReadingTransform)
            {
                accelerometerReadingTransform.ReadingTransform = sender.CurrentOrientation;
            }
        }

        /// <summary>
        /// This is the click handler for the 'Enable' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ScenarioEnable(object sender, RoutedEventArgs e)
        {
            // Establish the report interval
            accelerometerOriginal.ReportInterval = accelerometerOriginal.MinimumReportInterval;
            accelerometerReadingTransform.ReportInterval = accelerometerReadingTransform.MinimumReportInterval;

            // Establish the ReadingTransform to align with the current display orientation, so 
            // that the accelerometer data from 'accelerometerReadingTransform' will align with the 
            // current display orientation
            accelerometerReadingTransform.ReadingTransform = displayInformation.CurrentOrientation;

            Window.Current.VisibilityChanged += Current_VisibilityChanged;
            accelerometerOriginal.ReadingChanged += _accelerometerOriginal_ReadingChanged;
            accelerometerReadingTransform.ReadingChanged += _accelerometerReadingTransform_ReadingChanged;

            ScenarioEnableButton.IsEnabled = false;
            ScenarioDisableButton.IsEnabled = true;
        }


        /// <summary>
        /// This is the event handler for ReadingChanged event of the 'accelerometerOriginal' and should 
        /// notify of the accelerometer reading changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">
        /// Event data represents the accelerometer reading in its original reference frame.
        /// </param>
        async void _accelerometerOriginal_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = args.Reading;
                ScenarioOutput_X_Original.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                ScenarioOutput_Y_Original.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                ScenarioOutput_Z_Original.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);
            });
        }
        

        /// <summary>
        /// This is the event handler for ReadingChanged event of the 'accelerometerReadingTransform' and should 
        /// notify of the accelerometer reading changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">
        /// Event data represents the accelerometer reading in its original reference frame.
        /// </param>
        async void _accelerometerReadingTransform_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                AccelerometerReading reading = args.Reading;
                ScenarioOutput_X_ReadingTransform.Text = String.Format("{0,5:0.00}", reading.AccelerationX);
                ScenarioOutput_Y_ReadingTransform.Text = String.Format("{0,5:0.00}", reading.AccelerationY);
                ScenarioOutput_Z_ReadingTransform.Text = String.Format("{0,5:0.00}", reading.AccelerationZ);
            });
        }

        /// <summary>
        /// This is the event handler for VisibilityChanged events. You would register for these notifications
        /// if handling sensor data when the app is not visible could cause unintended actions in the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Event data that can be examined for the current visibility state.
        /// </param>
        void Current_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (ScenarioDisableButton.IsEnabled)
            {
                if (e.Visible)
                {
                    // Re-enable sensor input (no need to restore the desired reportInterval... it is restored for us upon app resume)
                    accelerometerOriginal.ReadingChanged += _accelerometerOriginal_ReadingChanged;
                    accelerometerReadingTransform.ReadingChanged += _accelerometerReadingTransform_ReadingChanged;
                }
                else
                {
                    // Disable sensor input (no need to restore the default reportInterval... resources will be released upon app suspension)
                    accelerometerOriginal.ReadingChanged -= _accelerometerOriginal_ReadingChanged;
                    accelerometerReadingTransform.ReadingChanged -= _accelerometerReadingTransform_ReadingChanged;
                }
            }
        }

        /// <summary>
        /// This is the click handler for the 'Disable' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ScenarioDisable(object sender, RoutedEventArgs e)
        {
            Window.Current.VisibilityChanged -= Current_VisibilityChanged;
            accelerometerOriginal.ReadingChanged -= _accelerometerOriginal_ReadingChanged;
            accelerometerReadingTransform.ReadingChanged -= _accelerometerReadingTransform_ReadingChanged;

            // Restore the default report interval to release resources while the sensor is not in use
            accelerometerOriginal.ReportInterval = 0;
            accelerometerReadingTransform.ReportInterval = 0;

            ScenarioEnableButton.IsEnabled = true;
            ScenarioDisableButton.IsEnabled = false;
        }
    }
}
