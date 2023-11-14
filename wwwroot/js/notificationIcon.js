"use strict";

$(document).ready(function () {

    console.log("Loaded notificationIcon.js");
       
    var notificationsHubConnection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

    notificationsHubConnection.on("ReceiveMessage", function (message) {
        console.log("hit 'ReceiveMessage' from '/NotificationsHub' in notificationIcon.js file");
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: red;');
    });

    notificationsHubConnection.on("ClearNotificationIcon", function (message) {
        console.log("hit 'ClearNotificationIcon' from '/NotificationsHub' in notificationIcon.js file");
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');

    });

    notificationsHubConnection.start();

    console.log("Page loaded, checking notifications...");
    GetCountUnreadNotifications();
});



function GetCountUnreadNotifications() {

    const baseUrl = window.location.origin;    
    var getCountUrl = baseUrl + '/Notification/GetCountUnreadNotifications';

    $.ajax({
        type: "GET",
        url: getCountUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            console.log(response + " unread notifications.");

            if (response === 0) {
            
                $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');            
                var clearNotificationUrl = baseUrl + '/Notification/ClearNotificationIcon';
            
                $.ajax({
                    type: "GET",
                    url: clearNotificationUrl,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var div = document.getElementById('notification_' + id);
                        if (div != null) {
                            div.remove();
                        }    
                        // GetCountUnreadNotifications();
                        
                    },
                    complete: function () {
            
                    },
                    failure: function (jqXHR, textStatus, errorThrown) {
                        alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
                    }
                });
            } else {

                $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: red;');
            }

        },
        complete: function () {

        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
        }
    });

}

