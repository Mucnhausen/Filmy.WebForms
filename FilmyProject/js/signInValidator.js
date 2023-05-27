function validate_form() {
    var submitOk = true;

    var username = document.getElementById("<%= usernameBox.ClientID %>").value;

    var fname = document.getElementById("<%= first_nameBox.ClientID %>").value;
    var lname = document.getElementById("<%= last_nameBox.ClientID %>").value;

    var tel = document.getElementById("<%= phoneBox.ClientID %>").value;
    var country = document.getElementById("<%= countryBox.ClientID %>").value;

    var password = document.getElementById("<%= passwordBox.ClientID %>").value;

    var email = document.getElementById("<%= emailBox.ClientID %>").value;

    var username_checker = {
        language: "",
        spaces: false
    }

    var fname_checker = {
        numbers: false,
        language: "english",
        smallLetter: false,
        mixed: false,
        spaces: false
    }

    var lname_checker = {
        numbers: false,
        language: "english",
        smallLetter: false,
        mixed: false,
        spaces: false
    }

    if (!/^\S+$/.test(username))
        username_checker.spaces = true;

    else if (/^[A-z]+$/.test(username)) // checks if the language is English
    {
        username_checker.language = "english";
    }

    if (/[0-9]/.test(fname))
        fname_checker.numbers = true;
    else if (!/^\S+$/.test(fname))
        fname_checker.spaces = true;

    else if (/^[A-z]+$/.test(fname)) // checks if the language is English
    {
        fname_checker.language = "english";
        if (fname[0].toLowerCase() === fname[0]) // checks first letter if it is uppercase or lowercase
            fname_checker.smallLetter = true;
    }
    else if (/^[\u0590-\u05ea]+$/.test(fname))
        fname_checker.language = "hebrew"; // Stopped here

    else
        fname_checker.mixed = true;


    if (/[0-9]/.test(lname))
        lname_checker.numbers = true;

    else if (!/^\S+$/.test(lname))
        lname_checker.spaces = true;

    else if (/^[A-z]+$/.test(lname)) // checks if the language is English
    {
        lname_checker.language = "english";
        if (lname[0].toLowerCase() === lname[0]) // checks first letter if it is uppercase or lowercase
            lname_checker.smallLetter = true;
    }
    else if (/^[\u0590-\u05ea]+$/.test(lname))
        lname_checker.language = "hebrew"; // Stopped here

    else
        lname_checker.mixed = true;


    if (username_checker.language == "english") {
        alert("Username must be in English.");
        submitOk = false;
    }
        

    if (fname_checker.numbers || lname_checker.numbers) {
        alert("Number are not allowed to use in names.");
        if (fname_checker.numbers)
            document.getElementById("<%= first_nameBox.ClientID %>").value = "";
        if (lname_checker.numbers)
            document.getElementById("<%= last_nameBox.ClientID %>").value = "";
        submitOk = false;
    }

    if (fname_checker.spaces || lname_checker.spaces || username_checker.spaces) {
        alert("Spaces are not allowed to use in names.");
        if (fname_checker.spaces)
            document.getElementById("<%= first_nameBox.ClientID %>").value = "";
        if (lname_checker.spaces)
            document.getElementById("<%= last_nameBox.ClientID %>").value = "";
        if (username_checker.spaces)
            document.getElementById("<%= usernameBox.ClientID %>").value = "";
        submitOk = false;
    }

    if (fname_checker.smallLetter || lname_checker.smallLetter) {
        alert("First letter of the name must be in uppercase.");
        if (fname_checker.smallLetter)
            document.getElementById("<%= first_nameBox.ClientID %>").value = "";
        if (lname_checker.smallLetter)
            document.getElementById("<%= last_nameBox.ClientID %>").value = "";
        submitOk = false;
    }

    if (fname_checker.language != lname_checker.language) {
        alert("Remember: you can't mix languages writing the name.\nSpecial symbols are not allowed to use in names.\nPlease, check your input name.");
        document.getElementById("<%= first_nameBox.ClientID %>").value = "";
        document.getElementById("<%= last_nameBox.ClientID %>").value = "";
        submitOk = false;
    }


    // Phone checker
    if (!/^(05[0-9]-[0-9]{7})+$/.test(tel)) {
        alert("Phone number has to be in next format: 050-1234567");
        document.getElementById("<%= phoneBox.ClientID %>").value = "";
        submitOk = false;
    }

    // Password checker
    if (/\S/.test(password)) {
        if (/[\u0590-\u05ea]/.test(password)) {
            alert("Password cannot contain Hebrew letters.");
            document.getElementById("<%= passwordBox.ClientID %>").value = "";
            submitOk = false;
        }
    }

    // Email checker
    if (/([A-z]{1})([A-z0-9\-\_\.]{1,})\@([A-z0-9\-\_\.]{1,})\.[A-z]{2,3}/.test(email))
        pass;
    else {
        alert("Check your email input. \nexample@gmail.com ");
        document.getElementById("<%= emailBox.ClientID %>").value = "";
        submitOk = false;
    }


    if (!submitOk)
        return false
    return true;
}   