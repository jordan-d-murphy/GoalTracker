"use strict";

$(document).ready(function () {

    console.log("kai.js reporting for duty");

    $('#kaiChatStart').on('click', function () {
        var kaiChatContainer = $('#kaiChatContainer');
        var kaiChatStartButton = $('#kaiChatStart');
        kaiChatContainer.removeClass("p-5");
        kaiChatContainer.removeClass("d-flex");
        kaiChatContainer.removeClass("justify-content-center");
        kaiChatContainer.removeClass("align-items-center");
        kaiChatStartButton.hide();

    });

    $('#kaiChatInput').on('keypress', function (e) {
        if (e.which == 13) {
            var input = $('#kaiChatInput');
            var test = input.val();
            var chat = $('#chat');
            var userInputDiv = $('<div class="card card-body text-start ms-auto mb-3" style="width: fit-content; max-width: 80%;">' + input.val() + '</div>');
            userInputDiv.appendTo(chat);
            userInputDiv[0].scrollIntoView({ behavior: "smooth" });
            input.val('');

            var kaiResponseDiv = $('<div class="card card-body text-start me-auto mb-3" style="width: fit-content; max-width: 80%; background-color: #D7F0F4; color: black !important;">'
                + 'You asked: <strong>' + test + '</strong></div>');
            kaiResponseDiv.appendTo(chat);
            kaiResponseDiv[0].scrollIntoView({ behavior: "smooth" });
        }
    });
});