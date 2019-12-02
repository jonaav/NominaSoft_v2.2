
function buscarEmpleado(){
    $.ajax({
        type: 'POST',
        url: "/Contrato/BuscarEmpleado",
        datatype: 'json',
        data: { dni: $("#txtDni").val() },
        success: function (data) {

            console.log(data);
            if (data != '') {
                location = 'GestionarContrato/Contrato/?dni=' + data;
            }
            else {
                swal({
                    title: "Error",
                    text: "Error el dni ingresado no esta registrado o no es valido. Ingresar otro por favor.",
                    icon: "error",
                    button: "Aceptar",
                    timer: 2000
                });
            }
            
        },
    });
}

function editarContratoModal(idEmpleado) {

    $.ajax({
        type: 'POST',
        url: "/Contrato/BuscarContratoVigente",
        data: { idEmpleado: idEmpleado },
        datatype: 'json',
        async: false,
        success: function (data) {

            if (data != '') {

                $('#txtIdContrato').val(data.idContrato);
                var fechaInicio = new Date(data.fechaInicio);
                var fechaTermino = new Date(data.fechaFin);
                var fechaInicioDia = ("0" + fechaInicio.getDate()).slice(-2);
                var fechaInicioMes = ("0" + (fechaInicio.getMonth()+1)).slice(-2);
                var fechaInicioFinal = fechaInicio.getFullYear() + "-" + fechaInicioMes + "-" + fechaInicioDia;
                var fechaTerminoDia = ("0" + fechaTermino.getDate()).slice(-2);
                var fechaTerminoMes = ("0" + (fechaTermino.getMonth()+1)).slice(-2);
                var fechaTerminoFinal = fechaTermino.getFullYear() + "-" + fechaTerminoMes + "-" + fechaTerminoDia;
                $('#dateFechaInicioEdicion').val(fechaInicioFinal);
                $('#dateFechaTerminoEdicion').val(fechaTerminoFinal);
                $('#txtCargoEdicion').val(data.cargo);
                $("#cmbAFPEdicion").val(data.idAfp);
                if (data.asignacionFamiliar) {
                    $('#chkAsignacionFamiliarEdicion').prop("checked", true);
                } else {
                    $('#chkAsignacionFamiliarEdicion').prop("checked", false);
                }
                
                $('#txtTotalHorasEdicion').val(data.horasSemanales);
                $('#txtValorHoraEdicion').val(data.valorHora);
                $('#modalEditarContrato').modal('show');

            } else {

                swal({
                    title: "Advertencia",
                    text: "Este empleado no contiene contratos vigentes",
                    icon: "warning",
                    button: "Aceptar"
                })
            }
           
        }
    });
}

function editarContrato(idEmp) {
   
     
    var idContrato = $('#txtIdContrato').val();
    var asignacionFamiliar=false;
    var cargo = $('#txtCargoEdicion').val();
    var estado=1;
    var fechaInicio = $('#dateFechaInicioEdicion').val();
    var fechaFin = $('#dateFechaTerminoEdicion').val();
    var horasSemanales = $('#txtTotalHorasEdicion').val();
    var idAFP = $('#cmbAFPEdicion').val();
    var idEmpleado=idEmp;
    var valorHora = $('#txtValorHoraEdicion').val();

     if ($('#chkAsignacionFamiliarEdicion').prop('checked')) {
        asignacionFamiliar = true;
     }

      $.ajax({
        type: 'POST',
        url: "/Contrato/Editar",
        datatype: 'json',
          data: {
              IdContrato:idContrato,
              AsignacionFamiliar: asignacionFamiliar,
              Cargo: cargo,
              Estado: estado,
              FechaInicio: fechaInicio,
              FechaFin: fechaFin,
              HorasSemanales: horasSemanales,
              IdAfp: idAFP,
              IdEmpleado: idEmpleado,
              ValorHora: valorHora
          },
          success: function (data) {

              (async () => {
                  swal({
                      title: "Correcto!",
                      text: "El contrato se ha editado exitosamente.",
                      icon: "success",
                      button: "Aceptar",
                      timer: 2000
                  }).then(
                      function () {
                          if (true) {
                              $('#modalEditarContrato').modal('hide');
                              location.reload();
                          }
                      }
                  )
              })();
          },
      });
      
}


function eliminarContrato() {

    var idContrato = $('#txtIdContrato').val();

     swal({
        title: "Mensaje de Confirmacion",
        text: "¿Desea eliminar este contrato?",
        icon: "warning",
        buttons: true,
        dangerMode: true
     })
        .then((willDelete) => {
            if(willDelete){
                $.ajax({
                    type: 'POST',
                    url: "/Contrato/Eliminar",
                    data: {
                        IdContrato: idContrato
                    },
                    datatype: 'json',
                    success: function (response) {
    
                        swal({
                            title: "Correcto!",
                            text: "Contrato eliminado exitosamente.",
                            icon: "success",
                            button: "Aceptar",
                            timer: 2000
                        }).then(
                            function () {
                                if (true) {
                                    location.reload();
                                }
                            }
                        )
    
                    },
                    error: function () {
                    }
                });
            }
            else{
                swal({
                    title: "Cancelado!",                                        
                    button: "Aceptar",
                    timer: 2000
                })
            }
            
        });
    }



