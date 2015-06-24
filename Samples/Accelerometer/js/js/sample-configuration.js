﻿//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";

    var sampleTitle = "AccelerometerJS";

    var scenarios = [
        { url: "/html/scenario1_DataEvents.html", title: "Data Events" },
        { url: "/html/scenario2_ShakeEvents.html", title: "Shake Events" },
        { url: "/html/scenario3_Polling.html", title: "Polling" },
        { url: "/html/scenario4_OrientationChanged.html", title: "OrientationChanged Handling" },
        { url: "/html/scenario5_DataEventsBatching.html", title: "Data Events Batching" }
    ];

    WinJS.Namespace.define("SdkSample", {
        sampleTitle: sampleTitle,
        scenarios: new WinJS.Binding.List(scenarios)
    });
})();