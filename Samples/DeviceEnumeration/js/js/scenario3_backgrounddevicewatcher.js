﻿//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";

    var DevEnum = Windows.Devices.Enumeration;
    var backgroundTaskName = "DeviceEnumerationJs_BackgroundTaskName";
    var backgroundTaskRegistration = null;

    var page = WinJS.UI.Pages.define("/html/scenario3_backgrounddevicewatcher.html", {
        ready: function (element, options) {

            // Hook up button event handlers
            document.getElementById("startWatcherButton").addEventListener("click", startWatcher, false);
            document.getElementById("stopWatcherButton").addEventListener("click", stopWatcher, false);

            // Manually bind selector options
            DisplayHelpers.selectorsList.forEach(function each(item) {
                var option = document.createElement("option");
                option.textContent = item.displayName;
                selectorComboBox.appendChild(option);
            });

            // Process any data bindings
            WinJS.UI.processAll();

            // Determine if the background task is already active
            var allTasks = Windows.ApplicationModel.Background.BackgroundTaskRegistration.allTasks;

            var iter = allTasks.first();
            while (iter.hasCurrent) {
                var task = iter.current.value;

                if (task.name === backgroundTaskName) {
                    backgroundTaskRegistration = task;
                    startWatcherButton.disabled = true;
                    stopWatcherButton.disabled = false;
                    break;
                }

                iter.moveNext();
            }
        }
    });

    function startWatcher() {
        var deviceWatcher = null;
        startWatcherButton.disabled = true;

        var selectedItem = DisplayHelpers.selectorsList.getAt(selectorComboBox.selectedIndex);

        // If the selected device selector is a pre-canned device class, call CreateWatcher with the device class
        // overload.  Otherwise assume the device selector contains an AQS filter selector and use that overload.
        if (null != selectedItem.deviceClassSelector) {
            deviceWatcher = DevEnum.DeviceInformation.createWatcher(selectedItem.deviceClassSelector);
        }
        else {
            deviceWatcher = DevEnum.DeviceInformation.createWatcher(
                selectedItem.selector,
                null // don't request additional properties for this sample
                );
        }

        // Get the background trigger for this watcher
        var triggerEventKinds = [DevEnum.DeviceWatcherEventKind.add, DevEnum.DeviceWatcherEventKind.update, DevEnum.DeviceWatcherEventKind.remove];
        var deviceWatcherTrigger = deviceWatcher.getBackgroundTrigger(triggerEventKinds);
        WinJS.log && WinJS.log("Starting watcher...", "sample", "status");
        
        // Register this trigger for our background task
        registerBackgroundTask(deviceWatcherTrigger);

        stopWatcherButton.disabled = false;
        WinJS.log && WinJS.log("Watcher started...", "sample", "status");
    }

    function stopWatcher() {

        stopWatcherButton.disabled = true;
        if (null != backgroundTaskRegistration) {
            unregisterBackgroundTask(backgroundTaskRegistration);
        }
        startWatcherButton.disabled = false;
    }

    function registerBackgroundTask(deviceWatcherTrigger) {

        // First see if we already have this background task registered. If so, unregister
        // it before we register it with the new trigger.
        var allTasks = Windows.ApplicationModel.Background.BackgroundTaskRegistration.allTasks;

        var iter = allTasks.first();
        while (iter.hasCurrent) {
            var task = iter.current.value;

            if (task.name === backgroundTaskName) {
                unregisterBackgroundTask(task);
                break;
            }

            iter.moveNext();
        }

        var taskBuilder = new Windows.ApplicationModel.Background.BackgroundTaskBuilder();
        taskBuilder.name = backgroundTaskName;
        taskBuilder.taskEntryPoint = "js\\BackgroundDeviceWatcher.js";
        taskBuilder.setTrigger(deviceWatcherTrigger);

        backgroundTaskRegistration = taskBuilder.register();
        backgroundTaskRegistration.addEventListener("completed", onCompleted)
    }

    function onCompleted(args) {
        WinJS.log && WinJS.log("Background task completed", "sample", "status");
    }

    function unregisterBackgroundTask(taskReg) {
        taskReg.unregister(true);
        var settings = Windows.Storage.ApplicationData.current.localSettings;
        settings.values["eventCount"] = 0;
    }

})();
