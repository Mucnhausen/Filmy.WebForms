// JavaScript Code
function validateForm() {
    var submitOk = true;
    var errorMessages = document.getElementById("errorMessages");
    errorMessages.innerHTML = ""; // Clear previous error messages

    // Access ASP.NET TextBox control values using their ClientID
    var username = document.getElementById("<%= usernameBox.ClientID %>").value;
    var fname = document.getElementById("<%= first_nameBox.ClientID %>").value;
    var lname = document.getElementById("<%= last_nameBox.ClientID %>").value;
    var tel = document.getElementById("<%= phoneBox.ClientID %>").value;
    var password = document.getElementById("<%= passwordBox.ClientID %>").value;
    var email = document.getElementById("<%= emailBox.ClientID %>").value;

    var username_checker = {
        language: "",
        spaces: false
    };

    var fname_checker = {
        numbers: false,
        language: "english",
        smallLetter: false,
        mixed: false,
        spaces: false
    };

    var lname_checker = {
        numbers: false,
        language: "english",
        smallLetter: false,
        mixed: false,
        spaces: false
    };

    // Check username
    if (!/^\S+$/.test(username))
        username_checker.spaces = true;
    else if (/^[A-z]+$/.test(username)) // checks if the language is English
        username_checker.language = "english";

    // Check first name
    if (/[0-9]/.test(fname))
        fname_checker.numbers = true;
    else if (!/^\S+$/.test(fname))
        fname_checker.spaces = true;
    else if (/^[A-z]+$/.test(fname)) { // checks if the language is English
        fname_checker.language = "english";
        if (fname[0].toLowerCase() === fname[0]) // checks first letter if it is uppercase or lowercase
            fname_checker.smallLetter = true;
    }
    else if (/^[\u0590-\u05ea]+$/.test(fname))
        fname_checker.language = "hebrew";
    else
        fname_checker.mixed = true;

    // Check last name
    if (/[0-9]/.test(lname))
        lname_checker.numbers = true;
    else if (!/^\S+$/.test(lname))
        lname_checker.spaces = true;
    else if (/^[A-z]+$/.test(lname)) { // checks if the language is English
        lname_checker.language = "english";
        if (lname[0].toLowerCase() === lname[0]) // checks first letter if it is uppercase or lowercase
            lname_checker.smallLetter = true;
    }
    else if (/^[\u0590-\u05ea]+$/.test(lname))
        lname_checker.language = "hebrew";
    else
        lname_checker.mixed = true;

    // Check username language
    if (username_checker.language === "english") {
        errorMessages.innerHTML += "Username must be in English.<br>";
        submitOk = false;
    }

    // Check numbers in names
    if (fname_checker.numbers || lname_checker.numbers) {
        errorMessages.innerHTML += "Numbers are not allowed in names.<br>";
        submitOk = false;
    }

    // Check spaces in names
    if (fname_checker.spaces || lname_checker.spaces || username_checker.spaces) {
        errorMessages.innerHTML += "Spaces are not allowed in names.<br>";
        submitOk = false;
    }

    // Check first letter case in names
    if (fname_checker.smallLetter || lname_checker.smallLetter) {
        errorMessages.innerHTML += "First letter of the name must be in uppercase.<br>";
        submitOk = false;
    }

    // Check mixed languages in names
    if (fname_checker.language !== lname_checker.language) {
        errorMessages.innerHTML += "You can't mix languages in the name.<br>";
        submitOk = false;
    }

    // Check phone number format
    if (!/^(05[0-9]-[0-9]{7})+$/.test(tel)) {
        errorMessages.innerHTML += "Phone number must be in the format: 050-1234567.<br>";
        submitOk = false;
    }

    // Check password for Hebrew letters
    if (/\S/.test(password) && /[\u0590-\u05ea]/.test(password)) {
        errorMessages.innerHTML += "Password cannot contain Hebrew letters.<br>";
        submitOk = false;
    }

    // Check email format
    if (!/([A-z]{1})([A-z0-9\-\_\.]{1,})\@([A-z0-9\-\_\.]{1,})\.[A-z]{2,3}/.test(email)) {
        errorMessages.innerHTML += "Invalid email format. Example: example@gmail.com<br>";
        submitOk = false;
    }

    // Submit the form or handle errors
    return submitOk;
}
