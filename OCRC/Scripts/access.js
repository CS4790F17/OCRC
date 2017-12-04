$(document).ready(function () {
    console.log('access', $('input[name=access]').val());
    if ($('input[name=access]').val() == '1') {
        $('#userLinks').append('<li><a href="/Account/UserList">Admin</a></li>');
    }
    if ($('input[name=access]').val() == '3' || $('input[name=access]').val() == '4') {
        $('#userLinks').append('<li><a href="/Account/UserList">Team Or School</a></li>');
    }
});
