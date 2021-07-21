// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('document').ready(function () {
    var uuid = uuidv4();
    if (localStorage.getItem("uuidv4") === null) {
        localStorage.setItem("uuidv4", uuid);
    }
});

$.ajax({
    type: 'POST',
    url: 'https://databaseapp125.azurewebsites.net/',
    data: JSON.stringify({ uuid: localStorage.getItem("uuidv4") }),
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        console.log(data.uuid);
    },
    error: function (error) {
        console.log(error);
    }
});