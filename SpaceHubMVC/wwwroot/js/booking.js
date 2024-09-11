/*const { ajax } = require("jquery");*/

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#bookingTable').DataTable({
        "ajax": { url:'/Admin/Booking/GetAll'},
        "columns": [
        { data: 'id',"width":"5%" },
            { data: 'bookingDate', "width": "10%" },
            { data: 'user.name', "width": "15%" },
            { data: 'workspaceId', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-80 btn-group" role="group">
                    <a href="/Admin/Booking/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square mx-2"></i>Edit</a>
                    <a onClick=Delete('/Admin/Booking/Delete?id=${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill mx-2"></i>Delete</a>
                    </div>`
                }, "width": "10%"
            }
    ]
    });
}
function Delete (url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reloaad();
                    toastr.success(data.message);
                }
            })

        }
    })
}

