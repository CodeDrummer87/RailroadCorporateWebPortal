$(document).ready(function () {

	$('#inpSignIn').focus();

    $(document).on('keypress', function (e) {
        if (e.which == 13) {
            // Temporary code
            DisplayCurrentMessage('Клавиша Enter была нажата', true);
        }
    });

});

function DisplayCurrentMessage(message, success) {
    if (success) {
        $('#currentMessage').css('color', 'green').text(message);
    }
    else {
        $('#currentMessage').css('color', 'red').text(message);
    }

    setTimeout(ClearCurrentMessage, 2500);
}

function ClearCurrentMessage() {
    $('#currentMessage').text('');
}
