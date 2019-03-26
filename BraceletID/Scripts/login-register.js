/* query for hidding and showing login and registers forms
 $(document).ready(function () {
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
//document.addEventListener("DOMContentLoaded", function (event) { // add this if js file is in the header
    var loginForm = document.getElementById('loginForm');
    var regForm = document.getElementById('registerForm');
    var regBtn = document.getElementById('registerBtn');
var back = document.getElementById('backBtn');
// button listeners
    regBtn.addEventListener('click', () => {
        loginForm.style.display = 'none';
        regForm.style.display = 'block';
    });
    back.addEventListener('click',() => {
        regForm.style.display = 'none';
        loginForm.style.display = 'block';
    });
//});// add this if js file is in the header.