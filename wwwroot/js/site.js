"use strict";

$(document).ready(function () {

    $("input.colorSuggestion").click(function (event) {
        event.preventDefault();
        var color = event.target.dataset.value;
        var targetId = event.target.dataset.targetid;
        $("#" + targetId).val(color);
    });



    $(".autocompleteAssignRoleInput").click(function (event) {
        event.preventDefault();

        var roles = $(".roleName").map(function () {
            return this.innerHTML;
        }).get();

        var autocompleteAssignRoleInputs = document.getElementsByClassName("autocompleteAssignRoleInput");
        for (var i = 0; i < autocompleteAssignRoleInputs.length; i++) {
            autocomplete(document.getElementById(autocompleteAssignRoleInputs[i].id), roles);
        }
    });

   



    function autocomplete(input, array) {
        var currentFocus;
        input.addEventListener("input", function (e) {
            var a, b, i, val = this.value;
            closeAllLists();
            if (!val) {
                return false;
            }
            currentFocus = -1;
            a = document.createElement("div");
            a.setAttribute("id", this.id + "autocomplete-list");
            a.setAttribute("class", "autocomplete-items");
            this.parentNode.appendChild(a);
            for (i = 0; i < array.length; i++) {
                if (array[i].substr(0, val.length).toUpperCase() === val.toUpperCase()) {
                    b = document.createElement("div");
                    b.innerHTML = "<strong>" + array[i].substr(0, val.length) + "</strong>";
                    b.innerHTML += array[i].substr(val.length);
                    b.innerHTML += "<input type='hidden' value='" + array[i] + "'>";

                    b.addEventListener("click", function (e) {
                        input.value = this.getElementsByTagName("input")[0].value;
                        closeAllLists();
                    })
                    a.appendChild(b);
                }
            }
        });

        input.addEventListener("keydown", function (e) {

            var x = document.getElementById(this.id + "autocomplete-list");
            if (x) {
                x = x.getElementsByTagName('div');
            }

            if (e.keyCode == 40) {
                currentFocus++;
                addActive(x);
            } else if (e.keyCode == 38) {
                currentFocus--;
                addActive(x);
            } else if (e.keyCode == 13) {
                e.preventDefault();

                if (currentFocus > -1) {

                    if (x) {
                        x[currentFocus].click();
                    }
                }
            }
        });
    }



    function addActive(x) {
        if (!x) {
            return false;
        }
        removeActive(x);
        if (currentFocus >= x.length) {
            currentFocus = 0;
        }
        if (currentFocus < 0) {
            currentFocus = (x.length - 1);
        }
        x[currentFocus].classList.Add("autocomplete-active");
    }



    function removeActive(x) {
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }



    function closeAllLists(element) {
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++) {
            x[i].parentNode.removeChild(x[i]);
        }
    }



    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });



    $('.modal').on('hidden.bs.modal', function () {
        $(this).find('form').trigger('reset');
    });

});


