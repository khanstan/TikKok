// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const popupMenuButton = document.getElementById("vnb__popup");
const collapseMenuButton = document.getElementById("collapse");
const closeMenuButton = document.getElementById("vnb__popup__top__close-button__image")

collapseMenuButton.addEventListener('click', expandMenu);
closeMenuButton.addEventListener('click', closeMenu);

function closeMenu() {
    popupMenuButton.style = 'display:none';
}
function expandMenu() {
    popupMenuButton.style = 'display:flex';
}