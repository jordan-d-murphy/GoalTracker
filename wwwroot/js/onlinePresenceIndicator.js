$(document).ready(function () {
       
    var onlinePresenceIndicationsConnection = new signalR.HubConnectionBuilder().withUrl("/OnlinePresenceIndications").build();

    onlinePresenceIndicationsConnection.on("SendOnlinePresence", function (message) {
        let data = JSON.parse(message);

        if (data.Status === "ONLINE")
        {
            $("#opi_popover_online_" + data.UserId).show();     
            $("#opi_online_" + data.UserId).show();      

            $("#opi_popover_offline_" + data.UserId).hide();     
            $("#opi_offline_" + data.UserId).hide();       
        } 
        else if (data.Status === "OFFLINE")
        {
            $("#opi_popover_online_" + data.UserId).hide();     
            $("#opi_online_" + data.UserId).hide();   

            $("#opi_popover_offline_" + data.UserId).show();     
            $("#opi_offline_" + data.UserId).show();                   
        }

    });

    onlinePresenceIndicationsConnection.start();

    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]')
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))

});