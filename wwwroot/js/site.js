// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggle_role(userid, role, enable_disable) {

    var URL = "/AdminController/OnRolePost";
    var DATA = { userid: userid, role: role, enable_disable: enable_disable };

    $.post(URL, DATA)
        .done(function (result) {
            alert('Edit was successful!');
        })
        .fail(function (result) {
            alert('Edit was not successful!');
        })
        .always(function () {
            $("#spinner").hide();
        });
}