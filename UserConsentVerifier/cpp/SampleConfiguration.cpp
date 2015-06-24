// Copyright (c) Microsoft. All rights reserved.

#include "pch.h"
#include "MainPage.xaml.h"
#include "SampleConfiguration.h"

using namespace SDKTemplate;

Platform::Array<Scenario>^ MainPage::scenariosInner = ref new Platform::Array<Scenario>
{
    { "Check Consent Availability", "UserConsentVerifier.Scenario1_CheckConsentAvailability" },
    { "Request Consent", "UserConsentVerifier.Scenario2_RequestConsent" }
};
