// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const navBar = document.querySelector('.nav-bar');
const navSideBar = document.querySelector('.nav-side-bar');
const navSideBarButton = document.querySelector('.nav-side-bar-button');
const navSideBarCloseButton = document.querySelector('.nav-side-bar-close-button');

navSideBarButton.addEventListener('click', (e) => {
    navSideBar.style.transform = 'translateX(0%)';
    navSideBar.style.opacity = '100%';
});
navSideBarCloseButton.addEventListener('click', (e) => {
    navSideBar.style.transform = 'translateX(100%)';
    navSideBar.style.opacity = '0%';
});

// Función para abrir la ventana emergente
function openPopup() {
    document.getElementById('popup').style.display = 'block';
}

// Función para cerrar la ventana emergente
function closePopup() {
    document.getElementById('popup').style.display = 'none';
}

// Agregar un listener al botón para abrir la ventana emergente
document.getElementById('openPopup').addEventListener('click', openPopup);


function toggleElementVisibilityById(elementId) {
    const element = document.getElementById(elementId);

    if (element) {
        // Si el elemento existe
        if (element.style.display === 'none') {
            // Si el elemento está oculto, mostrarlo
            element.style.display = 'flex';
        } else {
            // Si el elemento está visible, ocultarlo
            element.style.display = 'none';
        }
    } else {
        console.error('Elemento no encontrado con el ID:', elementId);
    }
}