function displayError(title, message) {
    toastr.error(message, title, { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000, newestOnTop: false });

}

function validateForm() {
    var submitForm = true;
    var title = document.getElementById('titleBox').value;
    var id = document.getElementById('idBox').value;
    var date = document.getElementById('dateBox').value;
    var budget = document.getElementById('budgetBox').value;
    var rating = document.getElementById('ratingBox').value;
    var genres = document.getElementById('genresBox').value;
    var actors = document.getElementById('actorsBox').value;
    var producers = document.getElementById('producersBox').value;
    var description = document.getElementById('descriptionBox').value;

    // Title validation
    if (!isValidTitle(title)) {
        displayError('Title', 'Please enter a valid title (letters, numbesr, hyphens and spaces only).')
        submitForm = false;
    }

    // ID name validation
    if (!isValidID(id)) {
        displayError('ID', 'Please enter a valid Movie ID (numbers only).')
        submitForm = false;
    }

    if (!isValidDate(date)) {
        displayError('Date', 'Please enter a valid date.')
        submitForm = false;
    }

    if (!isValidBudget(budget)) {
        displayError('Budget', 'Please enter a valid budget (numbers, dollar sign and M with K).')
        submitForm = false;
    }

    if (!isValidRating(rating)) {
        displayError('Rating', 'Please enter a valid rating (number from 1-10).')
        submitForm = false;
    }

    if (!isValidGenres(genres)) {
        displayError('Genres', 'Please enter valid genres (letters, commas and spaces only).')
        submitForm = false;
    }

    if (!isValidActors(actors)) {
        displayError('Actors', 'Please enter valid actors (letters, commas and spaces only).')
        submitForm = false;
    }

    if (!isValidProducers(producers)) {
        displayError('Producers', 'Please enter valid producers (letters, commas and spaces only).')
        submitForm = false;
    }

    if (!isValidDescription(description)) {
        displayError('Description', 'Please enter valid description (at least 10 characters long).')
        submitForm = false;
    }

    // Form is valid
    return submitForm;
}


function isValidTitle(title) {
    return true;
}

function isValidID(id) {
    var numberRegex = /^[0-9]+$/;
    return numberRegex.test(id);
}

function isValidDate(date) {
    var today = new Date();
    var selectedDate = new Date(date);
    return selectedDate <= today;
}

function isValidBudget(budget) {
    var budgetRegex = /^\$?\d+(?:\.\d+)?(?:M|K)?$/i;
    return budgetRegex.test(budget);
}

function isValidRating(rating) {
    var number = parseInt(rating, 10);
    return number <= 10 && number > 0;
}

function isValidGenres(genres) {
    var genresRegex = /^[A-Za-z, ]+$/;
    return genresRegex.test(genres);
}

function isValidActors(actors) {
    var actorsRegex = /^[A-Za-z, ]+$/;
    return actorsRegex.test(actors);
}

function isValidProducers(producers) {
    var producersRegex = /^[A-Za-z, ]+$/;
    return producersRegex.test(producers);
}

function isValidDescription(description) {
    return description.length >= 10;
}