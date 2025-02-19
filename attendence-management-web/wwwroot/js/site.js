$(document).ready(function () {
	$('.datepicker').datepicker({
		format: 'dd-mm-yyyy',  // Set the format you want
		autoclose: true,
		todayHighlight: true,
		startDate: new Date()
	}).on('changeDate', function (e) {
		$(this).closest('.input-group').find('.datepicker-input').val(e.format());
	});
	$(".datepicker-input").inputmask({
		mask: "99/99/9999",
		alias: "datetime",
		inputFormat: "dd/mm/yyyy",
		placeholder: "dd/mm/yyyy",
		clearIncomplete: true // Prevents partial dates like "12/3_/_"
	});

});