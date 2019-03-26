/*$(document).ready(function () {
    $('#registerBtn').click(function () {
        $('#loginForm').hide();
        $('#registerForm').show();
        return false;
    });
    $('.back').click(function() {
        $('#loginForm').show();
        $('#registerForm').hide();
        return false;
    });
});*/
document.addEventListener("DOMContentLoaded", function (event) {
    var loginForm = document.getElementById('loginForm');
    var regForm = document.getElementById('registerForm');
    var regBtn = document.getElementById('registerBtn');
    regBtn.addEventListener('click', () => {
        //loginForm.style.display = 'none';
        //regForm.style.display = 'block';
        alert("button has been clicked");
    });
});