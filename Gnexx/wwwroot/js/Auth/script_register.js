
function mostrarSeccion(seccionId) {
    var secciones = document.getElementsByClassName('section-registro');
    for (var i = 0; i < secciones.length; i++) {
        secciones[i].style.display = 'none';
    }
    document.getElementById(seccionId).style.display = 'block';
}

function validarYMostrar(seccionActual, seccionSiguiente) {
    var camposValidos = true;
    var campos = document.querySelectorAll('#' + seccionActual + ' input');
    for (var i = 0; i < campos.length; i++) {
        if (campos[i].value.trim() === '') {
            camposValidos = false;
            alert('Por favor, complete todos los campos antes de continuar.');
            break;
        }
    }

    if (camposValidos) {
        mostrarSeccion(seccionSiguiente);
    }
}
