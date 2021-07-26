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