async function guardarContrato(idEmp) {

    var asignacionFamiliar=false;
    var cargo = $('#txtCargoRegistro').val();
    var estado=1;
    var fechaInicio = $('#dateFechaInicioRegistro').val();
    var fechaFin = $('#dateFechaTerminoRegistro').val();
    var horasSemanales = $('#txtTotalHorasRegistro').val();
    var idAFP = $('#cmbAFPRegistro').val();
    var idEmpleado=idEmp;
    var valorHora = $('#txtValorHoraRegistro').val();

    if ($('#chkAsignacionFamiliarRegistro').prop('checked')) {
        asignacionFamiliar = true;
    }

      $.ajax({
        type: 'POST',
        url: "/Contrato/Guardar",
        datatype: 'json',
          data: {
              AsignacionFamiliar: asignacionFamiliar,
              Cargo: cargo,
              Estado: estado,
              FechaInicio: fechaInicio,
              FechaFin: fechaFin,
              HorasSemanales: horasSemanales,
              IdAfp: idAFP,
              IdEmpleado: idEmpleado,
              ValorHora: valorHora
          },
          success: function (data) {

              if (data != "") {

                  (async () => {

                      swal({
                          title: "Correcto!",
                          text: "El contrato se ha creado exitosamente.",
                          icon: "success",
                          button: "Aceptar",
                          timer: 2000
                      }).then(
                          function () {
                              if (true) {
                                  $('#basicExampleModal').modal('hide');
                                  location.reload();
                              }
                          }
                      )
                  })();

              } else {
                    swal({
                      title: "Error",
                      text: "Los datos no son validos.",
                      icon: "error",
                      button: "Aceptar",
                      timer: 2000
                  })
              }
        },
    });
}

$('#cmbListarPeriodos').change(function () {
    var idPeriodo = $(this).val();
    if (idPeriodo > 0) {

        $.ajax({
            type: 'POST',
            url: "/Pagos/DevolverPeriodo",
            datatype: 'json',
            data: {
                idPeriodo: idPeriodo,
            },
            success: function (data) {
                $('#txtFechaInicioPeriodo').val(moment(data.fechaInicio).format('DD-MMM-YYYY'));
                $('#txtFechaTerminoPeriodo').val(moment(data.fechaFin).format('DD-MMM-YYYY'));
                $('#txtIdPeriodo').val(idPeriodo);
                /*
                if (data.estado == 1) {
                    $('#btnProcesarPago').removeAttr('disabled');
                }*/
            },
        });

    } else {
        $('#txtFechaInicioPeriodo').val('');
        $('#txtFechaTerminoPeriodo').val('');
      //  $('#btnProcesarPago').attr('disabled', 'disabled');
    }

});

$("#btnProcesarPago").click(function () {

        if (totalPeriodosActivos() == 0) {

            swal({
                title: "Error",
                text: "No se puede procesar porque no existe periodo de pago activo.",
                icon: "error",
                button: "Aceptar"
            })
            return false;
            
        } else {

            if ($('#txtIdPeriodo').val() > 0) {

                if (totalContratosVigentes() == 0) {

                    swal({
                        title: "Error",
                        text: "No se puede procesar porque no existen contratos vigentes.",
                        icon: "error",
                        button: "Aceptar"
                    })
                    return false;

                } else {

                    if (ValidarFechaPermitidaParaProcesarPagos()) {

                        return true;
                    } else {

                        swal({
                            title: "Error",
                            text: "No se puede procesar porque la fecha actual no corresponde a la fecha admitida para procesar pagos.",
                            icon: "error",
                            button: "Aceptar"
                        })
                        return false;
                    }
                    
                }               

            } else {

                swal({
                    title: "Error",
                    text: "Debes seleccionar un periodo de pago.",
                    icon: "error",
                    button: "Aceptar"
                })
                return false;
            }
        }
});


function totalPeriodosActivos() {

    var totalPeriodosActivos = 0;
    $.ajax({
        type: 'GET',
        url: "/Pagos/DevolverTotalPeriodosActivos",
        datatype: 'json',
        async: false,
        success: function (data) {
            totalPeriodosActivos = data;
        }
    });

    return totalPeriodosActivos;
}

function totalContratosVigentes() {

    var totalContratosVigentes = 0;
    $.ajax({
        type: 'GET',
        url: "/Contrato/CantidadContratosVigentes",
        datatype: 'json',
        async: false,
        success: function (data) {
            totalContratosVigentes = data;
        }
    });

    return totalContratosVigentes;
}

function ValidarFechaPermitidaParaProcesarPagos() {

    var idPeriodo = $('#txtIdPeriodo').val();
    var fechaPermitida = false;
    $.ajax({
        type: 'GET',
        url: "/Pagos/ValidarFechaPermitidaParaProcesarPagos",
        data: { idPeriodo: idPeriodo },
        datatype: 'json',
        async: false,
        success: function (data) {
            fechaPermitida = data;
        }
    });

    return fechaPermitida;
}

$('.soloNumeros').on('input', function () {
    this.value = this.value.replace(/[^0-9]/g, '');
});

$("#txtDni").keypress(function (e) {
    if (e.which == 13) {
        return false;
        }
});
