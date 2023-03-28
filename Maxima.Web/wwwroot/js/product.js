var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "pageLength": 100,
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl",
                "render": function (data) {
                    return `
                        
                        <img  width="50" src="${data}"/>
				
                        `
                },
                "width": "10%"
            },
            { "data": "name", 
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3  text-uppercase">
                       ${data}
                     </p>
                        `
                },
                "width": "20%",
            },
            {
                "data": "price",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3 text-uppercase">
                       ${data}
                     </p>
                        `
                },

                "width": "15%"
            },
            {
                "data": "category.name",
                "render": function (data) {
                    return `
                        
			    	<p class="lead fw-normal product_card_secondary_text mt-3 text-uppercase">
                       ${data}
                     </p>
                        `
                },

                "width": "20%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Product/Upsert?id=${data}"
                        class="btn btn-filter mx-2 d-flex justify-content-center mt-3"> <i class="bi bi-pencil-fill"></i></a>
                        <a onClick=Delete('/Admin/Product/Delete/${data}')
                        class="btn btn-filter mx-2 d-flex justify-content-center mt-3" ><i class="bi bi-trash-fill"></i></a>
					</div>
                        `
                },
                "width": "10%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}