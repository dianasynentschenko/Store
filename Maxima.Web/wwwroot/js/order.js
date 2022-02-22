var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("newOrder")) {
        loadDataTable("newOrder");
    }
    else {
        if (url.includes("confirmed")) {
            loadDataTable("confirmed");
        }
        else {
            if (url.includes("inProcessing")) {
                loadDataTable("inProcessing");
            }
            else {
                if (url.includes("sending")) {
                    loadDataTable("sending");
                }
                else {
                    if (url.includes("receive")) {
                        loadDataTable("receive");
                    }
                    else {
                        loadDataTable("all");
                    }
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Details</a>
                        
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}
