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

#include "Scenario1.g.h"
#include "MainPage.xaml.h"

namespace LoggingCPP
{
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class Scenario1 sealed
    {
    public:
        Scenario1();
    private:
        SDKTemplate::MainPage^ rootPage;
        void DoWin81Mode(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        void DoWin10Mode(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
    };
}
