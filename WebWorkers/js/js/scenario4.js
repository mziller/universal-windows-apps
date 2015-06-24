﻿//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";
    var cmWorker1;
    var cmWorker2;

    function stopListenToWorker() {
        if (cmWorker1) {
            cmWorker1.onmessage = null;
        }
        if (cmWorker2) {
            cmWorker2.onmessage = null;
        }
    }

    function sendChannelMessage() {
        if (!cmWorker1) {
            cmWorker1 = new Worker('js/messaging.js');
        }
        if (!cmWorker2) {
            cmWorker2 = new Worker('js/messaging2.js');
        }

        cmWorker1.onmessage = function (e) {
            document.getElementById("messageLog")
              .appendChild(document.createElement('p'))
              .textContent = "Worker 1 says: \"" + e.data + "\"";
        };

        cmWorker2.onmessage = function (e) {
            document.getElementById("messageLog")
              .appendChild(document.createElement('p'))
              .textContent = "Worker 2 says: \"" + e.data + "\"";
        };

        var channel = new MessageChannel();
        cmWorker2.postMessage(null, [channel.port2]);
        cmWorker1.postMessage({ message: "Hello World!" }, [channel.port1]);
    }

    var page = WinJS.UI.Pages.define("/html/scenario4.html", {
        ready: function () {
            document.getElementById("doMessageChannel").addEventListener("click", sendChannelMessage);
            document.getElementById("clearMessageLog").addEventListener("click", function () {
                document.getElementById("messageLog").innerHTML = "";
            });
        },
        unload: stopListenToWorker
    });
})();
