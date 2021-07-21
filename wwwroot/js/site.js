// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('document').ready(function () {
    var uuid = uuidv4();
    if (localStorage.getItem("uuidv4") === null) {
        localStorage.setItem("uuidv4", uuid);
    }
    console.log(localStorage.getItem("uuidv4"));
});

$.ajax({
    type: 'POST',
    url: 'localhost:5000/Todos/Create',
    data: localStorage.getItem("uuidv4"),
    success: function (data) {
        console.log(data);
    },
    error: function (error) {
        alert('error For details refer console log');
        console.log(error);
    }
});