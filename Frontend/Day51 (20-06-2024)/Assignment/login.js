document.getElementById('loginForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    const users = [
        { username: 'Huzair', password: '123' },
        { username: 'Ashi', password: '321' },
        {username: 'Sarath', password:'000'}
    ];
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    
    const user = users.find(user => user.username === username && user.password === password);
    
    const errorMessage = document.getElementById('errorMessage');
    
    if (user) {
        errorMessage.style.display = 'none';
        alert('Login successful!');
    } else {
        errorMessage.style.display = 'block';
    }
});
