﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {



    $("input.colorSuggestion").click(function (event) {
        event.preventDefault()
        var color = event.target.dataset.value
        var targetId = event.target.dataset.targetid
        $("#" + targetId).val(color)
    })




    $(".autocompleteAssignRoleInput").click(function (event) {
        event.preventDefault()

        console.log(".autocompleteAssignRoleInput clicked...")
        var roles = $(".roleName").map(function () {
            console.log("each on this: " + this.innerHTML)
            return this.innerHTML
        }).get()

        console.log("roles: " + roles)

        var autocompleteAssignRoleInputs = document.getElementsByClassName("autocompleteAssignRoleInput")
        for (var i = 0; i < autocompleteAssignRoleInputs.length; i++) {
            autocomplete(document.getElementById(autocompleteAssignRoleInputs[i].id), roles)
        }


    })

    $('#kaiChatStart').on('click', function () {
        var kaiChatContainer = $('#kaiChatContainer')
        var kaiChatStartButton = $('#kaiChatStart')
        kaiChatContainer.removeClass("p-5")
        kaiChatContainer.removeClass("d-flex")
        kaiChatContainer.removeClass("justify-content-center")
        kaiChatContainer.removeClass("align-items-center")
        kaiChatStartButton.hide()

    })

    $('#kaiChatInput').on('keypress', function (e) {
        if (e.which == 13) {
            var input = $('#kaiChatInput')
            var test = input.val()
            var chat = $('#chat')
            var userInputDiv = $('<div class="card card-body text-start ms-auto mb-3" style="width: fit-content; max-width: 80%;">' + input.val() + '</div>')
            userInputDiv.appendTo(chat)
            userInputDiv[0].scrollIntoView({ behavior: "smooth" })
            input.val('')

            var kaiResponseDiv = $('<div class="card card-body text-start me-auto mb-3" style="width: fit-content; max-width: 80%; background-color: #D7F0F4; color: black !important;">'
                + 'You asked: <strong>' + test + '</strong></div>')
            kaiResponseDiv.appendTo(chat)
            kaiResponseDiv[0].scrollIntoView({ behavior: "smooth" })

        }

    })



    function autocomplete(input, array) {
        var currentFocus
        input.addEventListener("input", function (e) {
            var a, b, i, val = this.value
            closeAllLists()
            if (!val) {
                return false
            }
            currentFocus = -1
            a = document.createElement("div")
            a.setAttribute("id", this.id + "autocomplete-list")
            a.setAttribute("class", "autocomplete-items")
            this.parentNode.appendChild(a)
            for (i = 0; i < array.length; i++) {
                if (array[i].substr(0, val.length).toUpperCase() === val.toUpperCase()) {
                    b = document.createElement("div")
                    b.innerHTML = "<strong>" + array[i].substr(0, val.length) + "</strong>"
                    b.innerHTML += array[i].substr(val.length)
                    b.innerHTML += "<input type='hidden' value='" + array[i] + "'>"

                    b.addEventListener("click", function (e) {
                        input.value = this.getElementsByTagName("input")[0].value
                        closeAllLists()
                    })
                    a.appendChild(b)
                }
            }
        })




        input.addEventListener("keydown", function (e) {

            var x = document.getElementById(this.id + "autocomplete-list")
            if (x) {
                x = x.getElementsByTagName('div')
            }

            if (e.keyCode == 40) {
                currentFocus++
                addActive(x)
            } else if (e.keyCode == 38) {
                currentFocus--
                addActive(x)
            } else if (e.keyCode == 13) {
                e.preventDefault()

                if (currentFocus > -1) {

                    if (x) {
                        x[currentFocus].click()
                    }
                }
            }


        })
    }





    function addActive(x) {
        if (!x) {
            return false
        }
        removeActive(x)
        if (currentFocus >= x.length) {
            currentFocus = 0
        }
        if (currentFocus < 0) {
            currentFocus = (x.length - 1)
        }
        x[currentFocus].classList.Add("autocomplete-active")


    }




    function removeActive(x) {
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active")
        }
    }




    function closeAllLists(element) {
        var x = document.getElementsByClassName("autocomplete-items")
        for (var i = 0; i < x.length; i++) {
            x[i].parentNode.removeChild(x[i])

            // if (element != x[i] && element != document.getElementById("autocompleteAssignRoleInput")) {
            //     x[i].parentNode.removeChild(x[i])
            // }
        }
    }





    document.addEventListener("click", function (e) {
        closeAllLists(e.target)
    })




    $('.modal').on('hidden.bs.modal', function () {
        $(this).find('form').trigger('reset')
    })







    var notificationsHubConnection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

    notificationsHubConnection.on("ReceiveMessage", function (message) {
        console.log("Red - Scenario 2");
        console.log("hit 'ReceiveMessage' from '/NotificationsHub' in site.js file... , make it red!");
        // console.log("message is " + message);
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: red;');
    });

    notificationsHubConnection.on("ClearNotificationIcon", function (message) {
        console.log("hit 'ClearNotificationIcon' from '/NotificationsHub' in site.js file..., make it White!");
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');

    });

    notificationsHubConnection.start();


    





    var onlinePresenceIndicationsConnection = new signalR.HubConnectionBuilder().withUrl("/OnlinePresenceIndications").build();

    onlinePresenceIndicationsConnection.on("SendOnlinePresence", function (message) {
        console.log("hit 'SendOnlinePresence' from '/OnlinePresenceIndications' in site.js file...");
        let data = JSON.parse(message);

    
        console.log("data.UserId is " + data.UserId);
        console.log("data.Status is " + data.Status);
        console.log("data.Timestamp is " + data.Timestamp);

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



})






function GetCountUnreadNotifications() {

    // console.log("Notifications count: ");

    const baseUrl = window.location.origin;
    // console.log("baseUrl: " + baseUrl);
    
    var getCountUrl = baseUrl + '/Notification/GetCountUnreadNotifications';

    // console.log("GetCountUnreadNotifications() url: " + getCountUrl);

    $.ajax({
        type: "GET",
        url: getCountUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response + " unread notifications.");

            if (response === 0) {
                console.log("hit 'GetCountUnreadNotifications()' in site.js file...,repsone === 0, make it White!");
                $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');
                
                var clearNotificationUrl = baseUrl + '/Notification/ClearNotificationIcon';
            
                // console.log("ClearNotificationIcon url: " + clearNotificationUrl);

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
                        GetCountUnreadNotifications();
                        
                    },
                    complete: function () {
            
                    },
                    failure: function (jqXHR, textStatus, errorThrown) {
                        alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message  
                    }
                });
            } else {
                console.log("Red - Scenario 3");
                console.log("site.js - Inside GetCountUnreadNotifications - hit else, make it red!");
                // console.log("response is " + response);
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

