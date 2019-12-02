$(document).ready(function () {

    $.ajax({
        type: 'GET',
        url: "/Pagos/DevolverPeriodoActual",
        datatype: 'json',
        success: function (data) {

            if (data != null) {
                $('#txtFechaInicioPeriodo').val(moment(data.fechaInicio).format('DD-MMM-YYYY'));
                $('#txtFechaTerminoPeriodo').val(moment(data.fechaFin).format('DD-MMM-YYYY'));
                $('#txtIdPeriodo').val(data.idPeriodoPago);

            } else {

                swal({
                    title: "Advertencia",
                    text: "No se encontraron periodos activos.",
                    icon: "warning",
                    button: "Aceptar",
                })
            }

        }

    });

});