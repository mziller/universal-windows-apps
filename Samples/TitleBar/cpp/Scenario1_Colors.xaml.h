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

#pragma once

#include "Scenario1_Colors.g.h"
#include "MainPage.xaml.h"

namespace SDKTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class Scenario1_Colors sealed
    {
    public:
        Scenario1_Colors();

    private:
        void UseCustomColors_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs e)
        {
            UpdateColors();
        }

        void UpdateColors();
        void ReportColors();

    private:
        MainPage^ rootPage;
        Windows::UI::ViewManagement::ApplicationViewTitleBar^ titleBar;
    };
}
