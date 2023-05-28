function displayError(title, message) {
    toastr.error(message, title, { timeOut: 5000, progressBar: true, preventDuplicates: true, extendedTimeOut: 2000, newestOnTop: false });

}

function validateForm() {
    var submitForm = true;
    var id = document.getElementById('idBox').value;
    var ddl = document.getElementById('DropDownList1').value;
    var rating = document.getElementById('ratingBox').value;
    var review = document.getElementById('reviewBox').value;

    // ID name validation
    if (!isValidID(id)) {
        displayError('ID', 'Please enter a valid Review ID (numbers).')
        submitForm = false;
    }

    // Last name validation
    if (!isValidDDL(ddl)) {
        displayError('Movie', 'Please choose a valid movie(from the dropdown list).')
        submitForm = false;
    }

    // Username validation
    if (!isValidRating(rating)) {
        displayError('Rating', 'Please enter a valid rating (number from 1-10).')
        submitForm = false;
    }

    // Review validation
    if (!isValidReview(review)) {
        displayError('Review', 'Please enter a review (at least 10 characters long).')
        submitForm = false;
    }

    // Form is valid
    return submitForm;
}
function isValidID(id) {
    var numberRegex = /^[0-9]+$/;
    return numberRegex.test(id);
}


function isValidDDL(ddl) {
    return ddl != "Movie Title";
}

function isValidRating(rating) {
    var number = parseInt(rating, 10);
    return number <= 10 && number > 0;
}

function isValidReview(review) {
    return review.length >= 10;
}