"use strict";

console.log("loaded notifications js file...");

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

connection.on("ReceiveMessage", function (message) {
    console.log("on message....");
    
    let data = JSON.parse(message);
    dayjs.extend(window.dayjs_plugin_relativeTime)

    console.log(data);
    console.log(dayjs(data.SentTimestamp).fromNow());

    let li = document.createElement('a');
    li.id = 'notification_' + data.Id;
    li.className = 'list-group-item list-group-item-action';
    li.innerHTML = '<div class="d-flex w-100 justify-content-between" onclick="MarkAsRead(\'' + data.Id + '\');">\
      <h5 class="mb-1">Notification</h5>\
      <small class="text-muted">' + dayjs(data.SentTimestamp).fromNow() + '</small>\
    </div>\
    <p class="mb-1">' + data.MessageBody + '</p>\
    <small class="text-muted">And some muted small print.</small>';

    document.getElementById("notificationsList").prepend(li);
   
    console.log("notification received....");
    console.log(message["MessageBody"]);

});

connection.start();


function MarkAsRead(id) {

    console.log("onclick for mark as read, id: " + id);

    $.ajax({
        type: "POST",
        url: 'MarkAsRead/' + id,
        // data: id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",       
        success: function (response) {            
            var div = document.getElementById('notification_' + id);
            div.remove();
        },
        complete: function () {
            // Hide(); // Hide loader icon  
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
        }
    });

}
