// Copyright (c) Microsoft. All rights reserved.

#include "pch.h"
#include "MainPage.xaml.h"
#include "SampleConfiguration.h"

using namespace SDKTemplate;

Platform::Array<Scenario>^ MainPage::scenariosInner = ref new Platform::Array<Scenario>
{
    { "Pick a single photo",   "SDKTemplate.Scenario1" },
    { "Pick multiple files",   "SDKTemplate.Scenario2" },
    { "Pick a folder",         "SDKTemplate.Scenario3" },
    { "Save a file",           "SDKTemplate.Scenario4" },
};
