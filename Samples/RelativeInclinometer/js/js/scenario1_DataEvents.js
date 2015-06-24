﻿//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";
    var reportInterval = 0;
    var inclinometer;

    var page = WinJS.UI.Pages.define("/html/scenario1_DataEvents.html", {
        ready: function (element, options) {
            document.getElementById("scenario1Open").addEventListener("click", enableReadingChangedScenario, false);
            document.getElementById("scenario1Revoke").addEventListener("click", disableReadingChangedScenario, false);
            document.getElementById("scenario1Open").disabled = false;
            document.getElementById("scenario1Revoke").disabled = true;

            inclinometer = Windows.Devices.Sensors.Inclinometer.getDefaultForRelativeReadings();
            if (inclinometer) {
                // Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                // This value will be used later to activate the sensor.
                var minimumReportInterval = inclinometer.minimumReportInterval;
                reportInterval = minimumReportInterval > 16 ? minimumReportInterval : 16;
            } else {
                WinJS.log && WinJS.log("No relative inclinometer found", "sample", "error");
            }
        },
        unload: function () {
            if (document.getElementById("scenario1Open").disabled) {
                document.removeEventListener("visibilitychange", visibilityChangeHandler, false);
                inclinometer.removeEventListener("readingchanged", onDataChanged);

                // Return the report interval to its default to release resources while the sensor is not in use.
                inclinometer.reportInterval = 0;
            }
        }
    });

    function visibilityChangeHandler() {
        // This is the event handler for VisibilityChanged events. You would register for these notifications
        // if handling sensor data when the app is not visible could cause unintended actions in the app.
        if (document.getElementById("scenario1Open").disabled) {
            if (document.msVisibilityState === "visible") {
                // Re-enable sensor input. No need to restore the desired reportInterval (it is restored for us upon app resume).
                inclinometer.addEventListener("readingchanged", onDataChanged);
            } else {
                // Disable sensor input. No need to restore the default reportInterval (resources will be released upon app suspension).
                inclinometer.removeEventListener("readingchanged", onDataChanged);
            }
        }
    }

    function onDataChanged(e) {
        var reading = e.reading;

        // Event can still be in queue after unload is called
        // so check if elements are still loaded.

        if (document.getElementById("eventOutputX")) {
            document.getElementById("eventOutputX").innerHTML = reading.pitchDegrees.toFixed(2);
        }
        if (document.getElementById("eventOutputY")) {
            document.getElementById("eventOutputY").innerHTML = reading.rollDegrees.toFixed(2);
        }
        if (document.getElementById("eventOutputZ")) {
            document.getElementById("eventOutputZ").innerHTML = reading.yawDegrees.toFixed(2);
        }
    }

    function enableReadingChangedScenario() {
        if (inclinometer) {
            // Set the reportInterval to enable the sensor events.
            inclinometer.reportInterval = reportInterval;

            document.addEventListener("visibilitychange", visibilityChangeHandler, false);
            inclinometer.addEventListener("readingchanged", onDataChanged);
            document.getElementById("scenario1Open").disabled = true;
            document.getElementById("scenario1Revoke").disabled = false;
        } else {
            WinJS.log && WinJS.log("No relative inclinometer found", "sample", "error");
        }
    }

    function disableReadingChangedScenario() {
        document.removeEventListener("visibilitychange", visibilityChangeHandler, false);
        inclinometer.removeEventListener("readingchanged", onDataChanged);
        document.getElementById("scenario1Open").disabled = false;
        document.getElementById("scenario1Revoke").disabled = true;

        // Return the report interval to its default to release resources while the sensor is not in use.
        inclinometer.reportInterval = 0;
    }
})();
