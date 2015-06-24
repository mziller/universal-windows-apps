//*********************************************************
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
using System.Threading.Tasks;
using Windows.Devices.PointOfService;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MagneticStripeReaderSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Scenario1_BankCards : Page
    {
        // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
        // as NotifyUser()
        MainPage rootPage = MainPage.Current;

        MagneticStripeReader _reader = null;
        ClaimedMagneticStripeReader _claimedReader = null;

        public Scenario1_BankCards()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates the default magnetic stripe reader.
        /// </summary>
        /// <returns>true if magnetic stripe reader is created. Otherwise returns false</returns>
        private async Task<bool> CreateDefaultMagneticStripeReaderObject()
        {
            if (_reader == null)
            {
                _reader = await MagneticStripeReader.GetDefaultAsync();

                if (_reader == null)
                {
                    rootPage.NotifyUser("Magnetic Stripe Reader not found. Please connect a Magnetic Stripe Reader.", NotifyType.ErrorMessage);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Claim the magnetic stripe reader
        /// </summary>
        /// <returns>true if claim is successful. Otherwise returns false</returns>
        private async Task<bool> ClaimReader()
        {
            if (_claimedReader == null)
            {
                // claim the magnetic stripe reader
                _claimedReader = await _reader.ClaimReaderAsync();

                if (_claimedReader == null)
                {
                    rootPage.NotifyUser("Claim Magnetic Stripe Reader failed.", NotifyType.ErrorMessage);
                    return false;
                }
            }
            return true;
        }

        private async void ScenarioStartReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CreateDefaultMagneticStripeReaderObject())
            {
                if (_reader != null)
                {
                    // after successful creation, claim the reader for exclusive use and enable it so that data reveived events are received.
                    if (await ClaimReader())
                    {
                        if (_claimedReader != null)
                        {
                            // It is always a good idea to have a release device requested event handler. If this event is not handled, there is a chance that another app can 
                            // claim ownsership of the magnetic stripe reader.
                            _claimedReader.ReleaseDeviceRequested += OnReleaseDeviceRequested;

                            // after successfully claiming and enabling, attach the BankCardDataReceived event handler.
                            // Note: If the scanner is not enabled (i.e. EnableAsync not called), attaching the event handler will not be of any use because the API will not fire the event 
                            // if the claimedScanner has not beed Enabled
                            _claimedReader.BankCardDataReceived += OnBankCardDataReceived;

                            // Ask the API to decode the data by default. By setting this, API will decode the raw data from the magnetic stripe reader
                            _claimedReader.IsDecodeDataEnabled = true;

                            await _claimedReader.EnableAsync();

                            rootPage.NotifyUser("Ready to swipe. Device ID: " + _claimedReader.DeviceId, NotifyType.StatusMessage);

                            // reset the button state
                            ScenarioEndReadButton.IsEnabled = true;
                            ScenarioStartReadButton.IsEnabled = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for End button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ScenarioEndReadButton_Click(object sender, RoutedEventArgs e)
        {
            ResetTheScenarioState();
        }

        /// <summary>
        /// Event handler for the Release Device Requested event fired when magnetic stripe reader receives Claim request from another application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"> Contains the ClaimedMagneticStripeReader that is sending this request</param>
        void OnReleaseDeviceRequested(object sender, ClaimedMagneticStripeReader args)
        {
            // let us retain the device always. If it is not retained, this exclusive claim will be lost.
            args.RetainDevice();
        }

        /// <summary>
        /// Event handler for the DataReceived event fired when a bank card is read by the magnetic stripe reader 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"> Contains the MagneticStripeReaderBankCardDataReceivedEventArgs which contains the data obtained in the scan</param>
        async void OnBankCardDataReceived(object sender, MagneticStripeReaderBankCardDataReceivedEventArgs args)
        {
            // read the data and display
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                rootPage.NotifyUser("Got data.", NotifyType.StatusMessage);

                ScenarioOutputAccountNumber.Text = args.AccountNumber;
                ScenarioOutputExpirationDate.Text = args.ExpirationDate;
                ScenarioOutputFirstName.Text = args.FirstName;
                ScenarioOutputMiddleInitial.Text = args.MiddleInitial;
                ScenarioOutputServiceCode.Text = args.ServiceCode;
                ScenarioOutputSuffix.Text = args.Suffix;
                ScenarioOutputSurname.Text = args.Surname;
                ScenarioOutputTitle.Text = args.Title;
            });

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ResetTheScenarioState();
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Invoked when this page is no longer displayed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ResetTheScenarioState();
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Reset the Scenario state
        /// </summary>
        void ResetTheScenarioState()
        {
            if (_claimedReader != null)
            {
                // Detach the datareceived event handler and releasedevicerequested event handler
                _claimedReader.BankCardDataReceived -= OnBankCardDataReceived;
                _claimedReader.ReleaseDeviceRequested -= OnReleaseDeviceRequested;

                // release the Claimed Magnetic Stripe Reader and set to null
                _claimedReader.Dispose();
                _claimedReader = null;
            }

            if (_reader != null)
            {
                // release the Magnetic Stripe Reader and set to null
                _reader = null;
            }

            // Reset the strings in the UI
            rootPage.NotifyUser("Click the Start Receiving Data Button.", NotifyType.StatusMessage);

            ScenarioOutputAccountNumber.Text = "No data";
            ScenarioOutputExpirationDate.Text = "No data";
            ScenarioOutputFirstName.Text = "No data";
            ScenarioOutputMiddleInitial.Text = "No data";
            ScenarioOutputServiceCode.Text = "No data";
            ScenarioOutputSuffix.Text = "No data";
            ScenarioOutputSurname.Text = "No data";
            ScenarioOutputTitle.Text = "No data";

            // reset the button state
            ScenarioEndReadButton.IsEnabled = false;
            ScenarioStartReadButton.IsEnabled = true;
        }
    }
}
