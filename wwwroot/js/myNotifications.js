"use strict";

$(document).ready(function () {

    console.log("loaded myNotifications.js file...");
    dayjs.extend(window.dayjs_plugin_relativeTime);
    dayjs.extend(window.dayjs_plugin_localizedFormat);
    dayjs.extend(window.dayjs_plugin_customParseFormat);

    var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

    connection.on("ReceiveMessage", function (message) {

        console.log("hit 'ReceiveMessage' in myNotifications.js file");

        let data = JSON.parse(message);
        let li = document.createElement('a');
        li.id = 'notification_' + data.Id;
        li.className = 'list-group-item list-group-item-action';
        li.innerHTML = '<div class="d-flex w-100 justify-content-between" onclick="MarkAsRead(\'' + data.Id + '\');">\
        <h5 class="mb-1">Notification</h5>\
        <small class="text-muted created-sent-timestamp" id="sent_timestamp_' + data.Id + '" data-date="' + data.SentTimestamp + '">' + dayjs(data.SentTimestamp).fromNow() + '</small>\
        </div>\
        <p class="mb-1">' + data.MessageBody + '</p>\
        <small class="text-muted">From: ' + data.Sender.Email + '</small>';

        document.getElementById("notificationsList").prepend(li);
        UpdateDisplayTimes();

        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: red;');

    });

    connection.start();

    function UpdateDisplayTimes() {
        $('.sent-timestamp').each(function () {
            var dateString = $(this).attr('data-date');
            var thisId = $(this).attr('id');
            dateString = dayjs(dateString, 'MM/D/YYYY HH:mm:ssA');
            dateString = dayjs(dateString).format('LLL');
            var replaceDate = dayjs(dateString).fromNow();
            $("#" + thisId).text(replaceDate);
        });
    }

    UpdateDisplayTimes();

})


function MarkAsRead(id) {

    const baseUrl = window.location.origin;
    var url = baseUrl + '/Notification/MarkAsRead/' + id;
    console.log("MarkAsRead(<id>) url: " + url);

    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var div = document.getElementById('notification_' + id);
            if (div != null) {
                div.remove();
            }

            GetCountUnreadNotifications();
            
        },
        complete: function () {

        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
        }
    });
}


