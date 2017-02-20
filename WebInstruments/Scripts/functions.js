var btn = document.getElementById("myBtn");
var modal = document.getElementById('myModal');
var btnClose = document.getElementById("myCloseBtn");

btn.onclick = function () {
    modal.style.display = "block";
}


btnClose.onclick = function () {
    modal.style.display = "none";
    $(modal).find('input[type="text"],input[type="email"],input[type="number"],textarea,select').val('');
}


window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function remove(id, url) {
    if (!(confirm('Deseja realmente excluir o item selecionado?')))
        return;

    $.ajax({
        url: url,
        type: 'POST',
        data: { id: id },
        error: function () {
            alert("Não foi possível realizar a operação!");
        },
        success: function () {
            load();
        }
    });
}


$(document)
    .ready(function () {
        $('#myTable').DataTable({
            "paging": true,
            "pageLength": 10,
            "lengthChange": false,
            "filter": true,
            "columnDefs": [
                { "width": "15%", "targets": 0 },
                { "classname": "dt-head-center", "targets": '_all' }
            ],
            "oLanguage": {
                "sEmptyTable": "Sem Registros",
                "sInfoFiltered": "",
                "sInfoEmpty": "Sem registros",
                "sSearch": "Busca:",
                "sZeroRecords": "Sem Resultados",
                "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                "oPaginate": {
                    "sNext": "Próximo",
                    "sPrevious": "Anterior",
                    "sSearch": "Busca"
                }
            }

        });
    });


function load() {
    location.reload();
}


