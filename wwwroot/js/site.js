// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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



    var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationsHub").build();

    connection.on("ReceiveMessage", function (message) {
        console.log("\n\n\nhit 'ReceiveMessage' from '/NotificationsHub' in site.js file...\n\n\n");
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: red;');
    });

    connection.on("ClearNotificationIcon", function (message) {
        console.log("\n\n\nhit 'ClearNotificationIcon' from '/NotificationsHub' in site.js file...\n\n\n");
        $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');

    });

    connection.start();








})






function GetCountUnreadNotifications() {

    console.log("Notifications count: ");

    const currentUrl = window.location.href;
    console.log(currentUrl);
    
    var url = 'Notification/GetCountUnreadNotifications';
    if (currentUrl.includes("/Notification/")) {
        url = 'GetCountUnreadNotifications';
    }

    


    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response + " unread notifications.");

            if (response === 0) {
                $("#unreadNotificationIcon").attr('style','font-size: 1rem; color: white;');

                $.ajax({
                    type: "GET",
                    url: 'ClearNotificationIcon',
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

