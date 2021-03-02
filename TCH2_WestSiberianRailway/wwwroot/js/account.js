$(document).ready(function () {
	$('#positions').click(function () {
		GetPositions();
	});

	$('#employees').click(function () {
		GetEmployees();
	});
});

function GetEmployees() {
	$.ajax({
		url: 'https://localhost:44323/content/getemployees',
		method: 'GET',
		success: function (response) {
			let result = JSON.parse(response);
			console.log(result);
			$('#mainArticle').css('color', 'white').text(result);
			DisplayMessage("Список сотрудников ТЧЭ-2 'Омск' загружен", true);
		},
		error: function () {
			DisplayMessage("Ошибка выполнения запроса", false);
		}
	});
}

function GetPositions() {
	$.ajax({
		url: 'https://localhost:44323/content/getpositions',
		method: 'GET',
		success: function (response) {
			let result = JSON.parse(response);
			$('#mainArticle').css('color', 'white').text(result);
			DisplayMessage("Список текущих должностей в ТЧЭ-2 'Омск' загружен", true);
		},
		error: function () {
			DisplayMessage("Ошибка выполнения запроса", false);
		}
	});
}

function DisplayMessage(message, success) {
	if (success) {
		$('#mainMessages').css('color', '#00ff21').text(message);
	}
	else {
		$('#mainMessages').css('color', 'red').text(message);
	}

	setTimeout(function () { $('#mainMessages').text(''); }, 3500);
}
