/* Contains any javascript functions needed for the TA
 * website
 * 
 * @authors - Tyler Allen and Ben Malohi
 * @date - Octobober 8, 2021
 */

$(document).ready(function () {
    $.noConflict();
    $('#roletable').DataTable();
});
/*
 * Uses sweet alerts when a switch in the roles table is 
 * toggled.
 * 
 * @param userid - 
 * @param role - the role that's being toggled
 */
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