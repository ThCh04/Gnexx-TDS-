const navBar = document.querySelector('.nav-bar');
const navSideBar = document.querySelector('.nav-side-bar');
const navSideBarButton = document.querySelector('.nav-side-bar-button');
const navSideBarCloseButton = document.querySelector('.nav-side-bar-close-button');
const openPopupButton = document.getElementById('openPopup');
const openPopupEdit = document.getElementById('openPopupEdit');

navSideBarButton.addEventListener('click', (e) => {
    navSideBar.style.transform = 'translateX(-10%)';
});

navSideBarCloseButton.addEventListener('click', (e) => {
    navSideBar.style.transform = 'translateX(-110%)';
});

function openPostOptions() {
    document.getElementById('post_options').style.display = 'block';
}

function closePostOptions() {
    document.getElementById('post_options').style.display = 'none';
}

function showConfirmDeletePost() {
    document.getElementById('overlay').style.display = 'block';
    document.getElementById('popupDeletePost').style.display = 'flex';
    closePostOptions();
}

function hideConfirmDeletePost() {
    document.getElementById('overlay').style.display = 'none';
    document.getElementById('popupDeletePost').style.display = 'none';
}

function cancelar() {
    console.log('Operación de eliminación cancelada.');
    hideConfirmDeletePost();
}

function aceptar() {
    console.log('Operación de eliminación confirmada. Realizar acción de eliminación aquí.');
    // Agrega aquí la lógica para la eliminación
    hideConfirmDeletePost();
}

// Función para abrir la ventana emergente
function openPopup() {
    document.getElementById('popup').style.display = 'block';
    closePostOptions();
}

// Función para cerrar la ventana emergente
function closePopup() {
    document.getElementById('popup').style.display = 'none';
}

function toggleDropdownOptions(id) {
    var DropdownElementId = document.getElementById(id);
    if (DropdownElementId.style.display === 'block') {
        // Si está abierto, ciérralo
        DropdownElementId.style.display = 'none';
    } else {
        // Si está cerrado, ábrelo
        DropdownElementId.style.display = 'block';
    }
}

// Agregar un listener al botón para abrir la ventana emergente
openPopupButton.addEventListener('click', openPopup);
openPopupEdit.addEventListener('click', openPopup);