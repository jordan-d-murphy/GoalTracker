"use strict";

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



    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));

    window.PollActiveUsersId = setInterval(PollActiveUsers, 15000);

});


function PollActiveUsers() {

    console.log("POLLING ACTIVE USERS...");

    const baseUrl = window.location.origin;
    var url = baseUrl + '/OnlinePresenceIndicator/PollActiveUsers';

    console.log("url -> " + url);

    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("response returned from PollActiveUsers()" + response);
        },
        complete: function () {

        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
        }
    });
}