$(document).ready(function () {

    var idEmpleado = $('#txtIdEmpleado').val();
    $.ajax({
        type: 'POST',
        url: "/Contrato/BuscarContratoVigente",
        data: { idEmpleado: idEmpleado },
        datatype: 'json',
        async: false,
        success: function (data) {
            if (data != '') {
                $('#txtIdContrato').val(data.idContrato);
                $('#btnCrearContrato').attr('disabled', 'disabled');
                $('#btnEditarContrato').removeAttr('disabled');
                $('#btnEliminarContrato').removeAttr('disabled');
            } else {
                $('#btnEditarContrato').attr('disabled', 'disabled');
                $('#btnEliminarContrato').attr('disabled', 'disabled');
                $('#btnCrearContrato').removeAttr('disabled');
            }
        }

    });

});