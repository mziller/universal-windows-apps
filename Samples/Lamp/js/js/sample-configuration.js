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

(function () {
    "use strict";

    var sampleTitle = "Lamp";

    var scenarios = [
        { url: "/html/Scenario1_GetLamp.html", title: "Get Lamp Instance" },
        { url: "/html/Scenario2_EnableSettings.html", title: "Enable Lamp and Settings Adjustment" },
        { url: "/html/Scenario3_AvailabilityChanged.html", title: "Lamp Device Change Events" }
    ];

    WinJS.Namespace.define("SdkSample", {
        sampleTitle: sampleTitle,
        scenarios: new WinJS.Binding.List(scenarios)
    });
})();