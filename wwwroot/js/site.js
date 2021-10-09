function toggle_role(userid, role) {
    var enabled = document.getElementById("" + event.target.dataset.x);
    var URL = "/Admin/OnPost";
    var DATA = { userid: userid, role: role, enable_disable: enabled.checked };

    Swal.fire({
        title: 'Are you sure you want to edit the role?',
        text: "You will be able to revert this later.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, update it!'
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.post(URL, DATA)
                .fail(function (result) {
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong! Role was not changed.',
                    })
                    enabled.checked = !enabled.checked;
                })
                .done(function (result) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Role successfully changed!',
                        showConfirmButton: false,
                        timer: 1500
                    })
                })
                .always(function () {
                    $("#spinner").hide();
                });
        } else {
            enabled.checked = !enabled.checked;
        }
    })
}