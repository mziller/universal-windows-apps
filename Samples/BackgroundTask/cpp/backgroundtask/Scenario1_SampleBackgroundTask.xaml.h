﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

//
// Scenario1_SampleBackgroundTask.xaml.h
// Declaration of the SampleBackgroundTask class
//

#pragma once

#include "pch.h"
#include "Scenario1_SampleBackgroundTask.g.h"
#include "MainPage.xaml.h"

namespace BackgroundTask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class SampleBackgroundTask sealed
    {
    public:
        SampleBackgroundTask();

    protected:
        virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
    private:
        SDKTemplate::MainPage^ rootPage;

        void AttachProgressAndCompletedHandlers(Windows::ApplicationModel::Background::IBackgroundTaskRegistration^ task);
        void RegisterBackgroundTask(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        void UnregisterBackgroundTask(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        void UpdateUI();
    };
}
