function displayError(title, message) {
    toastr.error(message, title, { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000, newestOnTop: false });

}

function validatePassword() {
    var submitForm = true;
    var password = document.getElementById('passwordBox').value;
    // Password validation
    if (!isValidPassword(password)) {
        displayError('Password', 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.')
        submitForm = false;
    }
    return submitForm;
}

function validateForm() {
    var submitForm = true;

    var email = document.getElementById('emailBox').value;
    
    var firstName = document.getElementById('first_nameBox').value;
    var lastName = document.getElementById('last_nameBox').value;
    var birthDate = document.getElementById('birth_dateBox').value;
    var country = document.getElementById('countryBox').value;
    var phone = document.getElementById('phoneBox').value;
    var description = document.getElementById('descriptionBox').value;

    // Email validation
    if (!isValidEmail(email)) {
        displayError('Email', 'Please enter a valid email address.')
        submitForm = false;
    }

    
    // First name validation
    if (!isValidName(firstName)) {
        displayError('First Name', 'Please enter a valid first name (letters and hyphens only, at least 2 characters long).')
        submitForm = false;
    }

    // Last name validation
    if (!isValidName(lastName)) {
        displayError('Last Name', 'Please enter a valid last name (letters and hyphens only, at least 2 characters long).')
        submitForm = false;
    }


    // Birth date validation
    if (!isValidBirthDate(birthDate)) {
        displayError('Birth Date', 'Please enter a valid birth date.')
        submitForm = false;
    }

    // Country validation
    if (!isValidCountry(country)) {
        displayError('Country', 'Please enter existing country')
        submitForm = false;
    }

    // Phone validation
    if (!isValidPhone(phone)) {
        displayError('Phone Number', 'Please enter a valid 10-digit phone number.')
        submitForm = false;
    }

    // Description validation
    if (!isValidDescription(description)) {
        displayError('Description', 'Please enter a description (at least 10 characters long).')
        submitForm = false;
    }

    // Form is valid
    return submitForm;
}
function isValidEmail(email) {
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function isValidPassword(password) {
    var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,}$/;
    return passwordRegex.test(password);
}

function isValidName(name) {
    var nameRegex = /^[a-zA-Z-]{2,}$/;
    return nameRegex.test(name);
}

function isValidBirthDate(birthDate) {
    var today = new Date();
    var selectedDate = new Date(birthDate);
    return selectedDate <= today;
}

function isValidCountry(country) {
    var validCountries = [
        'Afghanistan',
        'Albania',
        'Algeria',
        'Andorra',
        'Angola',
        'Antigua and Barbuda',
        'Argentina',
        'Armenia',
        'Australia',
        'Austria',
        'Azerbaijan',
        'Bahamas',
        'Bahrain',
        'Bangladesh',
        'Barbados',
        'Belarus',
        'Belgium',
        'Belize',
        'Benin',
        'Bhutan',
        'Bolivia',
        'Bosnia and Herzegovina',
        'Botswana',
        'Brazil',
        'Brunei',
        'Bulgaria',
        'Burkina Faso',
        'Burundi',
        'Cabo Verde',
        'Cambodia',
        'Cameroon',
        'Canada',
        'Central African Republic',
        'Chad',
        'Chile',
        'China',
        'Colombia',
        'Comoros',
        'Congo, Democratic Republic of the',
        'Congo, Republic of the',
        'Costa Rica',
        'Croatia',
        'Cuba',
        'Cyprus',
        'Czech Republic',
        'Denmark',
        'Djibouti',
        'Dominica',
        'Dominican Republic',
        'East Timor (Timor-Leste)',
        'Ecuador',
        'Egypt',
        'El Salvador',
        'Equatorial Guinea',
        'Eritrea',
        'Estonia',
        'Eswatini',
        'Ethiopia',
        'Fiji',
        'Finland',
        'France',
        'Gabon',
        'Gambia',
        'Georgia',
        'Germany',
        'Ghana',
        'Greece',
        'Grenada',
        'Guatemala',
        'Guinea',
        'Guinea-Bissau',
        'Guyana',
        'Haiti',
        'Honduras',
        'Hungary',
        'Iceland',
        'India',
        'Indonesia',
        'Iran',
        'Iraq',
        'Ireland',
        'Israel',
        'Italy',
        'Jamaica',
        'Japan',
        'Jordan',
        'Kazakhstan',
        'Kenya',
        'Kiribati',
        'Korea, North',
        'Korea, South',
        'Kosovo',
        'Kuwait',
        'Kyrgyzstan',
        'Laos',
        'Latvia',
        'Lebanon',
        'Lesotho',
        'Liberia',
        'Libya',
        'Liechtenstein',
        'Lithuania',
        'Luxembourg',
        'Madagascar',
        'Malawi',
        'Malaysia',
        'Maldives',
        'Mali',
        'Malta',
        'Marshall Islands',
        'Mauritania',
        'Mauritius',
        'Mexico',
        'Micronesia',
        'Moldova',
        'Monaco',
        'Mongolia',
        'Montenegro',
        'Morocco',
        'Mozambique',
        'Myanmar (Burma)',
        'Namibia',
        'Nauru',
        'Nepal',
        'Netherlands',
        'New Zealand',
        'Nicaragua',
        'Niger',
        'Nigeria',
        'North Macedonia (formerly Macedonia)',
        'Norway',
        'Oman',
        'Pakistan',
        'Palau',
        'Palestine',
        'Panama',
        'Papua New Guinea',
        'Paraguay',
        'Peru',
        'Philippines',
        'Poland',
        'Portugal',
        'Qatar',
        'Romania',
        'Russia',
        'Rwanda',
        'Saint Kitts and Nevis',
        'Saint Lucia',
        'Saint Vincent and the Grenadines',
        'Samoa',
        'San Marino',
        'Sao Tome and Principe',
        'Saudi Arabia',
        'Senegal',
        'Serbia',
        'Seychelles',
        'Sierra Leone',
        'Singapore',
        'Slovakia',
        'Slovenia',
        'Solomon Islands',
        'Somalia',
        'South Africa',
        'South Sudan',
        'Spain',
        'Sri Lanka',
        'Sudan',
        'Suriname',
        'Sweden',
        'Switzerland',
        'Syria',
        'Taiwan',
        'Tajikistan',
        'Tanzania',
        'Thailand',
        'Togo',
        'Tonga',
        'Trinidad and Tobago',
        'Tunisia',
        'Turkey',
        'Turkmenistan',
        'Tuvalu',
        'Uganda',
        'Ukraine',
        'United Arab Emirates',
        'United Kingdom',
        'United States of America',
        'Uruguay',
        'Uzbekistan',
        'Vanuatu',
        'Vatican City (Holy See)',
        'Venezuela',
        'Vietnam',
        'Yemen',
        'Zambia',
        'Zimbabwe'
    ];
    return validCountries.includes(country);
}

function isValidPhone(phone) {
    var phoneRegex = /^\d{10}$/;
    return phoneRegex.test(phone);
}

function isValidDescription(description) {
    return description.length >= 10;
}