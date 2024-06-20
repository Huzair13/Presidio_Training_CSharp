const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

test('should display error message for invalid credentials', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const errorMessage = document.getElementById('errorMessage');

    usernameInput.value = 'invaliduser';
    passwordInput.value = 'invalidpassword';

    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);

    expect(errorMessage.style.display).toBe('block');
});

test('should hide error message for valid credentials', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const errorMessage = document.getElementById('errorMessage');

    usernameInput.value = 'Huzair';
    passwordInput.value = '123';

    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);
    
    expect(errorMessage.style.display).toBe('none');
});
