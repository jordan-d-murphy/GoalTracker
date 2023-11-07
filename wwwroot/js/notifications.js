"use strict";

console.log("loaded notifications js file...");


var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

connection.on("ReceiveMessage", function (message) {
    console.log("on message....");
    // var li = document.createElement("li");
    let uuid = self.crypto.randomUUID();
    console.log(uuid);


    let li = document.createElement('div');
    li.id = 'liveToast_' + uuid;
    li.className = 'toast';
    li.innerHTML = 
      '<div class="toast-header"> \
        <strong class="me-auto">Notification</strong> \
        <small>Just Now</small> \
        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button> \
      </div> \
      <div class="toast-body">' + message +         
    '</div>';



        document.getElementById("notificationsList").appendChild(li);
    // li.textContent = `message: ${message}`;

        const toastLiveExample = document.getElementById('liveToast_' + uuid)
        const toast = new bootstrap.Toast(toastLiveExample)
        toast.show()



    console.log("notification received....");
});

connection.start();

// connection.invoke("SendMessage", user, message);
