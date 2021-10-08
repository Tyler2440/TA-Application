// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ChangeEditPage()
{
    $.post("/Applications/Edit/", data)
        .done(function (result) {
            $("#stats").append(`<li>Completed: data returned ${result.x}</li>`);
        })

        .fail(function (result) {
            $("#stats")
            .append(`<li>Failure: data returned ${result.responseJSON.x}</li>`); $("#customSwitch2").prop("checked", false);
        })
        .always(function () { console.log("all finished"); });
}