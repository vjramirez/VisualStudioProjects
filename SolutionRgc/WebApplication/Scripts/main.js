$(function () {
    $("#fechaIni").datepicker({
            changeMonth: true,
            changeYear: true
    });
    $("#fechaFin").datepicker({
        changeMonth: true,
        changeYear: true
    });
    $("#fechaIni").datepicker("option", "dateFormat", "yy/mm/dd");
    $("#fechaFin").datepicker("option", "dateFormat", "yy/mm/dd");
    $("#fechaIni").datepicker("option",
        $.datepicker.regional["co"]);
    $("#fechaFin").datepicker("option",
        $.datepicker.regional["co"]);

    $("#buscar").click(function () {
        var tablita = $('#tabla');
        //tablaJquery.fnClearTable();
        $.ajax({
            type: "POST",
            url: '/Default.aspx/buscarDatos',
            data: '{fechaIni: "' + $("#fechaIni").val() + '", fechaFin:"' + $("#fechaFin").val() + '" }',
            contentType: "application/json; charset=utf-8",
            success: function (datos) {

                if (datos.d.substring(0, 5) === "ERROR") {
                    alert(datos.d);
                }
                else {
                    console.log(datos.d);
                    var rta = JSON.parse(datos.d);

                    principal.fnClearTable();
                    if (!jQuery.isEmptyObject(rta)) {
                        principal.fnAddData(rta);
                    }
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        })
    })
});

var principal;

window.onload = function (e){
    principal = $('#tabla').dataTable({
        data: [],
        columns: [
            { data: 'fecha' },
            { data: 'cedula' },
            { data: 'nombre' },
            { data: 'apellido1' },
            { data: 'apellido2' },
            { data: 'escliente' }
        ],
        "language": {
            "url": "Content/DatatableConfig.json"
        }
    })
};


