"use strict";

console.log("loaded notifications js file...");


var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

connection.on("ReceiveMessage", function (message) {
    console.log("on message....");
    // var li = document.createElement("li");
    let uuid = self.crypto.randomUUID();
    console.log(uuid);


    // let li = document.createElement('div');
    // li.id = 'liveToast_' + uuid;
    // li.className = 'toast';
    // li.innerHTML = 
    //   '<div class="toast-header"> \
    //     <strong class="me-auto">Notification</strong> \
    //     <small>Just Now</small> \
    //     <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button> \
    //   </div> \
    //   <div class="toast-body">' + message +         
    // '</div>';

    let data = JSON.parse(message);

    console.log(data);

    let li = document.createElement('a');
    li.id = 'notification_' + data.Id;
    li.className = 'list-group-item list-group-item-action';
    li.innerHTML = '<div class="d-flex w-100 justify-content-between" onclick="MarkAsRead(\'' + data.Id + '\');">\
      <h5 class="mb-1">Notification</h5>\
      <small class="text-muted">' + data.SentTimestamp + '</small>\
    </div>\
    <p class="mb-1">' + data.MessageBody + '</p>\
    <small class="text-muted">And some muted small print.</small>';


    document.getElementById("notificationsList").prepend(li);
    // li.textContent = `message: ${message}`;

    // const toastLiveExample = document.getElementById('notification_' + uuid)
    // const toast = new bootstrap.Toast(toastLiveExample)
    // toast.show()


    console.log("notification received....");
    console.log(message["MessageBody"]);



});

connection.start();

// connection.invoke("SendMessage", user, message);


function MarkAsRead(id) {

    console.log("onclick for mark as read, id: " + id);

    $.ajax({
        type: "POST",
        url: 'MarkAsRead/' + id,
        // data: id,
        contentType: "application/json; charset=utf-8",
        dataType: "json",       
        success: function (response) {
            alert("MarkAsRead Ajax response - " + response);
            // Looping over emloyee list and display it  
            // $.each(response, function (index, emp) {
            //     $('#output').append('<p>Id: ' + emp.ID + '</p>' +
            //         '<p>Id: ' + emp.Name + '</p>');
            // });
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
