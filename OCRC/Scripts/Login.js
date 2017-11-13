$(document).ready(function () {
    testLocalStorageData();
    loadProfile();
});


function getLocalProfile(callback) {
    var profileName = sessionStorage.getItem("PROFILE_NAME");
    var profileReAuthEmail = sessionStorage.getItem("PROFILE_REAUTH_EMAIL");

    if (profileName !== null
        && profileReAuthEmail !== null) {
        var url = $("#RedirectTo").val();
        location.href = url;
    }
    else {
        var url = $("#RedirectTo").val();
        location.href = url;
    }
}

function loadProfile() {
    if (!supportsHTML5Storage()) { return false; }
    getLocalProfile(function (profileName, profileReAuthEmail) {
        //changes in the UI
        $("#profile-name").html(profileName);
        $("#reauth-email").html(profileReAuthEmail);
        $("#inputEmail").hide();
        $("#remember").hide();
    });
}

function supportsHTML5Storage() {
    try {
        return 'sessionStorage' in window && window['sessionStorage'] !== null;
    } catch (e) {
        return false;
    }
}

function testLocalStorageData() {
    if (!supportsHTML5Storage()) { return false; }
    sessionStorage.setItem("PROFILE_NAME", "Hoang Cao");
    sessionStorage.setItem("PROFILE_REAUTH_EMAIL", "hoangcao@mail.weber.edu");
}