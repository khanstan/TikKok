"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/api/notify").build();

connection.on("NotifyUploaded", (message) => {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-left",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "200",
        "hideDuration": "400",
        "timeOut": "5000",
        "extendedTimeOut": "200",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    toastr.info(message);

});

connection.start().catch(function (err) {
    return console.error(err.toString());
});