const printToken = () =>{
    const token = localStorage.getItem('token');
    if (token) {
        console.log("JWT Token:", token);
        alert("JWT Token:\n" + token);
    } else {
        alert("No JWT token found in local storage.");
    }
}