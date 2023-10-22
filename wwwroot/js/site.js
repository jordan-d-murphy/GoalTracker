// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function (){

    
});

$("input.colorSuggestion").click(function(event) {
        event.preventDefault()
        var color = event.target.dataset.value
        var targetId = event.target.dataset.targetid

        console.log("Color: " + color + "   targetId: " + targetId)

        $("#" + targetId).val(color)                 
    }
)

    


