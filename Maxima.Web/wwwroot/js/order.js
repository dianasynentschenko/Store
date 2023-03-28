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
        "order": [[1, 'desc']],

        "pageLength": 100,
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },


        "columns": [
            {
                "data": "id",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "10%"
            },
            {
                "data": "orderDate",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "20%"
            },
            {
                "data": "name",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "20%"
            },
            {
                "data": "phoneNumber",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "15%"
            },
            {
                "data": "applicationUser.email",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "15%"
            },
            {
                "data": "orderStatus",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "15%"
            },
            {
                "data": "orderTotal",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "15%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}"
                        class="btn btn-filter mx-2 d-flex justify-content-center mt-2"> <i class="bi bi-pencil-fill"></i></a>
                        
					</div>
                        `
                },
                "width": "15%"
            }
        ]

        
    });
}

