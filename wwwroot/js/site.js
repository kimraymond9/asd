// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('document').ready(function () {
    if (localStorage.getItem("token") === null) {
        localStorage.setItem("token", uuidv4());
    }
    if (window.location.pathname === "/") {
        window.location.replace(localStorage.getItem("token"));
    }
});

$('#create-form').submit(function () {
    $("#create-token").val(localStorage.getItem("token"));
});

$('#edit-form').submit(function () {
    $("#edit-token").val(localStorage.getItem("token"));
});

$('#delete-form').submit(function () {
    $("#delete-token").val(localStorage.getItem("token"));
});

/*
$.ajax({
    type: 'POST',
    url: '/Todos/Create',
    data: JSON.stringify({ UUIDv4: localStorage.getItem("uuidv4") },
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        console.log(data.UUIDv4);
    },
    error: function (error) {
        console.log(error);
    }
});
*/