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

    var sampleTitle = "DatagramSocket";

    var scenarios = [
        { url: "/html/scenario1_Start.html", title: "Start DatagramSocket Listener" },
        { url: "/html/scenario2_Connect.html", title: "Connect to Listener" },
        { url: "/html/scenario3_Send.html", title: "Send Data" },
        { url: "/html/scenario4_Close.html", title: "Close Socket" }
    ];

    WinJS.Namespace.define("SdkSample", {
        sampleTitle: sampleTitle,
        scenarios: new WinJS.Binding.List(scenarios)
    });
})();
