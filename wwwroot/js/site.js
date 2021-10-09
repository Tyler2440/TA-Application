function toggle_role(userid, role) {

    var enabled = document.getElementById("" + event.target.dataset.x);

    var URL = "/Admin/OnPostRole";
    var DATA = { userid: userid, role: role, enable_disable: enabled.checked};

    alert(enabled.checked);
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