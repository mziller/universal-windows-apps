﻿//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";

    var ViewManagement = Windows.UI.ViewManagement;
    var FullScreenSystemOverlayMode = ViewManagement.FullScreenSystemOverlayMode;
    var ApplicationView = ViewManagement.ApplicationView;

    var page = WinJS.UI.Pages.define("/html/scenario1-basic.html", {
        ready: function (element, options) {
            toggleFullScreenMode.addEventListener("click", onToggleFullScreenMode);
            showStandardSystemOverlays.addEventListener("click", onShowStandardSystemOverlays);
            useMinimalOverlays.addEventListener("check", onMinimalOverlaysChanged);
            // The resize event is raised when the view enters or exits full screen mode.
            window.addEventListener("resize", onresize);
            document.body.addEventListener("keydown", onkeydown);
            onresize();
        },

        unload: function () {
            window.removeEventListener("resize", onresize);
            document.body.removeEventListener("keydown", onkeydown);
        }
    });

    function onToggleFullScreenMode() {
        var view = ApplicationView.getForCurrentView();
        if (view.isFullScreenMode) {
            view.exitFullScreenMode();
            WinJS.log && WinJS.log("Exiting full screen mode", "samples", "status");
            // The resize event will be raised when the exit from full screen mode is complete.
        } else {
            if (view.tryEnterFullScreenMode()) {
                WinJS.log && WinJS.log("Entering full screen mode", "samples", "status");
                // The resize event will be raised when the entry to full screen mode is complete.
            } else {
                WinJS.log && WinJS.log("Failed to enter full screen mode", "samples", "error");
            }    
        }
    }
    
    function onShowStandardSystemOverlays() {
        var view = ApplicationView.getForCurrentView();
        view.showStandardSystemOverlays();
    }

    function onMinimalOverlaysChanged() {
        var view = ApplicationView.getForCurrentView();
        view.fullScreenSystemOverlayMode = useMinimalOverlays.checked ? FullScreenSystemOverlayMode.minimal : FullScreenSystemOverlayMode.standard;
    }

    function onresize() {
        var view = ApplicationView.getForCurrentView();
        var isFullScreenMode = view.isFullScreenMode;
        toggleFullScreenMode.innerText = WinJS.UI.AppBarIcon[isFullScreenMode ? "backtowindow" : "fullscreen"];
        reportFullScreenMode.innerText = isFullScreenMode ? "is in" : "is not in";
        fullScreenOptions.style.display = isFullScreenMode ? "block" : "none";
    }

    function onkeydown(e) {
        if (e.key === "Esc") {
            var view = ApplicationView.getForCurrentView();
            if (view.isFullScreenMode) {
                view.exitFullScreenMode();
                WinJS.log && WinJS.log("Exited full screen mode due to keypress", "samples", "status");
            }
        }
    }
})();
