
const CheckPassword = async () => {

    let password = document.getElementById("password").value;
    let power = document.getElementById("power-point");
    let widthPower =
        ["1%", "25%", "50%", "75%", "100%"];
    let colorPower =
        ["#FFFFFF", "#A6A6A6", "#7F7F7F", "#FF7C80", "#FF0000"];
    if (password == "") {
        return;
    }
    const postData = {
        email: document.getElementById("email").value,
        password: password,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    }  
    const responsePost = await fetch('api/users/passStrength', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    const dataPost = await responsePost.json();

    if (dataPost!=="") {
      power.style.width = widthPower[dataPost];
      power.style.backgroundColor = colorPower[dataPost]; 
    }
   
}

const Login = async () => {
    const postData = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    }
    const responsePost = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });
    const dataPost = await responsePost.json();
    
    if (dataPost) {
        sessionStorage.setItem("userId", JSON.stringify(dataPost.userId))
        window.location.href = "HomePage.html"
    }
    else {
        alert("שם משתמש או סיסמא אינם תקינים");
    }
};

const Register = async () => {


    const postData = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    }

    const responsePost = await fetch('api/users/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });

    if (responsePost.status == 400) {
        alert("סיסמא חלשה")       
    }
    else {
        if (responsePost) {
             window.location.href = "Login.html";
        }
    }
    
    
      

};

const UpdateUserDetails = async () => {
    const postData = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value
    }
    const id = sessionStorage.getItem("userId");
    const responsePost = await fetch(`api/users/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    });

    if (responsePost.status == 400) {
        alert("סיסמא חלשה")
    }
    else {

        if (responsePost) {
            alert("הפרטים עודכנו בהצלחה");
            window.location.href = "HomePage.html";
        }
    }
    
};
  



