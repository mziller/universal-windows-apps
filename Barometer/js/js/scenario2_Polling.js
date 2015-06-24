﻿//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";
    var barometer;

    var page = WinJS.UI.Pages.define("/html/scenario2_Polling.html", {
        ready: function (element, options) {
            document.getElementById("scenario2Open").addEventListener("click", enableGetReadingScenario, false);
            document.getElementById("scenario2Open").disabled = false;

            barometer = Windows.Devices.Sensors.Barometer.getDefault();
            if (!barometer) {
                WinJS.log && WinJS.log("No barometer found", "sample", "error");
            }
        },
        unload: function () {
        }
    });

    function enableGetReadingScenario() {
        if (barometer) {
            var reading = barometer.getCurrentReading();
            if (reading) {
                document.getElementById("readingOutputPressure").innerHTML = reading.stationPressureInHectopascals.toFixed(2);
            }
        } else {
            WinJS.log && WinJS.log("No barometer found", "sample", "error");
        }
    }
})();
