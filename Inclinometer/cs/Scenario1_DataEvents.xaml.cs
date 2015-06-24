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

namespace InclinometerCS
{
    public sealed partial class Scenario1_DataEvents : Page
    {
        // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
        // as NotifyUser()
        MainPage rootPage = MainPage.Current;

        private Inclinometer _inclinometer;
        private uint _desiredReportInterval;

        public Scenario1_DataEvents()
        {
            this.InitializeComponent();

            _inclinometer = Inclinometer.GetDefault();
            if (_inclinometer != null)
            {
                // Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                // This value will be used later to activate the sensor.
                uint minReportInterval = _inclinometer.MinimumReportInterval;
                _desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;
            }
            else
            {
                rootPage.NotifyUser("No inclinometer found", NotifyType.ErrorMessage);
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ScenarioEnableButton.IsEnabled = true;
            ScenarioDisableButton.IsEnabled = false;
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
                Window.Current.VisibilityChanged -= new WindowVisibilityChangedEventHandler(VisibilityChanged);
                _inclinometer.ReadingChanged -= new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);

                // Restore the default report interval to release resources while the sensor is not in use
                _inclinometer.ReportInterval = 0;
            }

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// This is the event handler for VisibilityChanged events. You would register for these notifications
        /// if handling sensor data when the app is not visible could cause unintended actions in the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Event data that can be examined for the current visibility state.
        /// </param>
        private void VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if (ScenarioDisableButton.IsEnabled)
            {
                if (e.Visible)
                {
                    // Re-enable sensor input (no need to restore the desired reportInterval... it is restored for us upon app resume)
                    _inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);
                }
                else
                {
                    // Disable sensor input (no need to restore the default reportInterval... resources will be released upon app suspension)
                    _inclinometer.ReadingChanged -= new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }

        /// <summary>
        /// This is the event handler for ReadingChanged events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ReadingChanged(object sender, InclinometerReadingChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                InclinometerReading reading = e.Reading;
                ScenarioOutput_X.Text = String.Format("{0,5:0.00}", reading.PitchDegrees);
                ScenarioOutput_Y.Text = String.Format("{0,5:0.00}", reading.RollDegrees);
                ScenarioOutput_Z.Text = String.Format("{0,5:0.00}", reading.YawDegrees);
                switch (reading.YawAccuracy)
                {
                    case MagnetometerAccuracy.Unknown:
                        ScenarioOutput_YawAccuracy.Text = "Unknown";
                        break;
                    case MagnetometerAccuracy.Unreliable:
                        ScenarioOutput_YawAccuracy.Text = "Unreliable";
                        break;
                    case MagnetometerAccuracy.Approximate:
                        ScenarioOutput_YawAccuracy.Text = "Approximate";
                        break;
                    case MagnetometerAccuracy.High:
                        ScenarioOutput_YawAccuracy.Text = "High";
                        break;
                    default:
                        ScenarioOutput_YawAccuracy.Text = "No data";
                        break;
                }
            });
        }

        /// <summary>
        /// This is the click handler for the 'Enable' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScenarioEnable(object sender, RoutedEventArgs e)
        {
            if (_inclinometer != null)
            {
                // Establish the report interval
                _inclinometer.ReportInterval = _desiredReportInterval;

                Window.Current.VisibilityChanged += new WindowVisibilityChangedEventHandler(VisibilityChanged);
                _inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);

                ScenarioEnableButton.IsEnabled = false;
                ScenarioDisableButton.IsEnabled = true;
            }
            else
            {
                rootPage.NotifyUser("No inclinometer found", NotifyType.ErrorMessage);
            }
        }

        /// <summary>
        /// This is the click handler for the 'Disable' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScenarioDisable(object sender, RoutedEventArgs e)
        {
            Window.Current.VisibilityChanged -= new WindowVisibilityChangedEventHandler(VisibilityChanged);
            _inclinometer.ReadingChanged -= new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);

            // Restore the default report interval to release resources while the sensor is not in use
            _inclinometer.ReportInterval = 0;

            ScenarioEnableButton.IsEnabled = true;
            ScenarioDisableButton.IsEnabled = false;
        }
    }
}
