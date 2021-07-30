$('document').ready(function () {

    if (localStorage.getItem("token") === null) {
        localStorage.setItem("token", uuidv4());
    }
    if (window.location.pathname === "/") {
        window.location.replace(localStorage.getItem("token"));
    }

    switch (window.location.search) {
        case "":
            $("#description").html("Description");
            $("#date-added").html("Date Added ▼");
            $("#due-date").html("Due Date");
            break;
        case "?sortOrder=Date_Added_Desc":
            $("#description").html("Description");
            $("#date-added").html("Date Added ▲");
            $("#due-date").html("Due Date");
            break;
        case "?sortOrder=Description":
            $("#description").html("Description ▼");
            $("#date-added").html("Date Added");
            $("#due-date").html("Due Date");
            break;
        case "?sortOrder=Description_Desc":
            $("#description").html("Description ▲");
            $("#date-added").html("Date Added");
            $("#due-date").html("Due Date");
            break;
        case "?sortOrder=Due_Date":
            $("#description").html("Description");
            $("#date-added").html("Date Added");
            $("#due-date").html("Due Date ▼");
            break;
        case "?sortOrder=Due_Date_Desc":
            $("#description").html("Description");
            $("#date-added").html("Date Added");
            $("#due-date").html("Due Date ▲");
            break;
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
Date Added ▼
Date Added ▲
*/