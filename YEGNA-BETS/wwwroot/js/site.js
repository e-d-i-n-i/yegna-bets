const menuButton = document.querySelector('.menu');
const dashboard = document.querySelector('.nav-dashboard');
const Content = document.querySelector('.wrapper-section');
menuButton.addEventListener('click', () => {

    if (menuButton.classList.contains("opened")) {
        menuButton.classList.remove("opened"); // Add the new class to the current value of the class attribute
    } else {
        const currentClasses = menuButton.classList; // The element does not have the "opened" class
        currentClasses.add("opened"); // Add the new class to the current value of the class attribute
        menuButton.classList = currentClasses; // Set the element's class attribute to the new value
    }
    if (window.innerWidth <= 767) {
        if (Content.classList.contains("wrapper-section-hide")) {
            Content.classList.remove("wrapper-section-hide");
        } else {
            setTimeout(() => {
                const currentClasses = Content.classList;
                currentClasses.add("wrapper-section-hide");
                Content.classList = currentClasses;
            }, 1000);
        }

    }

    dashboard.style.left = (dashboard.style.left === "0px") ? "-1000px" : "0px";
});



const changeProfile = document.querySelector('#changeProfile');
const browseInput = document.querySelector('#profilePic');
const picBox = document.querySelector('#profilePicBox');
const removeProfile = document.querySelector('#removeProfile');

changeProfile.addEventListener('click', () => {
    browseInput.click();
});


function isDoubleValue(value) {
    return /^\d+(\.\d+)?$/.test(value);
}

function clearInputFields() {
    document.getElementById("matchNumber").value = "";
    document.getElementById("HomeTeam").value = "";
    document.getElementById("AwayTeam").value = "";
    document.getElementById("OddForHomeTeam").value = "";
    document.getElementById("OddForAwayTeam").value = "";
    document.getElementById("OddForDraw").value = "";
}

function showToastMessage(message, status) {
    var toast = document.createElement("div");
    toast.classList.add("toast-msg");
    if (status == "success") {
        toast.classList.add("toast-msg-success");
    }
    else if (status == "danger") {
        toast.classList.add("toast-msg-danger");
    }
    else {
        toast.classList.add("toast-msg-warning");
    }
    toast.classList.add("show");

    // Create the <h1> element and set its content to "hello"
    var heading = document.createElement("span");
    heading.textContent = message;

    // Append the <h1> element to the toast div
    toast.appendChild(heading);

    document.body.appendChild(toast);

    setTimeout(function () {
        toast.classList.remove("show");
        document.body.removeChild(toast);
    }, 2000);
}


//FORMATS MONEY
function formatMoneyString(moneyString) {
    // Remove any existing commas or non-digit characters
    const cleanValue = moneyString.replace(/[^0-9.]/g, '');

    // Split the string into integer and decimal parts
    const parts = cleanValue.split('.');
    let integerPart = parts[0];
    const decimalPart = parts[1] || '';

    // Add commas to the integer part
    integerPart = integerPart.replace(/\B(?=(\d{3})+(?!\d))/g, ',');

    // Combine the integer and decimal parts
    const formattedValue = decimalPart.length > 0 ? `${integerPart}.${decimalPart}` : integerPart;

    return formattedValue;
}

