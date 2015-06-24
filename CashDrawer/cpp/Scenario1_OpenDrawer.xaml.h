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

#include "Scenario1_OpenDrawer.g.h"
#include "MainPage.xaml.h"

namespace SDKTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [Windows::Foundation::Metadata::WebHostHidden]
    public ref class Scenario1_OpenDrawer sealed
    {
    public:
        Scenario1_OpenDrawer();

    private:
        MainPage^ rootPage;

        Windows::Devices::PointOfService::CashDrawer^ drawer = nullptr;
        Windows::Devices::PointOfService::ClaimedCashDrawer^ claimedDrawer = nullptr;

        void InitDrawerButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        void OpenDrawerButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

        concurrency::task<bool> CreateDefaultCashDrawerObject();
        concurrency::task<bool> ClaimCashDrawer();

        void ResetScenarioState();

    protected:
        virtual void OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
        virtual void OnNavigatedFrom(Windows::UI::Xaml::Navigation::NavigationEventArgs^ e) override;
    };

}
