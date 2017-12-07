$(document).ready(function () {

    $("#teamSelector").hide();
    $("#schoolSelector").hide();

    if ($('input[name=access]').val() == '1') {
        $('#userLinks').append('<li><a href="/Account/UserList">Admin</a></li>');
    }
    if ($('input[name=access]').val() == '3' || $('input[name=access]').val() == '4') {

        $('#userLinks').append('<li><a href="/home/result">Team Or School</a></li>');
    }

    $("#role_2_").on("change", function () {
        if (this.checked) {
            $("#teamSelector").show();
        } else {
            $("#teamSelector").hide();
        }
    })
    $("#role_3_").on("change", function () {
        if (this.checked) {
            $("#schoolSelector").show();
        } else {
            $("#schoolSelector").hide();
        }
    })
});
