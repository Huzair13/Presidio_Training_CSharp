// NAVBAR
window.addEventListener('scroll', function() {
    var navbar = document.querySelector('.navbar');
    var logInAndSignUp = document.getElementById('startQuiz');
    if (window.scrollY > 0) {
        navbar.classList.add('navbar-scrolled');
        logInAndSignUp.classList.add('navbar-scrolled-start')
        
    } else {
        navbar.classList.remove('navbar-scrolled');
        logInAndSignUp.classList.remove('navbar-scrolled-start')
    }
});